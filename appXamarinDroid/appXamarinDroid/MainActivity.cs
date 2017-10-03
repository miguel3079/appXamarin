using Android.App;
using Android.Widget;
using Android.OS;
using System;
using appXamarinDroid.Model;

namespace appXamarinDroid
{
    [Activity(Label = "appXamarinDroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Initializing button from layout
            Button login = FindViewById<Button>(Resource.Id.login);

            //Login button click action
            login.Click += (object sender, EventArgs e) => {
                Connection connection = new Connection();
                Android.Widget.Toast.MakeText(this, connection.GetAccountCountFromMySQL(), Android.Widget.ToastLength.Short).Show();
            };
        }
    }
}

