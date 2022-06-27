namespace MyToDoList.ViewModels;

public class ApplicationViewModel : INotifyPropertyChanged
{

    private IToDoList selectedList;
    private IToDoItem selectedItem;

    public ObservableCollection<IToDoList> ToDoLists { get; set; }

    public ApplicationViewModel(IEnumerable<IToDoList> todoLists)
    {
        ToDoLists = new ObservableCollection<IToDoList>(todoLists);
        if (ToDoLists.Count > 0)
            SelectedList = ToDoLists[0];
    }

    public IToDoList SelectedList
    {
        get => selectedList;
        set
        {
            selectedList = value;
            OnPropertyChanged("SelectedList");
            if (SelectedList.Items.Count > 0)
                SelectedItem = SelectedList.Items[0];
        }
    }

    public IToDoItem SelectedItem
    {
        get => selectedItem;
        set
        {
            selectedItem = value;
            OnPropertyChanged("SelectedItem");
        }
    }

    private RelayCommand addItemCommand;
    public RelayCommand AddItemCommand
    {
        get
        {
            return addItemCommand ??
                (addItemCommand = new RelayCommand(obj =>
                {
                    var task = new ToDoItem();
                    SelectedList.AddItem(task);
                }));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
    //private ToDoList selectedItem;
    //private ToDoItem selectedListItem;

    //public ObservableCollection<ToDoList> ToDoLists { get; set; }

    //public ApplicationViewModel(IEnumerable<ToDoList> toDoLists)
    //{
    //    ToDoLists = new ObservableCollection<ToDoList>(toDoLists);
    //    if (ToDoLists.Count > 0)
    //        SelectedItem = ToDoLists[0];
    //}

    //private RelayCommand addTaskCommand;
    //public RelayCommand AddTaskCommand
    //{
    //    get
    //    {
    //        return addTaskCommand ??
    //            (addTaskCommand = new RelayCommand(obj =>
    //            {
    //                //SelectedItem.Items.Add(new ToDoItem());
    //            }));
    //    }
    //}












    //public ToDoItem SelectedListItem
    //{
    //    get => selectedListItem;
    //    set
    //    {
    //        selectedListItem = value;
    //        OnPropertyChanged("SelectedListItem");
    //    }
    //}
    //public ToDoList SelectedItem
    //{
    //    get => selectedItem;
    //    set
    //    {
    //        selectedItem = value;
    //        if (value?.Items.Count > 0)
    //            SelectedListItem = value.Items[0];
    //        OnPropertyChanged("SelectedItem");
    //    }
    //}
}
