namespace Tegu.Net.Client.Maui.Pages;

public partial class ControlsPage : ContentPage
{
	public ControlsPage(ControlsVM vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}