using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.Linq;
using TrackEmployees.Model;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace TrackEmployees.Behavior
{
	public class MapBehavior : BindableBehavior<Xamarin.Forms.Maps.Map>
	{
		private Xamarin.Forms.Maps.Map _map;

		public static readonly BindableProperty ItemsSourceProperty =
			BindableProperty.CreateAttached("ItemsSource", typeof(IEnumerable<Employees>), typeof(MapBehavior),
				default(IEnumerable<Employees>), BindingMode.Default, null, OnItemsSourceChanged);

		public IEnumerable<Employees> ItemsSource
		{
			get { return (IEnumerable<Employees>)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		private static void OnItemsSourceChanged(BindableObject view, object oldValue, object newValue)
		{
			var mapBehavior = view as MapBehavior;

			if (mapBehavior != null)
			{
				mapBehavior.AddPins();
				mapBehavior.PositionMap();
			}
		}

		protected override void OnAttachedTo(Xamarin.Forms.Maps.Map bindable)
		{
			base.OnAttachedTo(bindable);

			_map = bindable;
		}

		protected override void OnDetachingFrom(Xamarin.Forms.Maps.Map bindable)
		{
			base.OnDetachingFrom(bindable);

			_map = null;
		}


		private string pintZType(Employees emp)
        {

			if (emp.EmailID == Application.Current.Properties["EmailID"].ToString())
			{
				return "SearchResult";


			}
			else
			{
				if (emp.IsEmp1)
					return "Generic";
				else if (emp.IsEmp2)
					return "Place";
				else
					return "SavedPin";
			}


        }

		private async Task<string>  getAddress(Employees employees)
        {


			var placemarks = await Geocoding.GetPlacemarksAsync(double.Parse(employees.Latitude), double.Parse(employees.Longitude));

			var placemark = placemarks?.FirstOrDefault();
			if(placemark!=null)
            {
				return placemark.AdminArea + "  " + placemark.Locality + " " + placemark.SubLocality;
            }
			return "";
		}
		private void AddPins()
		{
			for (int i = _map.Pins.Count - 1; i >= 0; i--)
			{
				_map.Pins.RemoveAt(i);
			}

			var pins = ItemsSource.Select( x =>
			{
				var pin = new Pin
				{
					Type = PinType.Place//pintZType(x)






					   ,
					Address = pintZType(x).ToString()
					,
					
					Position = new Position(double.Parse( x.Latitude),double.Parse( x.Longitude)),
					Label = string.Format("{0} {1}  Phone : {2}", x.FirstName, x.LastName,x.Phone)
				};

				return pin;
			}).ToArray();

			foreach (var pin in pins)
			{
				

					_map.Pins.Add(pin);
			}
		}

		private void PositionMap()
		{
			if (ItemsSource == null || !ItemsSource.Any()) return;

			var centerPosition = new Position(double.Parse(Application.Current.Properties["Latitude"].ToString()), double.Parse(Application.Current.Properties["Longitude"].ToString()));

			var distance = 1;

			_map.MoveToRegion(MapSpan.FromCenterAndRadius(centerPosition, Distance.FromMiles(distance)));

			Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
			{
				_map.MoveToRegion(MapSpan.FromCenterAndRadius(centerPosition, Distance.FromMiles(distance)));
				return false;
			});
		}
	}
}
