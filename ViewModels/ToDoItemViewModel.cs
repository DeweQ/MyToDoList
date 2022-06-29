namespace MyToDoList.ViewModels;

public class ToDoItemViewModel : INotifyPropertyChanged
{

    IToDoItem item;

    public bool IsCompleted
    {
        get => item.IsCompleted;
        set
        {
            item.IsCompleted = value;
            OnPropertyChanged("IsCompleted");
        }
    }

    public IToDoItem Item { get => Item; }

    public string Text
    {
        get => item.Text;
        set
        {
            item.Text = value;
            OnPropertyChanged("Text");
        }
    }

    public ToDoItemViewModel(IToDoItem item)
    {
        this.item = item;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string property = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
