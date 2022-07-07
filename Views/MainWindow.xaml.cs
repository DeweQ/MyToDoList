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
        
        var parent = RelativeFinder.FindParent<ItemsControl>(sender as TextBox);
        var button = RelativeFinder.FindChildByName<ToggleButton>(parent,"EditButton");
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

    
}
