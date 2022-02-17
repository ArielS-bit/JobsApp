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
            ProfileViewModel p = new ProfileViewModel();
            this.BindingContext = p;
            p.SetImageSourceEvent += OnSetImageSource;
        }

        public void OnSetImageSource(ImageSource imgSource)
        {
            theImage.Source = imgSource;
        }
    }
}