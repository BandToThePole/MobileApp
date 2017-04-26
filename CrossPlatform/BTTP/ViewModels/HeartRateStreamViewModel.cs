using System;
using System.Collections.Generic;

namespace BTTP
{
	public class HeartRateStreamViewModel : StreamViewModel
	{
		public HeartRateStreamViewModel()
		{
			this.Title = "Heart Rate";
		}

		public override void UpdateModel(AllData data)
		{
			base.UpdateModel(data);
			List<ItemViewModel> items = new List<ItemViewModel>();
            foreach (var bpm in data.HeartRates)
			{
                items.Add(new ItemViewModel() { Title = $"${bpm.BeatsPerMinute} bpm", Description = bpm.Time.ToString() });
			}
			this.Items = items;
		}
	}
}
