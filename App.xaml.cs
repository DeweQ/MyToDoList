

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
            var list = InitializeList();
            var ViewModel = new ApplicationViewModel(InitializeList(), new Generator());
            var js = JsonSerializer.Serialize<List<ToDoList>>(list);
            var vm = JsonSerializer.Deserialize<List<ToDoList>>(js);
            if (list.Equals(vm))
                MessageBox.Show("Success");
            MainWindow window = new MainWindow(ViewModel);
            app.Run(window);
        }

        static List<ToDoList> InitializeList()
        {
            return new List<ToDoList>()
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
