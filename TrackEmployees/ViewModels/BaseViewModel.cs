using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TrackEmployees.RestClient;
using Xamarin.Forms;

namespace TrackEmployees.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public INavigation navigation { get; set; }
        private ServerResponse serverResponse;
        public ServerResponse ServerResponse
        {
            get
            {
                return serverResponse;
            }

            set
            {
                serverResponse = value;
                OnPropertyChanged();
            }
        }

        private string statusMassege;
        public string StatusMassege
        {
            get
            {
                return statusMassege;
            }

            set
            {
                statusMassege = value;
                OnPropertyChanged();
            }
        }

        private Color errorcolor;
        public Color Errorcolor
        {
            get
            {
                return errorcolor;
            }

            set
            {
                errorcolor = value;
                OnPropertyChanged();
            }
        }


        private bool isBusy;

        public bool IsBusy
        {
            get
            {
                return isBusy;
            }

            set
            {
                isBusy = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string caller = null)
        {
            // make sure only to call this if the value actually changes

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
