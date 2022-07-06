using MyToDoList.ViewModels;
using System.Windows.Controls.Primitives;

namespace MyToDoList;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow(ApplicationViewModel applicationViewModel)
    {
        InitializeComponent();
        this.DataContext = applicationViewModel;
    }

    private void EditTextBoxLostFocus(object sender, RoutedEventArgs e)
    {
        var parent = FindParent<ItemsControl>(sender as TextBox);
        var button = FindChildByName<ToggleButton>(parent,"EditButton");
        button.IsChecked = false;
    }

    private void SelectAllText(object sender, KeyboardFocusChangedEventArgs e)
    {
        TextBox tb = sender as TextBox;
        tb.SelectAll();
    }

    private void LoseFocusOnEnterKeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
            EditTextBoxLostFocus(sender, e);
    }

    private T FindParent<T>(DependencyObject child) where T : DependencyObject
    {
        var parent = VisualTreeHelper.GetParent(child);
        if (parent == null)
            return null;
        if (parent is T)
            return parent as T;
        return FindParent<T>(parent);
    }

    private T FindParentByName<T>(DependencyObject child, string name) where T : DependencyObject
    {
        var parent = VisualTreeHelper.GetParent(child);
        if (parent == null)
            return null;
        if (parent is T && 
            (parent as Control).Name == name)
            return parent as T;
        return FindParentByName<T>(parent,name);
    }

    private T FindChild<T>(DependencyObject parent) where T : DependencyObject
    {
        int count = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = count - 1; i >= 0; i--)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is T)
                return child as T;
            else child = FindChild<T>(child);
            if (child is T)
                return child as T;
        }
        return null;
    }

    private T FindChildByName<T>(DependencyObject parent,string name) where T : DependencyObject
    {
        int count = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i <count; i++)
        {
            var child = VisualTreeHelper.GetChild(parent, i);
            if (child is T && (child as Control).Name == name)
                return child as T;
            else child = FindChildByName<T>(child,name);
            if (child is T && (child as Control).Name == name)
                return child as T;
        }
        return null;
    }
}
