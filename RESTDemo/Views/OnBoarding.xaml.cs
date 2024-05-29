using RESTDemo.ViewModels;

namespace RESTDemo.Views;

public partial class OnBoarding : ContentPage
{
    public OnBoarding()
    {
        InitializeComponent();

        BindingContext = new OnBoardingViewModel();
    }
}