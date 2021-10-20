using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JobsApp.Models;
using JobsApp.Views;

using System.Collections.Generic;

namespace JobsApp
{
    public partial class App : Application
    {
        public User CurrentUser { get; set; }
        public static bool IsDevEnv
        {
            get
            {
                return true; //change this before release!
            }
        }

        public App()
        {
            
            InitializeComponent();

            MainPage = new NavigationPage(new ExPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
