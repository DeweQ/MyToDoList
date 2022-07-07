namespace MyToDoList
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
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

        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(',') ? args.Name.Substring(0, args.Name.IndexOf(',')) :
                args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");

            if (dllName.EndsWith("_resources")) return null;

            System.Resources.ResourceManager rm = new(GetType().Namespace + ".Properties.Resources",
                System.Reflection.Assembly.GetExecutingAssembly());

            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);

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
            Infrastructure.ResourceManager.WriteFile("ToDoLists", json);
        }

        static List<IToDoList> GetToDoLists()
        {
            var json = Infrastructure.ResourceManager.ReadFile("ToDoLists");
            var ToDoLists = Infrastructure.JsonSerializer.DeserealizeToDoLists(json);
            if (ToDoLists == null)
                ToDoLists = InitializeNewList();
            return ToDoLists;
        }
        #endregion

        static List<IToDoList> InitializeNewList()
        {
            return new List<IToDoList>()
            {
                new ToDoList()
                {
                    Name = "Orginize your ToDo List!",
                    Items = new List<IToDoItem>()
                    {
                        new ToDoItem(){Text="Add new lists and tasks to begin with!"},
                    }
                }
            };
        }
    }
}
