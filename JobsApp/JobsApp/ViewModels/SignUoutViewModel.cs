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

namespace JobsApp.ViewModels
{
    class SignUoutViewModel:ViewModelBase
    {
        public SignUoutViewModel()
        {

        }

        public ICommand SignOutCommand => new Command(SignOut);

        public async void SignOut()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();

            currentApp.CurrentUser = null;
        }
    }
}
