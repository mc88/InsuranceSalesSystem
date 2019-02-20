using ISSMobile.Model;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISSMobile
{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = new LoginModel();
        }

        void LogIn(object sender, EventArgs e)
        {
            var loginModel = (LoginModel)BindingContext;

            if (loginModel.Login == "test" && loginModel.Password == "test")
            {
                Navigation.PushAsync(new MainPage { BindingContext = this.BindingContext});
            }
            else
            {
                DisplayAlert("Log In Failed", "Incorrect credentials! Please try again", "OK");
            }
        }
    }
}