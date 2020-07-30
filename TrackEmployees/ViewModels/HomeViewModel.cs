using System;
using System.Collections.Generic;
using TrackEmployees.Model;
using TrackEmployees.Services;
using Xamarin.Forms;

namespace TrackEmployees.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private Page _page;

        public HomeViewModel(Page page)
        {

            navigation = page.Navigation;
            _page = page;
            getData();
        }
            


        public async void getData()
        {
            IsBusy = true;
            // App.steps += " Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss") + "Funcation   : getData \r \n ";
            var services = new TrackEmployees.Services.Services();

            Employees = await services.GetEmployee();
            IsBusy = false;

        }




        public Command RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    getData();
                });
            }
        }
        private List<Employees> _employees;
        public List<Employees> Employees
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
