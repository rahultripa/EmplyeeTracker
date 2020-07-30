using System;
using System.Collections.Generic;
using TrackEmployees.ViewModels;
using Xamarin.Forms;

namespace TrackEmployees.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            LoginViewModel loginViewModel = new LoginViewModel(this);
            this.BindingContext = loginViewModel;
        }
    }
}
