namespace MyToDoList;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
{
    public ObservableCollection<ToDoList> ToDoLists { get; private set; }
    public ToDoList? SelectedList;

    public MainWindow(ApplicationViewModel applicationViewModel)
    {
        InitializeComponent();
        this.DataContext = applicationViewModel;
        //ToDoLists = new ObservableCollection<ToDoList>(toDoLists);

        //ListSelectionSection.Resources.Add("ToDoLists", ToDoLists);

        //Lists.ItemsSource = (ObservableCollection<ToDoList>)ListSelectionSection.Resources["ToDoLists"];
        //Lists.SelectedIndex = 0;

    }

    //private void Lists_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{

    //    ListView list = (ListView)sender;
    //    ToDoList td = (ToDoList)list.SelectedItem;
    //    SelectedList = td;
    //    Tasks.Items.Refresh();
    //    Tasks.ItemsSource = SelectedList.Items;
    //    CurrentListLabel.Content = SelectedList.Name;
    //}

    //private void AddListButton_Click(object sender, RoutedEventArgs e)
    //{
    //    var newList = new TextBox();
    //    newList.LostFocus += NewList_LostFocus;
    //    newList.PreviewKeyUp += NewList_PreviewKeyUp;
    //    ListsStackPanel.Children.Add(newList);
    //    newList.Focus();
    //}

    //private void NewList_LostFocus(object sender, RoutedEventArgs e)
    //{
    //    TextBox tb = (TextBox)sender;
    //    if (tb.IsKeyboardFocusWithin)
    //        return;
    //    CreateNewList(sender);
    //}


    //private void NewList_PreviewKeyUp(object sender, KeyEventArgs e)
    //{
    //    if (e.Key == Key.Enter)
    //        CreateNewList(sender);
    //}

    //private void CreateNewList(object sender)
    //{
    //    var tb = (TextBox)sender;
    //    if (!string.IsNullOrEmpty(tb.Text))
    //    {
    //        ToDoLists.Add(new ToDoList() { Name = tb.Text });
    //    }
    //    ListsStackPanel.Children.Remove(tb);
    //}
}
