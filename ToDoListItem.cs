namespace MyToDoList;

public class ToDoListItem : INotifyPropertyChanged
{
    private bool isCompleted = false;

    public string Text { get; set; } = "";
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