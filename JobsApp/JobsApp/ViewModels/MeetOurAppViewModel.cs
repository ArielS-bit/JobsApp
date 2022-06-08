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
       
        public MeetOurAppViewModel()
        {
            //Push += NavigateToPage;
        }
        public event Action<Page> Push;
        public ICommand NavigateToLogInCommand => new Command(GetLogInPage);
        public ICommand NavigateToSignUpCommand => new Command(GetSignUpPage);
        public void GetLogInPage()
        {
            Push?.Invoke(new LoginScreen());
        }
        public void GetSignUpPage()
        {
            Push?.Invoke(new BasicUserInfoScreen());
        }

        //private async void NavigateToPage(Page obj)
        //{
        //    await ((App)Application.Current).MainPage.Navigation.PushAsync(obj);
        //}


    }
    
}
