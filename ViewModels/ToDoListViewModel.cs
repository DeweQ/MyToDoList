namespace MyToDoList.ViewModels;

public class ToDoListViewModel : IToDoList, INotifyPropertyChanged
{
    IToDoList List;
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
    List<IToDoItem> IToDoList.Items { get => List.Items; set => List.Items = value; }

    public ToDoListViewModel(IToDoList list)
    {
        List = list;
        Items = new ObservableCollection<IToDoItem>(List.Items);
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string property="")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }

    public void AddItem(IToDoItem Task)
    {
        List.AddItem(Task);
        Items.Add(Task);
    }
}
