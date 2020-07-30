using System;
using TrackEmployees.Model;
using TrackEmployees.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrackEmployees
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (Application.Current.Properties.Count == 0 || Application.Current.Properties["EmailID"] == null)
                MainPage = new NavigationPage(new LoginPage());
            else
            {


                MainPage = new NavigationPage(new SettingPage());
            }
        }
       // public static Employees CurrentEmployees;
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
