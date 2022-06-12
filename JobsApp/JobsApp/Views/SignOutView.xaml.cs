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
    public partial class SignOutView : ContentView
    {
        public SignOutView()
        {
            InitializeComponent();
            InitializeComponent();
            SignUoutViewModel r = new SignUoutViewModel();
            this.BindingContext = r;
            r.Push += (p) => Navigation.PushAsync(p);
        }
    }
}