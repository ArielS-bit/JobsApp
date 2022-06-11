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
    public partial class EmployerFeedView : ContentView
    {
        public EmployerFeedView()
        {
            InitializeComponent();
            EmployerFeedViewModel l = new EmployerFeedViewModel();
            l.ClearSelection += ClearSelection;
            this.BindingContext = l;
            l.Push += (p) => Navigation.PushAsync(p);
           

        }

        public void ClearSelection()
        {
            jobOffersCollectionV.SelectedItem = null;
            
        }
        //protected override void OnAppearing()//לשים override
        //{
        //    ((EmployerFeedViewModel)this.BindingContext).OnAppearingFunc();
        //}
    }
}