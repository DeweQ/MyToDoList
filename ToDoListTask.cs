namespace MyToDoList;

public class ToDoListTask
{
    public string Text { get; set; } = "";
    public bool IsCompleted { get; private set; } = false;
}