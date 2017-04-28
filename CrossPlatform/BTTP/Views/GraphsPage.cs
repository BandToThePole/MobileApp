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

            caloriesButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new NavigationPage(CreateContentPage("Calories graph", CaloriesCreatePlotModel())));
            };

            heartButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new NavigationPage(CreateContentPage("Heart rate graph", HeartRateCreatePlotModel())));
            };

            distancesButton.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new NavigationPage(CreateContentPage("Distances graph", DistancesCreatePlotModel())));
            };

            Content = new StackLayout
            {
                Children = { caloriesButton, distancesButton, heartButton, }
            };
        }

        private static ContentPage CreateContentPage(String title, PlotModel model)
        {
            return new ContentPage()
            {
                Title = title,

                Content = new PlotView()
                {
                    Model = model,
                    VerticalOptions = LayoutOptions.Fill,
                    HorizontalOptions = LayoutOptions.Fill
                }
            };
        }

        private static String DATE_FORMAT = "dd-MMM";

        private PlotModel CaloriesCreatePlotModel()
        {
            CalorieStreamViewModel calorieStream = new CalorieStreamViewModel();
            var plotModel = new PlotModel();

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Calories (kcal)"
            });

            var series = new ColumnSeries()
            {
                Background = OxyColor.FromRgb(135, 206, 250), // blue
                FillColor = OxyColor.FromRgb(255, 165, 0)     // orange
            };

            List<Entry> entries = calorieStream.GetEntries();
            CategoryAxis categoryAxis = new CategoryAxis()
            {
                Position = AxisPosition.Bottom,
                StringFormat = DATE_FORMAT,
                Title = "Date"
            };

            CultureInfo culture = new CultureInfo("en-GB");

            if (entries != null)
            {
                foreach (var entry in entries)
                {
                    series.Items.Add(new ColumnItem(entry.value));
                    categoryAxis.Labels.Add(entry.date.ToString(DATE_FORMAT, culture));
                }
            }

            plotModel.Axes.Add(categoryAxis);
            plotModel.Series.Add(series);

            return plotModel;
        }

        private PlotModel HeartRateCreatePlotModel()
        {
            HeartRateStreamViewModel heartRateStream = new HeartRateStreamViewModel();
            var plotModel = new PlotModel();

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "BPM"
            });

            plotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Date",
                StringFormat = DATE_FORMAT,
            });

            var series = new ScatterSeries()
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColor.FromRgb(255, 165, 0),  // orange,
                MarkerFill = OxyColor.FromRgb(255, 165, 0),  // orange
                Background = OxyColor.FromRgb(135, 206, 250),  // blue
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

        private PlotModel DistancesCreatePlotModel()
        {
            DistancesStreamViewModel distancesStream = new DistancesStreamViewModel();
            var plotModel = new PlotModel();

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Distance (m)"
            });

            var series = new ColumnSeries()
            {
                Background = OxyColor.FromRgb(135, 206, 250), // blue
                FillColor = OxyColor.FromRgb(255, 165, 0)     // orange
            };

            List<Entry> entries = distancesStream.GetEntries();
            CategoryAxis categoryAxis = new CategoryAxis()
            {
                Position = AxisPosition.Bottom,
                StringFormat = DATE_FORMAT,
                Title = "Date"
            };

            CultureInfo culture = new CultureInfo("en-GB");

            if (entries != null)
            {
                foreach (var entry in entries)
                {
                    series.Items.Add(new ColumnItem((int)(entry.value / 1000.0)));
                    categoryAxis.Labels.Add(entry.date.ToString(DATE_FORMAT, culture));
                }
            }

            plotModel.Axes.Add(categoryAxis);
            plotModel.Series.Add(series);

            return plotModel;
        }
    }
}
