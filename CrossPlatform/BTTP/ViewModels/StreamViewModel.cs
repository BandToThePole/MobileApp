using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace BTTP
{
    public abstract class StreamViewModel : ObservableObject
    {
        public const string DATE_FORMAT = "dd-MMMM-yyyy";
        public static readonly CultureInfo Culture = new CultureInfo("en-GB");

        protected List<Entry> Entries;

        public string Title { get; protected set; }
        public Command LoadItemsCommand { get; set; }

        public StreamViewModel()
        {
            if (App.RestService.LastData != null)
            {
                UpdateModel(App.RestService.LastData);
            }
            MessagingCenter.Subscribe<AllData>(this, Constants.NewDataMessage, (obj) =>
            {
                IsBusy = false;
                UpdateModel(obj);
            });
            LoadItemsCommand = new Command(async () =>
            {
                IsBusy = true;
                await App.RestService.RefreshAndNotifyAsync();
            });
        }

        private List<ItemViewModel> items;
        public List<ItemViewModel> Items
        {
            get { return items; }
            protected set { SetProperty(ref items, value, "Items"); }
        }

        private bool isBusy = false;
        public bool IsBusy 
        { 
            get { return isBusy; } 
            set { SetProperty(ref isBusy, value, "IsBusy"); } 
        }

        public virtual void UpdateModel(AllData data)
        {
            // Implemented by subclasses
        }

        public List<Entry> GetEntries()
        {
            return Entries;
        }
    }
}
