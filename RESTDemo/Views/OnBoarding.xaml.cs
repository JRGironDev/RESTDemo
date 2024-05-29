using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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