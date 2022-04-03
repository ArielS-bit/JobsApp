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
    public partial class EmployerProfileScreen : ContentPage
    {
        public EmployerProfileScreen()
        {
            InitializeComponent();
            EmployerProfileViewModel s = new EmployerProfileViewModel();
            this.BindingContext = s;
            s.Push += (p) => Navigation.PushAsync(p);
        }
    }
}