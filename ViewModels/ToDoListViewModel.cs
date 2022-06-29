namespace MyToDoList.ViewModels;

public class ToDoListViewModel : INotifyPropertyChanged
{
    IToDoList List;

    public event PropertyChangedEventHandler? PropertyChanged;
    //public event NotifyCollectionChangedEventHandler? CollectionChanged;

    public ObservableCollection<ToDoItemViewModel> Items { get;private set; }


    //public IReadOnlyList<ToDoItemViewModel> Items 
    //{ get =>List.Items.Select(l => new ToDoItemViewModel(l)).ToList(); }



    public ToDoListViewModel(IToDoList list)
    {
        List = list;
        Items = new ObservableCollection<ToDoItemViewModel>(list.Items.Select(i => new ToDoItemViewModel(i)));
    }


    public string Name
    {
        get => List.Name;
        set
        {
            List.Name = value;
            OnPropertyChanged("Name");
        }
    }


    public void Add(IToDoItem Task)
    {
        List.Add(Task);
        Items.Add(new ToDoItemViewModel(Task));
    }

    public void Remove(ToDoItemViewModel selectedItem)
    {
        List.Remove(selectedItem.Item);
        Items.Remove(selectedItem);
    }

    void OnPropertyChanged([CallerMemberName] string property = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
