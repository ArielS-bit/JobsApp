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
    public partial class BasicUserInfoScreen : ContentPage
    {
        public BasicUserInfoScreen()
        {
            //this.BindingContext = context;
            //context.SetImageSourceEvent += OnSetImageSource;
            InitializeComponent();



        }

        public void OnSetImageSource(ImageSource imgSource)
        {
            theImage.Source = imgSource;
        }
    }
}