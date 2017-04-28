using System;
using System.Collections.Generic;
using System.Text;
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

        private PlotModel CaloriesCreatePlotModel()
        {
            CalorieStreamViewModel calorieStream = new CalorieStreamViewModel();
            var plotModel = new PlotModel();

            plotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "yyyy-MM-dd"
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Maximum = 10000,
                Minimum = 0,
                Title = "Calories (kcal)"
            });

            var series1 = new ScatterSeries()
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            foreach(var entry in calorieStream.GetEntries())
            {
                series1.Points.Add(new ScatterPoint(DateTimeAxis.ToDouble(entry.date), entry.value));
            }

            plotModel.Series.Add(series1);

            return plotModel;
        }

        private PlotModel HeartRateCreatePlotModel()
        {
            HeartRateStreamViewModel heartRateStream = new HeartRateStreamViewModel();
            var plotModel = new PlotModel();

            plotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "yyyy-MM-dd"
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Maximum = 200,
                Minimum = 0,
                Title = "BPM"
            });

            var series1 = new ScatterSeries()
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            foreach (var entry in heartRateStream.GetEntries())
            {
                series1.Points.Add(new ScatterPoint(DateTimeAxis.ToDouble(entry.date), entry.value));
            }

            plotModel.Series.Add(series1);

            return plotModel;
        }

        private PlotModel DistancesCreatePlotModel()
        {
            DistancesStreamViewModel distancesStream = new DistancesStreamViewModel();
            var plotModel = new PlotModel();

            plotModel.Axes.Add(new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "yyyy-MM-dd"
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Distance"
            });

            var series1 = new ScatterSeries()
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            foreach (var entry in distancesStream.GetEntries())
            {
                series1.Points.Add(new ScatterPoint(DateTimeAxis.ToDouble(entry.date), entry.value));
            }

            plotModel.Series.Add(series1);

            return plotModel;
        }
    }
}
