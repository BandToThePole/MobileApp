using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace BTTP
{
    public class TwitterPage : ContentPage
    {
        public TwitterPage()
        {
            this.Title = "Twitter";
            
            Content = new StackLayout
            {
                Children = {
                    new WebView()
                    {
                        Source = "https://twitter.com/jredden",
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand
                    }
                }
            };
        }
    }
}
