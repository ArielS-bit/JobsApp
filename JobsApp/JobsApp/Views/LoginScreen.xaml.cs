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
    public partial class LoginScreen : ContentPage
    {
        public LoginScreen()
        {
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Red;
            InitializeComponent();

            LoginViewModel l = new LoginViewModel();
            l.Push += (p) => Navigation.PushAsync(p);
            this.BindingContext = l;
            //((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Black;
            //((NavigationPage)Application.Current.MainPage).BarTextColor = Color.OrangeRed;
        }
        private void Password_Focused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            entry.IsPassword = true;
        }
    }
}