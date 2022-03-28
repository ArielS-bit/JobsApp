using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using JobsApp.Models;
using JobsApp.Views;
using Syncfusion;
using System.Collections.Generic;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: ExportFont("Roboto-Black.ttf", Alias = "Black")]
[assembly: ExportFont("Roboto-BlackItalic.ttf", Alias = "BlackItalic")]
[assembly: ExportFont("Roboto-Bold.ttf", Alias = "Bold")]
[assembly: ExportFont("Roboto-BoldItalic.ttf", Alias = "BoldItalic")]
[assembly: ExportFont("Roboto-Italic.ttf", Alias = "Italic")]
[assembly: ExportFont("Roboto-Light.ttf", Alias = "Light")]
[assembly: ExportFont("Roboto-LightItalic.ttf", Alias = "LightItalic")]
[assembly: ExportFont("Roboto-Medium.ttf", Alias = "Medium")]
[assembly: ExportFont("Roboto-MediumItalic.ttf", Alias = "MediumItalic")]
[assembly: ExportFont("Roboto-Thin.ttf", Alias = "Thin")]
[assembly: ExportFont("Roboto-ThinItalic", Alias = "ThinItalic")]


namespace JobsApp
{
    public partial class App : Application
    {
        ////Use it 
        //https://docs.microsoft.com/en-us/xamarin/android/user-interface/splash-screen
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

            MainPage = new NavigationPage(new AboutUsScreen());//Should be navigating to Splash Screen
            //{
            //    BarBackgroundColor = Color.Transparent
            //};
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
