namespace RESTDemo;

public partial class ApiPage : ContentPage
{

	public ApiPage()
	{
		InitializeComponent();

		BindingContext = new MainViewModel();
	}
}

