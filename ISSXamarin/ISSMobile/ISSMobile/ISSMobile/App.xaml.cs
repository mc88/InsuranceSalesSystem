using FreshMvvm;
using ISSMobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ISSMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.EntypoPlusModule())
                          .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                          .With(new Plugin.Iconize.Fonts.FontAwesomeBrandsModule())
                          .With(new Plugin.Iconize.Fonts.FontAwesomeSolidModule())
                          .With(new Plugin.Iconize.Fonts.IoniconsModule())
                          .With(new Plugin.Iconize.Fonts.MaterialModule())
                          .With(new Plugin.Iconize.Fonts.MeteoconsModule())
                          .With(new Plugin.Iconize.Fonts.SimpleLineIconsModule())
                          .With(new Plugin.Iconize.Fonts.TypiconsModule())
                          .With(new Plugin.Iconize.Fonts.WeatherIconsModule());

            SetUpIoC();

            LoadTabbedNav();

            
            //MainPage = new NavigationPage(new ManagePage());
        }

        public void LoadBasicNav()
        {
            var page = FreshPageModelResolver.ResolvePageModel<OffersPageModel>();
            var basicNavContainer = new FreshNavigationContainer(page);
            MainPage = basicNavContainer;
        }

        public void LoadTabbedNav()
        {
            var tabbedNavigation = new FreshTabbedNavigationContainer();
            tabbedNavigation.AddTab<PoliciesPageModel>("Policies", "fas-home");
            tabbedNavigation.AddTab<OffersPageModel>("Offers", "md-airplane");
            MainPage = tabbedNavigation;
        }

        protected void SetUpIoC()
        {
            FreshIOC.Container.Register<IRestService, RestService>();
            FreshIOC.Container.Register<IOffersService, OffersService>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
