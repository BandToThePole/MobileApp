using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BTTP
{
    public class DataPage : ContentPage
    {
        public DataPage()
        {
            var caloriesButton = new Button()
            {
                Text = "Calories"
            };

            var distancesButton = new Button()
            {
                Text = "Distances"
            };

            var heartButton = new Button()
            {
                Text = "Hear rate"
            };

            caloriesButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new NavigationPage(new ItemsPage(new CalorieStreamViewModel()))
                {
                    Title = "Calories",
                    Icon = Device.OnPlatform("tab_feed.png", null, null)
                });
            };

            distancesButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new NavigationPage(new ItemsPage(new DistancesStreamViewModel()))
                {
                    Title = "Distances",
                    Icon = Device.OnPlatform("tab_feed.png", null, null)
                });
            };

            heartButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new NavigationPage(new ItemsPage(new HeartRateStreamViewModel()))
                {
                    Title = "Heart rate",
                    Icon = Device.OnPlatform("tab_feed.png", null, null)
                });
            };

            Content = new StackLayout
            {
                Children = {caloriesButton, distancesButton, heartButton, }
            };
        }
    }
}
