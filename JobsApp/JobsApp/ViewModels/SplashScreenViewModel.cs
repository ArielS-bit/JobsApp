using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using JobsApp.Services;
using JobsApp.Models;
using Xamarin.Essentials;
using System.Linq;
using JobsApp.ViewModels;
using JobsApp.Views;
using System.Collections.ObjectModel;

namespace JobsApp.ViewModels
{
    class SplashScreenViewModel:ViewModelBase
    {
        public SplashScreenViewModel()
        {

        }


        public event Action<Page> Push;
    }
}
