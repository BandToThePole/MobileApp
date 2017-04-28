using System;
using System.Collections.Generic;
using System.Globalization;

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
            Entries = new List<Entry>();

            foreach (var bpm in data.HeartRates)
			{
                items.Add(new ItemViewModel() { Title = $"{bpm.BeatsPerMinute} bpm", Description = bpm.Time.ToString(StreamViewModel.DATE_FORMAT,
                                                                                                                     StreamViewModel.Culture)
                });
                Entries.Add(new Entry(bpm.BeatsPerMinute, bpm.Time));
            }

			this.Items = items;
		}
    }
}
