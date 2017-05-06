using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Xamarin.Forms;
using Xamarin.Forms;

namespace BTTP.Views
{
    public class GraphsPage : ContentPage
    {
        public GraphsPage()
        {
            this.Title = "Graphs";

            var caloriesButton = new Button()
            {
                Text = "Calories graph"
            };

            var heartButton = new Button()
            {
                Text = "Heart rate graph"
            };

            var distancesButton = new Button()
            {
                Text = "Distances graph"
            };

            var distCalButton = new Button()
            {
                Text = "Calories/Distance graph"
            };

            caloriesButton.Clicked += async (sender, args) =>
            {
                var navPage = new NavigationPage(CreateContentPage("Calories graph", CaloriesCreatePlotModel()))
                {
                    Title = "Calories graph"
                };

                navPage.Appearing += (sender1, args1) => NavigationPage.SetHasBackButton(navPage, true);
                await Navigation.PushAsync(navPage);
            };

            heartButton.Clicked += async (sender, args) =>
            {
                var navPage = new NavigationPage(CreateContentPage("Heart rate graph", HeartRateCreatePlotModel()))
                {
                    Title = "Heart rate graph"
                };

                navPage.Appearing += (sender1, args1) => NavigationPage.SetHasBackButton(navPage, true);
                await Navigation.PushAsync(navPage);
            };

            distancesButton.Clicked += async (sender, args) =>
            {
                var navPage = new NavigationPage(CreateContentPage("Distances graph", DistancesCreatePlotModel()))
                {
                    Title = "Distances graph",
                };

                navPage.Appearing += (sender1, args1) => NavigationPage.SetHasBackButton(navPage, true);
                await Navigation.PushAsync(navPage);
            };

            distCalButton.Clicked += async (sender, args) =>
            {
                var navPage = new NavigationPage(CreateContentPage("Calories/Distance graph", DistCalCreatePlotModel()))
                {
                    Title = "Calories/Distance graph"
                };

                navPage.Appearing += (sender1, args1) => NavigationPage.SetHasBackButton(navPage, true);
                await Navigation.PushAsync(navPage);
            };

            Content = new StackLayout
            {
                Children = { heartButton, caloriesButton, distancesButton, distCalButton }
            };
        }

        private static ContentPage CreateContentPage(string title, PlotModel model)
        {
            var page = new ContentPage()
            {
                Title = title,

                Content = new PlotView()
                {
                    Model = model,
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.Fill
                },
            };

            page.Appearing += (sender, args) => NavigationPage.SetHasNavigationBar(page, false);
   
            return page;
        }

        private const string DATE_FORMAT = "dd-MMM";
        private static readonly CultureInfo Culture = new CultureInfo("en-GB");

        private PlotModel genericColumnPlotModel(StreamViewModel viewModel, string yAxisTtitle, double scale = 1)
        {
            var plotModel = new PlotModel();

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = yAxisTtitle,
                MaximumPadding = 0.05
            });

            var series = new ColumnSeries()
            {
                Background = OxyColor.FromRgb(33, 150, 243), // blue
                FillColor = OxyColor.FromRgb(255, 165, 0)     // orange
            };

            List<Entry> entries = viewModel.GetEntries();
            CategoryAxis categoryAxis = new CategoryAxis()
            {
                Position = AxisPosition.Bottom,
                StringFormat = DATE_FORMAT,
                Title = "Date",
                MinimumPadding = 0.05,
                MaximumPadding = 0.05
            };

            if (entries != null)
            {
                foreach (var entry in entries)
                {
                    series.Items.Add(new ColumnItem((int)(entry.value / scale)));
                    categoryAxis.Labels.Add(entry.date.ToString(DATE_FORMAT, Culture));
                }
            }

            plotModel.Axes.Add(categoryAxis);
            plotModel.Series.Add(series);

            return plotModel;
        }

        private PlotModel CaloriesCreatePlotModel()
        {
            return genericColumnPlotModel(new CalorieStreamViewModel(), "Calories (kcal)");
        }

        private PlotModel DistancesCreatePlotModel()
        {
            return genericColumnPlotModel(new DistancesStreamViewModel(), "Distance (m)", 100.0);
        }

        private PlotModel HeartRateCreatePlotModel()
        {
            HeartRateStreamViewModel heartRateStream = new HeartRateStreamViewModel();
            var plotModel = new PlotModel();

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "BPM",
                MaximumPadding = 0.05
            });

            var dateTimeAxis = new DateTimeAxis()
            {
                Position = AxisPosition.Bottom,
                Title = "Date",
                StringFormat = DATE_FORMAT,
                MinimumPadding = 0.05,
                MaximumPadding = 0.05
            };

            plotModel.Axes.Add(dateTimeAxis);

            var series = new ScatterSeries()
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColor.FromRgb(0, 0, 139),    // darkblue
                MarkerFill = OxyColor.FromRgb(255, 165, 0),    // orange
                Background = OxyColor.FromRgb(33, 150, 243),   // blue
            };

            List<Entry> entries = heartRateStream.GetEntries();

            if (entries != null)
            {
                foreach (var entry in entries)
                {
                    series.Points.Add(new ScatterPoint(DateTimeAxis.ToDouble(entry.date), entry.value));
                }
            }

            plotModel.Series.Add(series);

            return plotModel;
        }
        private PlotModel DistCalCreatePlotModel()
        {
            DistCalStreamViewModel distCalStream = new DistCalStreamViewModel();
            var plotModel = new PlotModel();

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Calories",
                MaximumPadding = 0.05
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Distance",
                MaximumPadding = 0.05
            });

            var series = new ScatterSeries()
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColor.FromRgb(0, 0, 139),    // darkblue
                MarkerFill = OxyColor.FromRgb(255, 165, 0),    // orange
                Background = OxyColor.FromRgb(33, 150, 243),   // blue
            };

            List<DCEntry> entries = distCalStream.GetEntries();

            if (entries != null)
            {
                foreach (var entry in entries)
                {
                    series.Points.Add(new ScatterPoint(entry.dist/100.0, entry.cal));
                }
            }

            plotModel.Series.Add(series);

            return plotModel;
        }
    }
}
