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
    public partial class JobsHistoryView : ContentView
    {
        public JobsHistoryView()
        {
            InitializeComponent();
            JobsHistoryViewModel j = new JobsHistoryViewModel();
            this.BindingContext = j;
            j.Push += (p) => Navigation.PushAsync(p);
        }
    }
}