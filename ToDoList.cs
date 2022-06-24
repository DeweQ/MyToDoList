namespace MyToDoList;

public class ToDoList
{
    public List<ToDoListTask> Tasks { get; set; } = new List<ToDoListTask>();
    public string Name { get; set; } = "List";
}