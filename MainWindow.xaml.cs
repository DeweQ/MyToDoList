using MyToDoList.ViewModels;

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
}
