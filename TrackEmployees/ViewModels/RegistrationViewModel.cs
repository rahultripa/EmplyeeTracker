using System;
using TrackEmployees.helper;
using TrackEmployees.Model;
using TrackEmployees.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TrackEmployees.ViewModels
{
    public class RegistrationViewModel : BaseViewModel
    {
        public RegistrationViewModel(Page page)
        {

            navigation = page.Navigation;
            _page = page;
            Employees = new Employees();
        }
        private Page _page;
        public Command RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                   
                    if (!ValidationHelper.IsFormValid(Employees, _page)) { return; }
                     IsBusy = true;
                    Employees.IsEmp1 = false;
                    Employees.IsEmp2 = false;
                    Employees.IsSupport = false;

                    var services = new TrackEmployees.Services.Services();
                    var request = new GeolocationRequest(GeolocationAccuracy.Best);
                    var location = await Geolocation.GetLocationAsync(request);
                    if(location!=null)
                    {
                        Employees.Latitude = location.Latitude.ToString();
                        Employees.Longitude = location.Longitude.ToString();

                    }

                    var emp = await services.Register(Employees);
                    if (emp.EmailID != null)
                    {
                        Application.Current.Properties["EmailID"] = emp.EmailID;
                        Application.Current.Properties["FirstName"] = emp.FirstName;
                        Application.Current.Properties["LastName"] = emp.LastName;
                        Application.Current.Properties["Phone"] = emp.Phone;
                        Application.Current.Properties["IsEmp1"] = emp.IsEmp1;
                        Application.Current.Properties["IsEmp2"] = emp.IsEmp2;
                        Application.Current.Properties["IsSupport"] = emp.IsSupport;
                        Application.Current.Properties["Latitude"] = emp.Latitude;
                        Application.Current.Properties["Longitude"] = emp.Longitude;
                        Application.Current.SavePropertiesAsync();
                        Errorcolor = Color.Green;
                        StatusMassege = " Successfully Register ...";
                        navigation.PushAsync(new SettingPage(true));

                    }
                    else
                    {
                        Errorcolor = Color.Red;
                        StatusMassege = " Employee Already Exist ....";
                    }
                    IsBusy = false;
                });
            }
        }

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
    }
}
