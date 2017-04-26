using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BTTP
{
    public class MapViewModel : ObservableObject
    {
        private List<Pin> pins;
        public List<Pin> Pins
        {
            get { return pins; }
            set { SetProperty(ref pins, value, "Pins"); }
        }

        public MapViewModel()
        {
            MessagingCenter.Subscribe<AllData>(this, Constants.NewDataMessage, (obj) => UpdateModel(obj));
            if (App.RestService.LastData != null)
            {
                UpdateModel(App.RestService.LastData);
            }
        }

        private void UpdateModel(AllData data)
        {
            var ps = new List<Pin>();
            foreach (var loc in data.Locations)
            {
                ps.Add(new Pin()
                {
                    Type = PinType.Place,
                    Position = new Position(loc.Latitude, loc.Longitude),
                    Label = loc.Time.ToString()
                });
            }
            Pins = ps;
        }
    }
}
