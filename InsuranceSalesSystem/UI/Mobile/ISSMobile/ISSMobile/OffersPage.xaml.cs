using ISSMobile.Enums;
using ISSMobile.Model;
using ISSMobile.Services;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISSMobile
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersPage : ContentPage
    {
        public ObservableCollection<Offer> Items { get; set; }

        public OffersPage()
        {
            InitializeComponent();
            //Items = new ObservableCollection<string> { "tafsdf", "AsfdsfS" };

            Items = new ObservableCollection<Offer> { new Offer() { OfferNumber = "123", ProductCode = "qwe" } };
            Task.Run(async () => await InitializeItemsAsync());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async Task InitializeItemsAsync()
        {
            try
            {
                var url = $"{RestService.BaseUrl}Offer/GetAll";
                var result = await RestService.Get<OffersDetails>(url);

                //                await DisplayAlert("Response", JsonConvert.SerializeObject(result), "OK");

                foreach (var offer in result.Offers)
                {
                    Items.Add(offer);
                }

                //TODO: why this does not work from XAML
                MyListView.ItemsSource = Items;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Exception occured!", ex.Message, "OK");
                throw;
            }
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            BindingContext = e.Item;
        }

        private async void RefreshItems(object sender, EventArgs e)
        {
            Items.Clear();
            await InitializeItemsAsync();
        }

        private void BuyPolicy(object sender, EventArgs e)
        {
            Offer offer = (Offer)BindingContext;

            if (offer.OfferStatus == Enums.OfferStatus.Active)
            {
                DisplayAlert("TODO", $"Selected offer: {offer.OfferNumber}", "OK");
            }
            else
            {
                DisplayAlert("Can't buy!", $"Offer has incorrect status: {Enum.GetName(typeof(OfferStatus), offer.OfferStatus)}", "OK");
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
