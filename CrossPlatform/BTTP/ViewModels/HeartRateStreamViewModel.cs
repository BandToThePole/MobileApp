using System;
using System.Collections.Generic;

namespace BTTP
{
	public class HeartRateStreamViewModel : StreamViewModel
	{
        private List<Entry> entries;

        public HeartRateStreamViewModel()
		{
			this.Title = "Heart Rate";
		}

		public override void UpdateModel(AllData data)
		{
			base.UpdateModel(data);

			List<ItemViewModel> items = new List<ItemViewModel>();
            entries = new List<Entry>();

            foreach (var bpm in data.HeartRates)
			{
                items.Add(new ItemViewModel() { Title = $"{bpm.BeatsPerMinute} bpm", Description = bpm.Time.ToString() });
                entries.Add(new Entry(bpm.BeatsPerMinute, bpm.Time));
            }

			this.Items = items;
		}

        public List<Entry> GetEntries()
        {
            return entries;
        }
    }
}
