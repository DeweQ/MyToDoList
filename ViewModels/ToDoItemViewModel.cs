namespace MyToDoList.ViewModels;

public class ToDoItemViewModel : IToDoItem, INotifyPropertyChanged
{

    IToDoItem Item;

    public bool IsCompleted
    {
        get => Item.IsCompleted;
        set
        {
            Item.IsCompleted = value;
            OnPropertyChanged("IsCompleted");
        }
    }

    public string Text
    {
        get => Item.Text;
        set
        {
            Item.Text = value;
            OnPropertyChanged("Text");
        }
    }

    public ToDoItemViewModel(IToDoItem item)
    {
        Item = item;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void OnPropertyChanged([CallerMemberName] string property = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
