using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BTTP
{
    public class CustomMap : Map
    {
        private List<CustomPin> customPins;
        public List<CustomPin> CustomPins
        {
            get { return customPins; }
            set
            {
                customPins = value;
                Pins.Clear();
                if (customPins != null)
                {
                    foreach (var customPin in customPins)
                    {
                        Pins.Add(customPin.Pin);
                    }
                }                
            }
        }

        public CustomMap()
        {
        }
    }
}
