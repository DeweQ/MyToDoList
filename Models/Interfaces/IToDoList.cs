namespace MyToDoList.Models.Interfaces;

public interface IToDoList
{
    string Name { get; set; }
    List<IToDoItem> Items { get; set; }
    void Add(IToDoItem Task);
    void Remove(IToDoItem selectedItem);
}
