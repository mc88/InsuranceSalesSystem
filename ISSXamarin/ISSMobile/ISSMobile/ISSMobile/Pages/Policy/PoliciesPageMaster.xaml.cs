using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ISSMobile
{
    public partial class PoliciesPageMaster : ContentPage
    {
        public ListView ListView;

        public PoliciesPageMaster()
        {
            InitializeComponent();

            BindingContext = new PoliciesPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class PoliciesPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PoliciesPageMenuItem> MenuItems { get; set; }
            
            public PoliciesPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<PoliciesPageMenuItem>(new[]
                {
                    new PoliciesPageMenuItem { Id = 0, Title = "Page 1" },
                    new PoliciesPageMenuItem { Id = 1, Title = "Page 2" },
                    new PoliciesPageMenuItem { Id = 2, Title = "Page 3" },
                    new PoliciesPageMenuItem { Id = 3, Title = "Page 4" },
                    new PoliciesPageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}