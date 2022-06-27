namespace MyToDoList.Models.Interfaces;

public interface IToDoItem
{
    string Text { get; set; }
    bool IsCompleted { get; set; }
}
