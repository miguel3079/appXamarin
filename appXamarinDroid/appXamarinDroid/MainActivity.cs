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
            EditText name = FindViewById<EditText>(Resource.Id.userName);
            EditText pass = FindViewById<EditText>(Resource.Id.password);

            //Login button click action
            login.Click += (object sender, EventArgs e) => {
                Connection connection = new Connection();
                if (connection.Login(name.Text, pass.Text))
                {
                    Android.Widget.Toast.MakeText(this, "Dentro", Android.Widget.ToastLength.Short).Show();
                }
                else
                {
                    Android.Widget.Toast.MakeText(this, "Error de usuario y contraseña", Android.Widget.ToastLength.Short).Show();
                }
            };
        }
    }
}

