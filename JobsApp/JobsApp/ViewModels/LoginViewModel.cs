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
//using JobsApp.Services;
//using JobsApp.Models;


namespace JobsApp.ViewModels
{
    class LoginViewModel:ViewModelBase
    {
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public ICommand SubmitCommand { protected set; get; }

        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
        }

        private string serverStatus;
        public string ServerStatus
        {
            get { return serverStatus; }
            set
            {
                serverStatus = value;
                OnPropertyChanged("ServerStatus");
            }
        }

        public async void OnSubmit()
        {
            //עיגול שמסמן את טעינת האפליקציה יש להוסיף בהקדם!
            //ServerStatus = "מתחבר לשרת...";
            //await App.Current.MainPage.Navigation.PushModalAsync(new Views.ServerStatusPage(this));
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            User user = await proxy.LoginAsync(Email, Password);
            if (user == null)
            {
                await App.Current.MainPage.DisplayAlert("Alert!", "Log in failed, username or password invalid", "OK");
            }
            else
            {
                //ServerStatus = "קורא נתונים...";
                App theApp = (App)App.Current;
                theApp.CurrentUser = user;
                //bool success = await LoadPhoneTypes(theApp);
                //if (!success)
                //{
                //await App.Current.MainPage.Navigation.PopModalAsync();
                //await App.Current.MainPage.DisplayAlert("שגיאה", "קריאת נתונים נכשלה. נסה שוב מאוחר יותר", "בסדר");
                //}
                //Initiate all phone types refrence to the same objects of PhoneTypes


                Page p = new NavigationPage(new Views.FeedScreen());
                App.Current.MainPage = p;



            }
        }
    }
}

