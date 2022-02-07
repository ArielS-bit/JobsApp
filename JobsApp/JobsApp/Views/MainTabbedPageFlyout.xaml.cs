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

namespace JobsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedPageFlyout : ContentPage
    {
        public ListView ListView;

        public MainTabbedPageFlyout()
        {
            InitializeComponent();

            BindingContext = new MainTabbedPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MainTabbedPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainTabbedPageFlyoutMenuItem> MenuItems { get; set; }

            public MainTabbedPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainTabbedPageFlyoutMenuItem>(new[]
                {
                    new MainTabbedPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new MainTabbedPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new MainTabbedPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new MainTabbedPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new MainTabbedPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
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