using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace BTTP
{
    public abstract class StreamViewModel : ObservableObject
    {
        public string Title { get; protected set; }

        private List<ItemViewModel> items;
        public List<ItemViewModel> Items
        {
            get { return items; }
            protected set { SetProperty(ref items, value, "Items"); }
        }

        public bool IsBusy { get; set; }

        public virtual void UpdateModel(AllData data)
        {
            // Implemented by subclasses
        }
    }
}
