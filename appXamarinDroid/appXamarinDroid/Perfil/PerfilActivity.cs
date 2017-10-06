
using Android.App;
using Android.Content;
using Android.OS;
using appXamarinDroid.Model;
using Android.Widget;
using appXamarinDroid.Model.DTOs;

namespace appXamarinDroid
{
    [Activity(Label = "Perfil")]
    public class Perfil : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Connection connection = new Connection();
            base.OnCreate(savedInstanceState);
            string userName = Intent.GetStringExtra("UserName") ?? "Data not available";

            SetContentView(Resource.Layout.Perfil);
            ActionBar.Hide();
            // Inicializamos los elementos de nuestra vista

            UserDto user = connection.UserPerfil(userName);
            Initialize(user);

        }

        private void Initialize(UserDto user)
        {
            EditText nameUser = FindViewById<EditText>(Resource.Id.userName);
            EditText surnameUser = FindViewById<EditText>(Resource.Id.userSurname);
            EditText emailUser = FindViewById<EditText>(Resource.Id.userEmail);
            EditText passUser = FindViewById<EditText>(Resource.Id.password);
            Switch activoUSer = FindViewById<Switch>(Resource.Id.switch1);
            Button btnSave = FindViewById<Button>(Resource.Id.btnSave);
            Button btnCancel = FindViewById<Button>(Resource.Id.btnCancel);

            nameUser.Text = user.Name;
            surnameUser.Text = user.Surname;
            emailUser.Text = user.Email;
            passUser.Text = user.Pass;
            activoUSer.Checked = user.Active;
        }
    }
}
