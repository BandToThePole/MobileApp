using System;
using System.Collections.Generic;

namespace BTTP
{
    public class CalorieStreamViewModel : StreamViewModel
    {
        public CalorieStreamViewModel() 
        {
            this.Title = "Calories";
        }

        public override void UpdateModel(AllData data)
        {
            base.UpdateModel(data);

            List<ItemViewModel> items = new List<ItemViewModel>();
            Entries = new List<Entry>();

            foreach (var kcal in data.Calories)
            {
                items.Add(new ItemViewModel(){ Title = $"{kcal.Count} calories", Description = kcal.Time.ToString(StreamViewModel.DATE_FORMAT, 
                                                                                                                  StreamViewModel.Culture)});
                Entries.Add(new Entry(kcal.Count, kcal.Time));
            }

            this.Items = items;
        }
    }
}
