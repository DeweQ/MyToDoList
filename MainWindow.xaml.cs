﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ToDoList> ToDoLists { get; private set; }
        public MainWindow(List<ToDoList> toDoLists)
        {
            InitializeComponent();
            ToDoLists = toDoLists;

            Lists.ItemsSource = ToDoLists;
            
        }

        private void Lists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView list = (ListView)sender;
            ToDoList td = (ToDoList)list.SelectedItem;

            Binding binding = new Binding();
            binding.Source = td;
            binding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            Tasks.ItemsSource = td.Tasks;
        }
    }
}
