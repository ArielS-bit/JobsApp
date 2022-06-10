using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JobsApp.ViewModels;
using JobsApp.Views;



namespace JobsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployerMainTabView : ContentPage
    {
        public EmployerMainTabView()
        {
            InitializeComponent();
            MainTabViewVM m = new MainTabViewVM();
            this.BindingContext = m;
            m.Push += (p) => Navigation.PushAsync(p);
        }


        private void OpenSwipe(Object sender, EventArgs e)
        {

            MainSwipeMenu.Open((OpenSwipeItem)OpenSwipeItem.LeftItems);
            OpenAnimations();
            sideMenu.GestureRecognizers.Clear();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e1) => {
                CloseSwipe(s, e1);
            };
            sideMenu.Source = "OpenedSideMenu.png";
            sideMenu.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void CloseSwipe(Object sender, EventArgs e)
        {

            CloseAnimations();
            MainSwipeMenu.Close();
            sideMenu.GestureRecognizers.Clear();
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e1) => {
                OpenSwipe(s, e1);
            };
            sideMenu.Source = "SideMenuHamburger.png";
            sideMenu.GestureRecognizers.Add(tapGestureRecognizer);
        }


        public async void OpenAnimations()
        {
            await SwipeContent.ScaleYTo(0.9, 300, Easing.SinOut);
            Pancake.CornerRadius = 50;
            await SwipeContent.RotateTo(-25, 300, Easing.SinOut);
        }

        public async void CloseAnimations()
        {
            await SwipeContent.RotateTo(0, 300, Easing.SinIn);
            Pancake.CornerRadius = 0;
            await SwipeContent.ScaleYTo(1, 300, Easing.SinIn);
        }
    }
}