using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BTTP
{
    public class CustomMap : Map
    {
        private List<Pin> customPins;
        public List<Pin> CustomPins
        {
            get { return customPins; }
            set
            {
                customPins = value;
                if (customPins != null)
                {
					Pins.Clear();
					if (customPins != null)
					{
						foreach (var customPin in customPins)
						{
							Pins.Add(customPin);
						}
					}
					if (customPins.Count > 0)
					{
						MoveToRegion(MapSpan.FromCenterAndRadius(customPins[customPins.Count - 1].Position, Xamarin.Forms.Maps.Distance.FromKilometers(1)));
					}
                }
            }
        }

        public CustomMap()
        {
        }
    }
}
