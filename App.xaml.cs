using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
            var ViewModel = new ApplicationViewModel(InitializeList());
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
                    Items = new List<ToDoListItem>()
                    {
                        new ToDoListItem(){Text="ViewModel Implementation",IsCompleted=true},
                        new ToDoListItem(){Text="Serialization"},
                    }
                },new ToDoList()
                {
                    Name = "Model Level",
                    Items = new List<ToDoListItem>()
                    {
                        new ToDoListItem(){Text="Basic model",IsCompleted=true},
                        new ToDoListItem(){Text="Interface extraction"},
                        new ToDoListItem(){Text="Better ViewModel interaction"},
                    }
                },new ToDoList()
                {
                    Name = "View Level",
                    Items = new List<ToDoListItem>()
                    {
                        new ToDoListItem(){Text="Baic presentation of elements",IsCompleted=true},
                        new ToDoListItem(){Text="Propper binding and commands"},
                        new ToDoListItem(){Text="Better design and visualisation"},
                    }
                }
            };
        }
    }
}
