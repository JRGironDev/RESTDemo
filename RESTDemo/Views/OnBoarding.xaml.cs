using RESTDemo.ViewModels;

namespace RESTDemo.Views;

public partial class OnBoarding
{
    public OnBoarding()
    {
        InitializeComponent();

        BindingContext = new OnBoardingViewModel();
    }
}