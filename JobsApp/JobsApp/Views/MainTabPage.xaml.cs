using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JobsApp.Views;

namespace JobsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabPage : TabbedPage
    {
        public MainTabPage()
        {
            InitializeComponent();
            //MyMenu = GetMenus();
            //this.BindingContext = this;


        }

        //private void OpenSwipe(Object sender, EventArgs e)
        //{

        //    MainSwipeMenu.Open(OpenSwipeItem.LeftItems);
        //    OpenAnimations();
        //    sideMenu.GestureRecognizers.Clear();
        //    var tapGestureRecognizer = new TapGestureRecognizer();
        //    tapGestureRecognizer.Tapped += (s, e1) => {
        //        CloseSwipe(s, e1);
        //    };

        //    sideMenu.GestureRecognizers.Add(tapGestureRecognizer);
        //}

        //private void CloseSwipe(Object sender, EventArgs e)
        //{

        //    CloseAnimations();
        //    MainSwipeMenu.Close();
        //    sideMenu.GestureRecognizers.Clear();
        //    var tapGestureRecognizer = new TapGestureRecognizer();
        //    tapGestureRecognizer.Tapped += (s, e1) => {
        //        OpenSwipe(s, e1);
        //    };

        //    sideMenu.GestureRecognizers.Add(tapGestureRecognizer);
        //}

        //public class Menu
        //{
        //    public string Name { get; set; }
        //    public string Icon { get; set; }

        //}
        //public List<Menu> MyMenu { get; set; }
        //private List<Menu> GetMenus()
        //{
        //    return new List<Menu>
        //    {
        //        new Menu{Name="Home", Icon="HomeIcon.png"},
        //        new Menu{Name="Notifications", Icon="bellOffIcon.png"},
        //        new Menu{Name="Jobs", Icon="JobsIcon.png"},
        //        new Menu{Name="Profile", Icon="ProfileIcon.png"}


        //    };
        //}

        //public async void OpenAnimations()
        //{
        //    await SwipeContent.ScaleYTo(0.9, 300, Easing.SinOut);
        //    Pancake.CornerRadius = 50;

        //    await SwipeContent.RotateTo(-25, 300, Easing.SinOut);
        //}

        //public async void CloseAnimations()
        //{
        //    await SwipeContent.RotateTo(0, 300, Easing.SinIn);
        //    Pancake.CornerRadius = 0;
        //    await SwipeContent.ScaleYTo(1, 300, Easing.SinIn);
        //}
    }

}