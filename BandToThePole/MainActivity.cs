using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace BandToThePole
{
    [Activity(Label = "BandToThePole", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        // The date we are interested in
        string day = "1";
        string month = "1";
        string year = "1970";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            ActionBar.Hide();

            // Get the date from the calendar
            var calendar = FindViewById<CalendarView>(Resource.Id.calendar);
            calendar.DateChange += calendarDateChange;
            // Get our UI controls from the loaded layout
            Button dateButton = FindViewById<Button>(Resource.Id.DateButton);
            Button totalButton = FindViewById<Button>(Resource.Id.TotalButton);
            // Data for the selected date
            dateButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(DetailsActivity));
                //send the date data
                intent.PutExtra("isTotal", false);
                intent.PutExtra("day", day);
                intent.PutExtra("month", month);
                intent.PutExtra("year", year);
                StartActivity(intent);
            };
            // Total data
            totalButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(DetailsActivity));
                //the total data
                intent.PutExtra("isTotal", true);
                StartActivity(intent);
            };
        }
        // Notes a change in the calendar
        void calendarDateChange(object sender, CalendarView.DateChangeEventArgs e)
        {
            // set the selected date
            day = e.DayOfMonth.ToString();
            month = (e.Month + 1).ToString();
            year = e.Year.ToString();
        }
    }
}

