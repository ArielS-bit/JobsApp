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
    public partial class AddJobOffer : ContentPage
    {
        public AddJobOffer()
        {
            InitializeComponent();
            AddJobOfferViewModel a = new AddJobOfferViewModel();
            this.BindingContext = a;
            a.Push += (p) => Navigation.PushAsync(p);
        
        }
    }
}