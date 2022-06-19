namespace Tegu.Net.Client.Maui.Pages;

public partial class MVVMOnePage : ContentPage
{
	public MVVMOnePage(MVVMOneVM vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}