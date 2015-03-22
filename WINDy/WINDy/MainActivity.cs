using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Telephony;
using System.Collections.Generic;

namespace WINDy
{
    [Activity(Label = "WINDy", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyCustomTheme")]
    public class MainActivity : Activity
    {
        int count = 1;

        private TextView viewer;
        private Button calcButton;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);


            // Get our button from the layout resource,
            // and attach an event to it
            this.calcButton = FindViewById<Button>(Resource.Id.MyButton);

            this.viewer = FindViewById<TextView>(Resource.Id.textView1);

            this.calcButton.Click += delegate { this.calcButton.Text = "Calculating!"; GetNumSMS(); };
        }

        private void GetNumSMS()
        {
            viewer.Text = "Testing!";

            Android.Net.Uri uri = Android.Net.Uri.Parse("content://sms/inbox");

            var cursor = ManagedQuery(uri, null, null, null, null);

            var dateTimes = new List<DateTime>();

            var maybeDates = new List<string>();

            if (cursor.MoveToFirst())
            {
                for (int i = 0; i < cursor.Count; i++)
                {
                    maybeDates.Add(cursor.GetString(cursor.GetColumnIndexOrThrow("date")));
                    cursor.MoveToNext();
                }
            }
        }
    }
}

