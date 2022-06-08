using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JobsApp.ViewModels;

namespace JobsApp.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonalJobOffersView : ContentView
    {
        public PersonalJobOffersView()
        {
            InitializeComponent();
            PersonalJobOffersViewModel l = new PersonalJobOffersViewModel();
            l.Push += (p) => Navigation.PushAsync(p);
            this.BindingContext = l;
        }
    }
}