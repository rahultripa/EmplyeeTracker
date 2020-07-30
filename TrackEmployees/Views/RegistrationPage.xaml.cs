using System;
using System.Collections.Generic;
using TrackEmployees.ViewModels;
using Xamarin.Forms;

namespace TrackEmployees.Views
{
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();

            RegistrationViewModel registerViewModel = new RegistrationViewModel(this);
            this.BindingContext = registerViewModel;
        }
    }
}
