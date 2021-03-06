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
    public partial class ProfileScreen : ContentPage
    {
        public ProfileScreen()
        {
            InitializeComponent();
            ProfileViewModel r = new ProfileViewModel();
            this.BindingContext = r;
            r.Push += (p) => Navigation.PushAsync(p);
            r.SetImageSourceEvent += OnSetImageSource;
        }

        public void OnSetImageSource(ImageSource imgSource)
        {
            theImage.Source = imgSource;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
          

        }

    }
}