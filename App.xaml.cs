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
                    Tasks = new List<ToDoListTask>()
                    {
                        new ToDoListTask(){Text="task 1"},
                        new ToDoListTask(){Text="task 2"},
                        new ToDoListTask(){Text="task 3"},
                        new ToDoListTask(){Text="task 4"},
                    }
                },new ToDoList()
                {
                    Name = "List two",
                    Tasks = new List<ToDoListTask>()
                    {
                        new ToDoListTask(){Text="task 5"},
                        new ToDoListTask(){Text="task 6"},
                        new ToDoListTask(){Text="task 7"},
                        new ToDoListTask(){Text="task 8"},
                    }
                },new ToDoList()
                {
                    Name = "List three",
                    Tasks = new List<ToDoListTask>()
                    {
                        new ToDoListTask(){Text="task 9"},
                        new ToDoListTask(){Text="task 10"},
                        new ToDoListTask(){Text="task 11"},
                        new ToDoListTask(){Text="task 12"},
                    }
                }
            };
        }
    }
}
