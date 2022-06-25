namespace MyToDoList;

public class ApplicationViewModel : INotifyPropertyChanged
{
    private ToDoList selectedItem;

    public ObservableCollection<ToDoList> ToDoLists { get; set; }

    public ApplicationViewModel(IEnumerable<ToDoList> toDoLists)
    {
        ToDoLists = new ObservableCollection<ToDoList>(toDoLists);
        if (ToDoLists.Count() > 0)
            selectedItem = ToDoLists[0];
    }

    public ToDoList SelectedItem
    {
        get => selectedItem;
        set
        {
            selectedItem = value;
            OnPropertyChanged("SelectedItem");
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
