namespace MyToDoList;

public class ToDoList
{
    public List<ToDoListTask>? Tasks { get; private set; }
    public string Name { get; private set; } = "List";
}