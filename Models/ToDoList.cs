namespace MyToDoList.Models;

public class ToDoList :IToDoList
{
    public List<IToDoItem> Items { get; set; } = new List<IToDoItem>();
    public string Name { get; set; } = "List";

    public void AddItem(IToDoItem Task)
    {
        Items.Add(Task);
    }
}