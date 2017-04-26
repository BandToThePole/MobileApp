using System;
using System.Collections.Generic;

namespace BTTP
{
    public class DistancesStreamViewModel : StreamViewModel
    {
        public DistancesStreamViewModel()
        {
            this.Title = "Distances";
        }

        public override void UpdateModel(AllData data)
        {
            base.UpdateModel(data);
            List<ItemViewModel> items = new List<ItemViewModel>();
            foreach (var dist in data.Distances)
            {
                items.Add(new ItemViewModel() { Title = $"{dist.DistanceCM}", Description = dist.Time.ToString() });
            }
            this.Items = items;
        }
    }
}
