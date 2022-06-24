namespace MyToDoList;

public class ToDoList
{
    public List<ToDoListItem> Items { get; set; } = new List<ToDoListItem>();
    public string Name { get; set; } = "List";
}