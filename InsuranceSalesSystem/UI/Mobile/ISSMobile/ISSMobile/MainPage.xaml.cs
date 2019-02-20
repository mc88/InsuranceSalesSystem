using ISSMobile.Model;
using ISSMobile.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ISSMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void GetOffer(object sender, EventArgs e)
        {
            try
            {
                var url = $"{RestService.BaseUrl}Offer/OFF_636778039144482825";
                var result = await RestService.Get<OfferDetails>(url);

                await DisplayAlert("Response", JsonConvert.SerializeObject(result), "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception occured!", ex.Message, "OK");
                throw;
            }
        }

        async void CreateOffer(object sender, EventArgs e)
        {
            try
            {
                var createOfferPage = new CreateOfferPage();
                createOfferPage.BindingContext = new CreateOfferModel();
                await Navigation.PushModalAsync(createOfferPage);
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception occured!", ex.Message, "OK");
                throw;
            }
        }
    }
}
