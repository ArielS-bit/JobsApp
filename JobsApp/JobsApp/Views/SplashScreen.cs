using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using JobsApp.Views;

using Xamarin.Forms;

namespace JobsApp
{
    public class SplashScreen : ContentPage
    {
        Image splashImage;

        public SplashScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "DemoLogo.png",
                WidthRequest = 80,
                HeightRequest = 80
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#dfe6e9");
            this.Content = sub;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 2000); //Time-consuming processes such as initialization
            await splashImage.ScaleTo(0.6, 1500, Easing.Linear);
            await splashImage.ScaleTo(80, 1200, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new LoginScreen());    //After loading  MainPage it gets Navigated to our new Page
        }
    }
}
