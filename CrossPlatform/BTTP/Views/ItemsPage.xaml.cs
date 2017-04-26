using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BTTP
{
    public partial class ItemsPage : ContentPage
    {
        StreamViewModel viewModel;

        public ItemsPage(StreamViewModel svm)
        {
            InitializeComponent();
            BindingContext = viewModel = svm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            AllData allData = await App.RestService.RefreshDataAsync();
            viewModel.UpdateModel(allData);
        }
    }
}
