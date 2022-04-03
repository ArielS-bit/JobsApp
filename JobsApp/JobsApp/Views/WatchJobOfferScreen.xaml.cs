using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JobsApp.ViewModels;

namespace JobsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WatchJobOfferScreen : ContentPage
    {
        public WatchJobOfferScreen()
        {
            InitializeComponent();
            WatchJobOfferViewModel w = new WatchJobOfferViewModel();
            this.BindingContext = w;
            w.Push += (p) => Navigation.PushAsync(p);
        }
    }
}