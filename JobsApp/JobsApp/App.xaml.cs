using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JobsApp.Models;
using JobsApp.Views;
using Syncfusion;
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
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTg4MzA2QDMxMzkyZTM0MmUzMG1Ya0hxUmowbVN5TkVaUldpT2pDYldqcFBXTm1PTDFtNUZpcmZjU2pJZVU9");
            InitializeComponent();
            CurrentUser = null;
           
            MainPage = new NavigationPage(new SignUpScreen());
            
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
