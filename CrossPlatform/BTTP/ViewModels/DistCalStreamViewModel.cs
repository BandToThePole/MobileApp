using System;
using System.Collections.Generic;

namespace BTTP
{
    public class DistCalStreamViewModel : StreamViewModelDC
    {
        public DistCalStreamViewModel()
        {
            this.Title = "Distances/Calories";
        }

        public override void UpdateModel(AllData data)
        {
            base.UpdateModel(data);

            List<ItemViewModel> items = new List<ItemViewModel>();
            Entries = new List<DCEntry>();

            //foreach (var kcal in data.Calories)
            for (int i = 0; i < data.Calories.Count; i++)
                {
                items.Add(new ItemViewModel()
                {
                    Title = $"{data.Calories[i].Count} calories",
                    Description = $"{data.Distances[i].DistanceCM/100.0} m"
                });
                Entries.Add(new DCEntry(data.Calories[i].Count, data.Distances[i].DistanceCM));
            }

            this.Items = items;
        }
    }
}
