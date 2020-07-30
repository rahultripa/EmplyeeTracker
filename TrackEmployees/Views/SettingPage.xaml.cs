using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrackEmployees.ViewModels;
using Xamarin.Forms;

namespace TrackEmployees.Views
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();

            //await DisplayAlert("Info", "Locaation not found", "OK");
           BackButtonPressed();


        }
        public SettingPage(bool tst)
        {
            InitializeComponent();
            SettingViewModel registerViewModel = new SettingViewModel(this);
            this.BindingContext = registerViewModel;
            grid.IsVisible = true;


        }
        public async Task BackButtonPressed()
        {
            var action = await DisplayAlert("Info", "Are you chang possition ", "Yes", "No");
            if (action)
            {
                grid.IsVisible = true;
                SettingViewModel registerViewModel = new SettingViewModel(this);
                this.BindingContext = registerViewModel;
                //  Navigate to first page
            }
            else
            {

                Navigation.PushAsync(new HomePage());
            }
        }
    }
}
