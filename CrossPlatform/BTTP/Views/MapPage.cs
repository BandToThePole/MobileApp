using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BTTP
{
    public class MapPage : ContentPage
    {
        private MapViewModel viewModel;
        private CustomMap map;

        public MapPage()
        {
            this.Title = "Map";
            this.map = new CustomMap
            {
                MapType = MapType.Street
            };
            Content = new StackLayout
            {
                Children = {
                    map
                }
            };
            viewModel = new MapViewModel();
            viewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "Pins")
                {
                    UpdateMap();
                }
            };
            UpdateMap();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Resolves iOS bug
            UpdateMap();
        }

        private void UpdateMap()
        {
            if (viewModel.Pins != null)
            {
                map.CustomPins = viewModel.Pins;
                if (viewModel.Pins.Count > 0)
                {
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(viewModel.Pins[viewModel.Pins.Count - 1].Pin.Position, Xamarin.Forms.Maps.Distance.FromKilometers(1.0)));
                }
            }
        }
    }
}

