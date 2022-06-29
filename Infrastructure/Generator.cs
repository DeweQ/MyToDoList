namespace MyToDoList.Infrastructure;

public class Generator
{
    private Func<IToDoItem> generateToDoItem = () => new ToDoItem();
    private Func<IToDoList> generateToDoList = () => new ToDoList();
    public Generator(Func<IToDoItem>? generateToDoItem = null, Func<IToDoList>? generateToDoList = null)
    {
        if (generateToDoItem != null)
            this.generateToDoItem = generateToDoItem;
        if (generateToDoList != null)
            this.generateToDoList = generateToDoList;
    }
    public IToDoItem CreateItem() => generateToDoItem.Invoke();
    public IToDoList CreateList() => generateToDoList.Invoke();
}
