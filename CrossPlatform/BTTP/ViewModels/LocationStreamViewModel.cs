using System;
using System.Collections.Generic;

namespace BTTP
{
	public class LocationStreamViewModel : StreamViewModel
	{
        public LocationStreamViewModel()
		{
			this.Title = "Locations";
		}

		public override void UpdateModel(AllData data)
		{
			base.UpdateModel(data);
			List<ItemViewModel> items = new List<ItemViewModel>();
            foreach (var loc in data.Locations)
			{
                items.Add(new ItemViewModel() { Title = $"{loc.Longitude}, {loc.Latitude}", Description = loc.Time.ToString() });
			}
			this.Items = items;
		}
	}
}
