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
    class MeetOurAppViewModel:ViewModelBase
    {
        public event Action<Page> Push;
        public Command NavigateToSognUp => new Command(GetPage);
        public MeetOurAppViewModel()
        {
            Push += NavigateToPage;
        }
        public void GetPage()
        {
            Push?.Invoke(new BasicUserInfoScreen());
        }

        private async void NavigateToPage(Page obj)
        {
            await ((App)Application.Current).MainPage.Navigation.PushAsync(obj);
        }


    }
    
}
