using System;
using TrackEmployees.Model;
using TrackEmployees.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TrackEmployees.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {
        public SettingViewModel(Page page)
        {

            navigation = page.Navigation;
            _page = page;
            Employees = new Employees();


            Employees.EmailID= (string )Application.Current.Properties["EmailID"] ;
            Employees.FirstName = (string)Application.Current.Properties["FirstName"];
            Employees.LastName = (string)Application.Current.Properties["LastName"];
            Employees.Phone = (string)Application.Current.Properties["Phone"] ;
            Employees.IsEmp1 = (bool)Application.Current.Properties["IsEmp1"] ;
            Employees.IsEmp2 = (bool) Application.Current.Properties["IsEmp2"];
            Employees.IsSupport = (bool)Application.Current.Properties["IsSupport"] ;
         
        }
        private Page _page;
        private Employees _employees;
        public Employees Employees
        {
            get
            {
                return _employees;
            }

            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        public Command HomeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    var services = new TrackEmployees.Services.Services();


                    var request = new GeolocationRequest(GeolocationAccuracy.Best);
                    var location = await Geolocation.GetLocationAsync(request);
                    if (location != null)
                    {
                        Employees.Latitude = location.Latitude.ToString();
                        Employees.Longitude = location.Longitude.ToString();
                        Application.Current.Properties["IsEmp1"] = Employees.IsEmp1;
                        Application.Current.Properties["IsEmp2"] = Employees.IsEmp2;
                        Application.Current.Properties["IsSupport"] = Employees.IsSupport;
                        Application.Current.Properties["Latitude"] = Employees.Latitude;
                        Application.Current.Properties["Longitude"] = Employees.Longitude;
                        Application.Current.SavePropertiesAsync();

                    }
                    var status = await services.UpdateLatLong(Employees);
                    if (status)
                    {
                         await   navigation.PushAsync(new HomePage());
                    }
                   
                    else
                    {
                        Errorcolor = Color.Red;
                        StatusMassege = "Please try after sometime ";
                    }
                    IsBusy = false;

                });
            }
        }

    }
}

