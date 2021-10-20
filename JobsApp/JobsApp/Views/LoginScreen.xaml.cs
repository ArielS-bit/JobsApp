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
            this.BindingContext = new LoginViewModel();
            InitializeComponent();
        }
        private void Password_Focused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            entry.IsPassword = true;
        }
    }
}