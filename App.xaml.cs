namespace MyToDoList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        App()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            App app = new App();
            ApplicationViewModel? ViewModel = InitializeViewModel();
            MainWindow window = new MainWindow(ViewModel);
            app.Run(window);
            SerializeViewModel(ViewModel);
        }


        static ApplicationViewModel InitializeViewModel()
        {

            var ToDoLists = GetToDoLists();
            var viewModel = new ApplicationViewModel(ToDoLists, new Generator());
            return viewModel;
        }

        #region Serialization
        private static void SerializeViewModel(ApplicationViewModel viewModel)
        {
            List<IToDoList> toDoLists = viewModel.ToDoLists.Select(x => x.List).ToList();
            var json = Infrastructure.JsonSerializer.Serialize(toDoLists);
            WriteJsonToFile("ToDoLists.json", json);
        }

        static List<IToDoList> GetToDoLists()
        {
            var json = ReadJsonFromFile("ToDoLists.json");
            var ToDoLists = Infrastructure.JsonSerializer.DeserealizeToDoLists(json);
            if (ToDoLists == null)
                ToDoLists = InitializeList();
            return ToDoLists;
        }

        private static string ReadJsonFromFile(string fileName)
        {
            var path = Directory.GetCurrentDirectory();
            var fullFileName = $"{path}/Resources/{fileName}";
            var output = "";
            if (!File.Exists(fullFileName))
                Directory.CreateDirectory("Resources");
            using (var stream = new FileStream(fullFileName, FileMode.OpenOrCreate))
            using (var sr = new StreamReader(stream))
                output = sr.ReadToEnd();
            return output;
        }

        private static void WriteJsonToFile(string fileName, string json)
        {
            var path = Directory.GetCurrentDirectory();
            var fullFileName = $"{path}/Resources/{fileName}";
            using (var stream = new FileStream(fullFileName, FileMode.OpenOrCreate))
            using (var sw = new StreamWriter(stream))
                sw.WriteLine(json);
        }
        #endregion

        static List<IToDoList> InitializeList()
        {
            return new List<IToDoList>()
            {
                new ToDoList()
                {
                    Name = "Application Level",
                    Items = new List<IToDoItem>()
                    {
                        new ToDoItem(){Text="ViewModel Implementation",IsCompleted=true},
                        new ToDoItem(){Text="Serialization"},
                    }
                },
                new ToDoList()
                {
                    Name = "Model Level",
                    Items = new List<IToDoItem>()
                    {
                        new ToDoItem(){Text="Basic model",IsCompleted=true},
                        new ToDoItem(){Text="Interface extraction",IsCompleted=true},
                        new ToDoItem(){Text="Better ViewModel interaction"},
                    }
                },
                new ToDoList()
                {
                    Name = "View Level",
                    Items = new List<IToDoItem>()
                    {
                        new ToDoItem(){Text="Baic presentation of elements",IsCompleted=true},
                        new ToDoItem(){Text="Propper binding and commands",IsCompleted=true},
                        new ToDoItem(){Text="Better design and visualisation"},
                    }
                }
            };
        }
    }
}
