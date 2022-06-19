namespace Tegu.Net.Client.Maui.Pages.Public;

public partial class MainPage : ContentPage
{
    public MainPage(MainVM vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}