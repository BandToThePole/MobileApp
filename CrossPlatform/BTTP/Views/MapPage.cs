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
            map.CustomPins = viewModel.Pins;
        }
    }
}

