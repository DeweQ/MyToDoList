using MyToDoList.Models;
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

        static List<IToDoList> InitializeList()
        {
            return new List<IToDoList>()
            {
                new ToDoListViewModel(new ToDoList()
                {
                    Name = "Application Level",
                    Items = new List<IToDoItem>()
                    {
                        new ToDoItemViewModel(
                            new ToDoItem(){Text="ViewModel Implementation",IsCompleted=true}),
                        new ToDoItemViewModel(new ToDoItem(){Text="Serialization"}),
                    }
                }),
                new ToDoListViewModel(new ToDoList()
                {
                    Name = "Model Level",
                    Items = new List<IToDoItem>()
                    {
                        new ToDoItemViewModel(new ToDoItem(){Text="Basic model",IsCompleted=true}),
                        new ToDoItemViewModel(new ToDoItem(){Text="Interface extraction",IsCompleted=true}),
                        new ToDoItemViewModel(new ToDoItem(){Text="Better ViewModel interaction"}),
                    }
                }),
                new ToDoListViewModel(new ToDoList()
                {
                    Name = "View Level",
                    Items = new List<IToDoItem>()
                    {
                        new ToDoItemViewModel(new ToDoItem(){Text="Baic presentation of elements",IsCompleted=true}),
                        new ToDoItemViewModel(new ToDoItem(){Text="Propper binding and commands"}),
                        new ToDoItemViewModel(new ToDoItem(){Text="Better design and visualisation"}),
                    }
                })
            };
        }
    }
}
