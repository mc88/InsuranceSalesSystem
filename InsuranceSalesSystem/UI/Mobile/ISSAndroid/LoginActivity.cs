using Android.App;
using Android.OS;
using Android.Widget;
using System;

namespace ISSAndroid
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        private Button loginButton;
        private EditText loginTextEdit;
        private EditText passwordTextEdit;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            InitializeControlsAndEvents();
        }

        private void InitializeControlsAndEvents()
        {
            loginButton = FindViewById<Button>(Resource.Id.LogInButton);
            loginTextEdit = FindViewById<EditText>(Resource.Id.LoginTextEdit);
            passwordTextEdit = FindViewById<EditText>(Resource.Id.PasswordTextEdit);

            loginButton.Click += (sender, e) => LogInClick(sender, e);
        }

        private void LogInClick(object sender, EventArgs e)
        {
            var login = loginTextEdit.Text;
            var password = passwordTextEdit.Text;

            if (MockedLogin(login, password))
            {

            }
            else
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetMessage("Incorrect credentials! Please try again!");
                //builder.SetPositiveButton("OK");
            }
        }

        //TODO: This simulates login functionality, need to add real authentication/authorization in future
        private bool MockedLogin(string login, string password)
        {
            var mockedUserName = "test";
            var mockedPassword = "test";

            return login == mockedUserName && password == mockedPassword;
        }
    }
}