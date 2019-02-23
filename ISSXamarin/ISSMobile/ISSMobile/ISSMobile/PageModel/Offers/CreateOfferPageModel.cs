using FreshMvvm;
using ISSMobile.Model;
using ISSMobile.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ISSMobile
{
    public class CreateOfferPageModel : FreshBasePageModel
    {
        private readonly IOffersService offersService;

        public CreateOffer Offer { get; set; }

        public CreateOfferPageModel(IOffersService offersService)
        {
            this.offersService = offersService;
            Offer = new CreateOffer();
        }

        public Command RequestPolicy
        {
            get
            {
                return new Command(async () => {
                    bool success = await offersService.CreateOffer(Offer);

                    if (success)
                    {
                        await CoreMethods.DisplayAlert("Success", "Check new offer", "OK");
                    }
                    else
                    {
                        await CoreMethods.DisplayAlert("Failure", "Something goes wrong", "OK");
                    }

                    await CoreMethods.PopPageModel();
                });
            }
        }

        public Command Cancel
        {
            get
            {
                return new Command(async () => {
                    await CoreMethods.PopPageModel();
                });
            }
        }


        //public Command ProductChanged
        //{
        //    get
        //    {
        //        return new Command(() => {
        //            Offer.ProductCode = (string)((Picker)sender).SelectedItem;
        //        });
        //    }
            
        //}

        //void CoverChanged(object sender, EventArgs e)
        //{
        //    //TODO: multiple Picker (probably need to replace Picker by ListView)
        //    Offer.SelectedCovers = new List<string>() { (string)((Picker)sender).SelectedItem };
        //}

        //void ProductChanged(object sender, EventArgs e)
        //{
        //    Offer.ProductCode = (string)((Picker)sender).SelectedItem;
        //}

        //void CoverChanged(object sender, EventArgs e)
        //{
        //    //TODO: multiple Picker (probably need to replace Picker by ListView)
        //    Offer.SelectedCovers = new List<string>() { (string)((Picker)sender).SelectedItem };
        //}
    }
}
