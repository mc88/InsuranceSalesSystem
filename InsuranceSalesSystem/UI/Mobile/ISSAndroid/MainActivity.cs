using Android.App;
using Android.Widget;
using Android.OS;
using ISSAndroid.Rest;
using ISSAndroid.Dto.Rest;
using ISSAndroid.Dto.Offer;
using Newtonsoft.Json;

namespace ISSAndroid
{
    [Activity(Label = "ISSAndroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button loginButton = FindViewById<Button>(Resource.Id.LogInButton);
            EditText clientIdEditText = FindViewById<EditText>(Resource.Id.clientIdTextEdit);
            TextView offerDetailsTextView = FindViewById<TextView>(Resource.Id.OfferDetailsTextView);

            loginButton.Click += async (sender, e) =>
            {
                var message = $"Hello {clientIdEditText.Text}!";
                Toast.MakeText(ApplicationContext, message, ToastLength.Long).Show();


                var url = $"{BaseRestService.BaseUrl}Offer/OFF_636778039144482825";
                var result = await BaseRestService.Get<OfferDetailsDto>(url);

                offerDetailsTextView.Text = JsonConvert.SerializeObject(result); 
            };
        }
    }
}

