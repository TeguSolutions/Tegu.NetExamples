namespace Tegu.Net.Client.Maui.Pages;

public partial class NavigationAbsolutePage : ContentPage
{
	public NavigationAbsolutePage(NavigationAbsoluteVM vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}