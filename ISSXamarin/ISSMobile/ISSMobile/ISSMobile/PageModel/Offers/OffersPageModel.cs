using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FreshMvvm;
using ISSMobile.Enums;
using ISSMobile.Model;
using ISSMobile.Services;
using Xamarin.Forms;

namespace ISSMobile
{
    public class OffersPageModel : FreshBasePageModel
    {
        private readonly IOffersService offersService;

        public ObservableCollection<Offer> Offers { get; set; }

        public OffersPageModel(IOffersService offersService)
        {
            this.offersService = offersService;
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            GetOffers();
        }

        private async void GetOffers()
        {
            var offers = await offersService.GetOffers();

            Offers = new ObservableCollection<Offer>(offers);
            RaisePropertyChanged("Offers");
        }

        Offer selectedOffer;
        public Offer SelectedOffer
        {
            get
            {
                return selectedOffer;
            }
            set
            {
                selectedOffer = value;
                if (value != null)
                {
                    //ContactSelected.Execute(value);
                }
            }
        }

        //public Command<Offer> OfferSelected
        //{
        //    get
        //    {
        //        return new Command<Offer>(async (contact) => {
        //            await CoreMethods.PushPageModel<OfferPageModel>(contact);
        //        });
        //    }
        //}

        public Command CreateOffer
        {
            get
            {
                return new Command(async () => {
                    await CoreMethods.PushPageModel<CreateOfferPageModel>(null, true);
                });
            }
        }

        public Command BuyPolicy
        {
            get
            {
                return new Command(() => {
                    if (SelectedOffer.OfferStatus == Enums.OfferStatus.Active)
                    {
                        CoreMethods.DisplayAlert("TODO", $"Selected offer: {SelectedOffer.OfferNumber}", "OK");
                    }
                    else
                    {
                        CoreMethods.DisplayAlert("Can't buy!", $"Offer has incorrect status: {Enum.GetName(typeof(OfferStatus), SelectedOffer.OfferStatus)}", "OK");
                    }
                });
            }
        }
    }
}
