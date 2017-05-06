using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;

namespace BTTP
{
    public abstract class StreamViewModelDC : ObservableObject
    {
        public static readonly CultureInfo Culture = new CultureInfo("en-GB");

        protected List<DCEntry> Entries;

        public string Title { get; protected set; }
        public Command LoadItemsCommand { get; set; }

        public StreamViewModelDC()
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

        public List<DCEntry> GetEntries()
        {
            return Entries;
        }
    }
}
