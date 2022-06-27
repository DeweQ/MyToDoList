namespace MyToDoList.ViewModels;

public class ToDoListViewModel : IToDoList, INotifyPropertyChanged
{
    IToDoList List;
    List<IToDoItem> IToDoList.Items { get => List.Items; set => List.Items = value; }

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Name
    {
        get => List.Name;
        set
        {
            List.Name = value;
            OnPropertyChanged("Name");
        }
    }
    public ObservableCollection<IToDoItem> Items { get; set; }

    public ToDoListViewModel(IToDoList list)
    {
        List = list;
        Items = new ObservableCollection<IToDoItem>(List.Items);
    }

    void OnPropertyChanged([CallerMemberName] string property="")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    public void Add(IToDoItem Task)
    {
        List.Add(Task);
        Items.Add(Task);
    }

    public void Remove(IToDoItem selectedItem)
    {
        Items.Remove(selectedItem);
        List.Remove(selectedItem);
    }
}
