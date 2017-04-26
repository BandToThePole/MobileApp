using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace BTTP
{
    public abstract class StreamViewModel : INotifyPropertyChanged
    {
        public string Title { get; protected set; }

        private List<ItemViewModel> items;
        public List<ItemViewModel> Items
        {
            get
            {
                return items;
            }

            protected set
            {
                items = value;
                OnPropertyChanged("Items");
            }
        }

        public bool IsBusy { get; set; }

        public virtual void UpdateModel(AllData data)
        {
            Debug.WriteLine("Update model");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
