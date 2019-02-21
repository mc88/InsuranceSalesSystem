using ISSMobile.Model;
using ISSMobile.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISSMobile
{
	//[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateOfferPage : ContentPage
	{
        private CreateOfferModel Model => (CreateOfferModel)BindingContext;

		public CreateOfferPage()
		{
			InitializeComponent ();
		}

        void ProductChanged(object sender, EventArgs e)
        {
            Model.ProductCode = (string)((Picker)sender).SelectedItem;
        }

        void CoverChanged(object sender, EventArgs e)
        {
            //TODO: multiple Picker (probably need to replace Picker by ListView)
            Model.SelectedCovers = new List<string>() { (string)((Picker)sender).SelectedItem };
        }

        async void RequestPolicy(object sender, EventArgs e)
        {
            try
            {
                var url = $"{RestService.BaseUrl}Offer/Create";
                var result = await RestService.Post<object>(url, BindingContext);

                await DisplayAlert("Response", JsonConvert.SerializeObject(result), "OK");
                Cancel(sender, e);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception occured!", ex.Message, "OK");
                throw;
            }
        }

        async void Cancel(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
	}
}