namespace MyToDoList;

public class RelayCommand : ICommand
{
    private Action<Object> execute;
    private Func<object, bool> canExecute;

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public RelayCommand(Action<object> execute, Func<object, bool> canExecute=null)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return this.CanExecute == null || true;
    }

    public void Execute(object? parameter)
    {
        this.execute(parameter);
    }
}
