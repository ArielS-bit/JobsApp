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
    public partial class MeetOurApp : ContentPage
    {
        public MeetOurApp()
        {
            InitializeComponent();
            MeetOurAppViewModel l = new MeetOurAppViewModel();
            this.BindingContext = l;
            l.Push += (p) => Navigation.PushAsync(p);
            

            Stck.IsVisible = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

            Stck.IsVisible = true;
        }
    }
}