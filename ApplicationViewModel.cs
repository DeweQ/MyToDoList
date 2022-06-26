namespace MyToDoList;

public class ApplicationViewModel : INotifyPropertyChanged
{
    private ToDoList selectedItem;
    private ToDoListItem selectedListItem;

    public ObservableCollection<ToDoList> ToDoLists { get; set; }

    public ApplicationViewModel(IEnumerable<ToDoList> toDoLists)
    {
        ToDoLists = new ObservableCollection<ToDoList>(toDoLists);
        if (ToDoLists.Count > 0)
            SelectedItem = ToDoLists[0];
    }

    public ToDoListItem SelectedListItem
    { 
        get => selectedListItem;
        set
        {
            selectedListItem = value;
            OnPropertyChanged("SelectedListItem");
        }
    }
    public ToDoList SelectedItem
    {
        get => selectedItem;
        set
        {
            selectedItem = value;
            if (value?.Items.Count > 0)
                SelectedListItem = value.Items[0];
            OnPropertyChanged("SelectedItem");
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
