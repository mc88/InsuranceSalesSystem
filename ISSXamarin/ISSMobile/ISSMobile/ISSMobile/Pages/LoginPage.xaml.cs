using Xamarin.Forms;

namespace ISSMobile
{
    public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var basePageModel = this.BindingContext as FreshMvvm.FreshBasePageModel;
        }
    }
}