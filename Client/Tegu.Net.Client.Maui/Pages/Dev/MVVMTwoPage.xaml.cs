namespace Tegu.Net.Client.Maui.Pages;

public partial class MVVMTwoPage : ContentPage
{
	public MVVMTwoPage(MVVMTwoVM vm)
	{
		InitializeComponent();

        BindingContext = vm;
    }
}