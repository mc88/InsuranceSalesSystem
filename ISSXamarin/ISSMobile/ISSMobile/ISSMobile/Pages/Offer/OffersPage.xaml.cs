
using Xamarin.Forms;

namespace ISSMobile
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersPage : ContentPage
    {
        public OffersPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var basePageModel = this.BindingContext as FreshMvvm.FreshBasePageModel;

            if (basePageModel != null)
            {
                if (basePageModel.IsModalAndHasPreviousNavigationStack())
                {
                    if (ToolbarItems.Count < 2)
                    {
                        var closeModal = new ToolbarItem("Close Modal", "", () => {
                            basePageModel.CoreMethods.PopModalNavigationService();
                        });

                        ToolbarItems.Add(closeModal);
                    }
                }
            }
        }
    }
}
