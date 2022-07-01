namespace MyToDoList.ViewModels;

public class ApplicationViewModel : INotifyPropertyChanged
{
    #region Fields
    private readonly Generator Generator;
    private ToDoListViewModel selectedList;
    private ToDoItemViewModel selectedItem;
    private RelayCommand addItemCommand;
    private RelayCommand removeItemCommand;
    private RelayCommand addListCommand;
    private RelayCommand removeListCommand;
    #endregion

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<ToDoListViewModel> ToDoLists { get; set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ApplicationViewModel(
        IEnumerable<IToDoList> todoLists,
        Generator generator)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
        Generator = generator; 
        ToDoLists = new ObservableCollection<ToDoListViewModel>(todoLists.Select(l => new ToDoListViewModel(l)));
        if (ToDoLists.Count > 0)
            SelectedList = ToDoLists[0];
    }

    public ToDoListViewModel SelectedList
    {
        get => selectedList;
        set
        {
            selectedList = value;
            OnPropertyChanged("SelectedList");
            if (SelectedList?.Items.Count > 0)
                SelectedItem = SelectedList.Items[0];
        }
    }
    public ToDoItemViewModel SelectedItem
    {
        get => selectedItem;
        set
        {
            selectedItem = value;
            OnPropertyChanged("SelectedItem");
        }
    }

    #region //Commands
    public RelayCommand AddItemCommand
    {
        get
        {
            return addItemCommand ??
                (addItemCommand = new RelayCommand(obj =>
                {
                    var task = Generator.CreateItem();
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
    #endregion

    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
    
}
