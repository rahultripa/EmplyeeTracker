using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace TrackEmployees.Controls
{


    public class CustomMap : Map
    {

        public CustomMap() 
        {

        }
        public   CustomMap(MapSpan mapSpan)  : base(mapSpan)
            {
           
        }
        public List<CustomPin> CustomPins { get; set; }
    }
    public class CustomPin : Pin
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
