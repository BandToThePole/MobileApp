using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BTTP
{
    public class DonatePage : ContentPage
    {
        public DonatePage()
        {
            this.Title = "Donate";

            Content = new StackLayout
            {
                Children = {
                    new WebView()
                    {
                        Source = "http://uk.virginmoneygiving.com/JamesRedden",
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    }
                }
            };
        }
    }
}
