using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BTTP
{
    public partial class ItemsPage : ContentPage
    {
        public ItemsPage(StreamViewModel svm)
        {
            InitializeComponent();
            BindingContext = svm;
        }
    }
}
