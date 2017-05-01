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
            this.Title = "Data";

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
                Text = "Heart rate"
            };

            caloriesButton.Clicked += async (sender, args) =>
            {
                var itemsPage = new ItemsPage(new CalorieStreamViewModel());
                itemsPage.Appearing += (sender1, args1) => NavigationPage.SetHasNavigationBar(itemsPage, false);

                var navPage = new NavigationPage(itemsPage)
                {
                    Title = "Calories",
                    Icon = Device.OnPlatform("tab_feed.png", null, null)
                };

                navPage.Appearing += (sender1, args1) => NavigationPage.SetHasBackButton(navPage, true);

                await Navigation.PushAsync(navPage);
            };

            distancesButton.Clicked += async (sender, args) =>
            {
                var itemsPage = new ItemsPage(new DistancesStreamViewModel());
                itemsPage.Appearing += (sender1, args1) => NavigationPage.SetHasNavigationBar(itemsPage, false);

                var navPage = new NavigationPage(itemsPage)
                {
                    Title = "Distances",
                    Icon = Device.OnPlatform("tab_feed.png", null, null)
                };

                navPage.Appearing += (sender1, args1) => NavigationPage.SetHasBackButton(navPage, true);

                await Navigation.PushAsync(navPage);
            };

            heartButton.Clicked += async (sender, args) =>
            {
                var itemsPage = new ItemsPage(new HeartRateStreamViewModel());
                itemsPage.Appearing += (sender1, args1) => NavigationPage.SetHasNavigationBar(itemsPage, false);

                var navPage = new NavigationPage(itemsPage)
                {
                    Title = "Heart rate",
                    Icon = Device.OnPlatform("tab_feed.png", null, null)
                };

                navPage.Appearing += (sender1, args1) => NavigationPage.SetHasBackButton(navPage, true);

                await Navigation.PushAsync(navPage);
            };

            Content = new StackLayout
            {
                Children = { heartButton, caloriesButton, distancesButton }
            };
        }
    }
}
