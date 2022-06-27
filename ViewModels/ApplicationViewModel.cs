namespace MyToDoList.ViewModels;

public class ApplicationViewModel : INotifyPropertyChanged
{

    private IToDoList selectedList;
    private IToDoItem selectedItem;
    private RelayCommand addItemCommand;
    private RelayCommand removeItemCommand;
    private RelayCommand addListCommand;
    private RelayCommand removeListCommand;


    public event PropertyChangedEventHandler? PropertyChanged;

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

    public RelayCommand AddItemCommand
    {
        get
        {
            return addItemCommand ??
                (addItemCommand = new RelayCommand(obj =>
                {
                    var task = new ToDoItem();
                    SelectedList.Add(task);
                }));
        }
    }

    public RelayCommand RemoveItemCommand 
    {
        get
        {
            return removeItemCommand ??
                (removeItemCommand = new RelayCommand(obj =>
                {
                    SelectedList.Remove(SelectedItem);
                }));
        }
    }

    public RelayCommand AddListCommand 
    {
        get
        {

            return addListCommand ??
                (addListCommand = new RelayCommand(obj =>
                {
                    ToDoLists.Add(new ToDoListViewModel(new ToDoList()));
                }));
        }
    }
    public RelayCommand RemoveListCommand
    {
        get
        {
            return removeListCommand ??
                (removeListCommand = new RelayCommand(obj =>
                {
                    ToDoLists.Remove(SelectedList);
                }));
        }
    }

    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
    
}
