using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BandToThePole
{
    [Activity(Label = "Details")]
    public class DetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Details);
            ActionBar.Hide();
            // Get our UI controls from the loaded layout
            TextView heartRateText = FindViewById<TextView>(Resource.Id.heartRate);
            TextView caloriesText = FindViewById<TextView>(Resource.Id.calories);
            TextView distanceText = FindViewById<TextView>(Resource.Id.distance);
            bool isTotal = Intent.GetBooleanExtra("isTotal", true);
            // Display the data for a specific date
            if (!isTotal)
            {
                // Get the strings from MainActivity
                string day = Intent.GetStringExtra("day") ?? "Data not available";
                string month = Intent.GetStringExtra("month") ?? "Data not available";
                string year = Intent.GetStringExtra("year") ?? "Data not available";
                // Set the data
                heartRateText.SetText(day, TextView.BufferType.Normal);
                caloriesText.SetText(month, TextView.BufferType.Normal);
                distanceText.SetText(year, TextView.BufferType.Normal);
            }
        }
    }
}