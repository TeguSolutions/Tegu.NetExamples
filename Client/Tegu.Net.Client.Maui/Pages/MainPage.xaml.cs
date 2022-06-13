namespace Tegu.Net.Client.Maui.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainVM vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
}