namespace MyToDoList;

public class ToDoListItem : INotifyPropertyChanged
{
    private bool isCompleted = false;
    private string text = "";

    public string Text { get => text;
        set
        {
            text = value;
            OnPropertyChanged("Text");
        }
    }
    public bool IsCompleted
    {
        get => isCompleted;
        set
        {
            isCompleted = value;
            OnPropertyChanged("IsCompleted");
        }
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}