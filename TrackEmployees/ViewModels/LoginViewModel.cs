using System;
using TrackEmployees.helper;
using TrackEmployees.Model;
using TrackEmployees.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TrackEmployees.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(Page page)
        {

            navigation = page.Navigation;
            _page = page; 
            Employees = new Employees();

            Employees.FirstName = "Test";
            Employees.LastName = "Test";
            Employees.RePassword = "Test";
            Employees.Phone = "Test";
        }
        private Page _page;
        public Command LoginCommand
        {
            get
            {
                return new Command(async() =>
                {
                    if (!ValidationHelper.IsFormValid(Employees, _page)) { return; }
                    IsBusy = true;
                    var services = new TrackEmployees.Services.Services();
                    var emp =await services.LoginInfo(Employees);
                    if(emp.EmailID!=null)
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

                        //var request = new GeolocationRequest(GeolocationAccuracy.Best);
                        //var location = await Geolocation.GetLocationAsync(request);
                        //if (location != null)
                        //{
                        //    Employees.Latitude = location.Latitude.ToString();
                        //    Employees.Longitude = location.Longitude.ToString();

                        //}
                     //   App.CurrentEmployees = emp;
                        //var status = await services.UpdateLatLong(Employees);
                        //if (status)
                        {
                            navigation.PushAsync(new SettingPage());
                        }
                    }
                    else
                    {
                        Errorcolor = Color.Red;
                        StatusMassege = " Invalid User or Password ";
                    }
                    IsBusy = false;

                });
            }
        }

        public Command RegistrationCommand
        {
            get
            {
                return new Command(() =>
                {
                    navigation.PushAsync(new RegistrationPage());

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
