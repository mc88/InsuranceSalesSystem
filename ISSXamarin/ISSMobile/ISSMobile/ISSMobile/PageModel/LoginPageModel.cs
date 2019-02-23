using FreshMvvm;
using ISSMobile.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ISSMobile
{
    public class LoginPageModel : FreshBasePageModel
    {
        public LoginModel Credentials { get; set; }

        public Command LogIn
        {
            get {
                return new Command(async () => {
                    if (Credentials.Login == "test" && Credentials.Password == "test")
                    {
                        await CoreMethods.PushPageModel<ManagePageModel>();
                    }
                    else
                    {
                        await CoreMethods.DisplayAlert("Log In Failed", "Incorrect credentials! Please try again", "OK");
                    }
                });
            }
        }
    }
}
