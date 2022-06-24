namespace MyToDoList;

public class ApplicationViewModel : INotifyPropertyChanged
{
    private ToDoList selectedItem;

    public ObservableCollection<ToDoList> ToDoLists { get; set; }

    public ApplicationViewModel(IEnumerable<ToDoList> toDoLists)
    {
        ToDoLists = new ObservableCollection<ToDoList>(toDoLists);
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
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }
}
