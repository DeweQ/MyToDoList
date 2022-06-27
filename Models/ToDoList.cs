namespace MyToDoList.Models;

public class ToDoList :IToDoList
{
    public List<IToDoItem> Items { get; set; } = new List<IToDoItem>();
    public string Name { get; set; } = "List";

    public void Add(IToDoItem Task)
    {
        Items.Add(Task);
    }

    public void Remove(IToDoItem selectedItem)
    {
        Items.Remove(selectedItem);
    }
}