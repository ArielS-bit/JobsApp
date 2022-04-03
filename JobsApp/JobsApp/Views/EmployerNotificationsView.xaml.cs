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
    public partial class EmployerNotificationsView : ContentView
    {
        public EmployerNotificationsView()
        {
            InitializeComponent();
            EmployerNotificationsViewModel e = new EmployerNotificationsViewModel();
            this.BindingContext = e;
            e.Push += (p) => Navigation.PushAsync(p);
        }
    }
}