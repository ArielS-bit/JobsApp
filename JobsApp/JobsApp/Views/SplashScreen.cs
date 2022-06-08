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
                Source = "NormalScaleLogo.png",
                WidthRequest = 50,
                HeightRequest = 50
            };
            AbsoluteLayout.SetLayoutFlags(splashImage,
               AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(splashImage,
             new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#829ec6");
            this.Content = sub;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(1, 1500); //Time-consuming processes such as initialization
            await splashImage.ScaleTo(4, 100, Easing.SinOut);
            await splashImage.ScaleTo(500, 100, Easing.SinOut);
            Application.Current.MainPage = new NavigationPage(new MeetOurApp());    //After loading  MainPage it gets Navigated to our new Page
        }
    }
}
