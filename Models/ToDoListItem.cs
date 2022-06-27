namespace MyToDoList.Models;

public class ToDoItem :IToDoItem
{
    public bool IsCompleted { get; set; } = false;
    public string Text { get; set; } = "New task";
}