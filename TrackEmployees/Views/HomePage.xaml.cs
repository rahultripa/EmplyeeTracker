using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TrackEmployees.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TrackEmployees.Views
{
    public partial class HomePage : ContentPage
    {
        ObservableCollection<string> data = new ObservableCollection<string>();
        public HomePage()
        {
            InitializeComponent();

            HomeViewModel homeViewModel = new HomeViewModel(this);
            this.BindingContext = homeViewModel;
           
          
        }
     
        async void OnSearchBarButtonPressed(object sender, EventArgs args)
        {
            try
            {
                //  searchResults.Text = searchBar.Text;
                var address = searchBar.Text;
                var locations = await Geocoding.GetLocationsAsync(address);

                var location = locations?.FirstOrDefault();

                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(10)));
            }
            catch
            {
                await DisplayAlert("Info", "Locaation not found", "OK");

            }

        }

      
    }
}
