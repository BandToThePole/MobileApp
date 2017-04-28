using System;
using System.Collections.Generic;

namespace BTTP
{
    public class DistancesStreamViewModel : StreamViewModel
    {
        private List<Entry> entries;

        public DistancesStreamViewModel()
        {
            this.Title = "Distances";
        }

        public override void UpdateModel(AllData data)
        {
            base.UpdateModel(data);

            List<ItemViewModel> items = new List<ItemViewModel>();
            entries = new List<Entry>();

            foreach (var dist in data.Distances)
            {
                items.Add(new ItemViewModel() { Title = $"{dist.DistanceCM}", Description = dist.Time.ToShortDateString() });
                entries.Add(new Entry(dist.DistanceCM, dist.Time));
            }

            this.Items = items;
        }

        public List<Entry> GetEntries()
        {
            return entries;
        }
    }
}
