using System;
using System.Collections.Generic;

namespace BTTP
{
    public class CalorieStreamViewModel : StreamViewModel
    {
        private List<Entry> entries;

        public CalorieStreamViewModel() 
        {
            this.Title = "Calories";
        }

        public override void UpdateModel(AllData data)
        {
            base.UpdateModel(data);

            List<ItemViewModel> items = new List<ItemViewModel>();
            entries = new List<Entry>();

            foreach (var kcal in data.Calories)
            {
                items.Add(new ItemViewModel(){ Title = $"{kcal.Count} calories", Description = kcal.Time.ToShortDateString() });
                entries.Add(new Entry(kcal.Count, kcal.Time));
            }

            this.Items = items;
        }

        public List<Entry> GetEntries()
        {
            return entries;
        }
    }
}
