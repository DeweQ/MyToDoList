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
            MainWindow window = new MainWindow(InitializeList());
            app.Run(window);
        }

        static List<ToDoList> InitializeList()
        {
            return new List<ToDoList>()
            {
                new ToDoList()
                {
                    Name = "List one",
                    Items = new List<ToDoListItem>()
                    {
                        new ToDoListItem(){Text="task 1"},
                        new ToDoListItem(){Text="task 2"},
                        new ToDoListItem(){Text="task 3"},
                        new ToDoListItem(){Text="task 4"},
                    }
                },new ToDoList()
                {
                    Name = "List two",
                    Items = new List<ToDoListItem>()
                    {
                        new ToDoListItem(){Text="task 5"},
                        new ToDoListItem(){Text="task 6"},
                        new ToDoListItem(){Text="task 7"},
                        new ToDoListItem(){Text="task 8"},
                    }
                },new ToDoList()
                {
                    Name = "List three",
                    Items = new List<ToDoListItem>()
                    {
                        new ToDoListItem(){Text="task 9"},
                        new ToDoListItem(){Text="task 10"},
                        new ToDoListItem(){Text="task 11"},
                        new ToDoListItem(){Text="task 12"},
                    }
                }
            };
        }
    }
}
