using System;
using System.Threading.Tasks;
using BTTP.Views;
using Xamarin.Forms;

namespace BTTP
{
    public partial class App : Application
    {
        public static RestService RestService { get; private set; }

        public App()
        {
            InitializeComponent();
            RestService = new RestService();
            GoToMainPage();
        }

        public static void GoToMainPage()
        {
            Task.Factory.StartNew(RestService.RefreshAndNotifyAsync);
            Current.MainPage = new TabbedPage
            {
                Children = {
                    new NavigationPage(new DataPage())
                    {
                        Title = "Data"
                    },
                    new NavigationPage(new GraphsPage())
                    {
                      Title  =  "Graphs"
                    },
					new NavigationPage(new MapPage())
					{
						Title = "Map",
						Icon = Device.OnPlatform("tab_feed.png", null, null)
					},
                    new NavigationPage(new DonatePage())
                    {
                        Title = "Donate",
                        Icon = Device.OnPlatform("tab_feed.png", null, null)
                    },
                    new NavigationPage(new TwitterPage())
                    {
                        Title = "Twitter",
                        Icon = Device.OnPlatform("tab_feed.png", null, null)
                    }
				}
            };
        }
    }
}
