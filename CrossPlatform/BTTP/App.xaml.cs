using System;
using Xamarin.Forms;

namespace BTTP
{
    public partial class App : Application
    {
        public static IRestService RestService { get; private set; }

        public App()
        {
            InitializeComponent();
            RestService = new RestService();
            GoToMainPage();
        }

        public static void GoToMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children = {
                    new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse",
                        Icon = Device.OnPlatform("tab_feed.png", null, null)
                    },
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform("tab_about.png", null, null)
                    },
                }
            };
        }
    }
}
