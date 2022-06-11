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
    class LoginViewModel:ViewModelBase
    {
        #region Properties
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                EmailVaidation();
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

        private string isAnswerValid;
        public string IsAnswerValid
        {
            get { return isAnswerValid; }
            set
            {
                isAnswerValid = value;
                OnPropertyChanged("IsAnswerValid");
            }
        }


        private bool emailErrorShown;

        public bool EmailErrorShown
        {
            get => emailErrorShown;
            set
            {
                emailErrorShown = value;
                OnPropertyChanged("EmailErrorShown");
            }
        }
        #endregion

        private void EmailVaidation()
        {
            this.EmailErrorShown = (string.IsNullOrEmpty(Email)||!(Email.Contains('@')&&email.Contains('.')));
            
        }

        public LoginViewModel()
        {
            Email = "";
            Password = "";
            IsAnswerValid = "";
            EmailErrorShown = false;

        }
        public event Action<Page> Push;
        public ICommand LoginCommand => new Command(Login);

      

        //private string serverStatus;
        //public string ServerStatus
        //{
        //    get { return serverStatus; }
        //    set
        //    {
        //        serverStatus = value;
        //        OnPropertyChanged("ServerStatus");
        //    }
        //}

        public async void Login()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();

            User u = await proxy.LoginAsync(Email, Password);

            if (u == null)
            {
                await Application.Current.MainPage.DisplayAlert("Login Failed!", "Email or password invalid", "OK");
            }
            else
            {
                ((App)App.Current).CurrentUser = u;
                
                    //try
                    //{
                    //    await SecureStorage.SetAsync("user_token", "secret-user-token-value");
                    //}
                    //catch (Exception e)
                    //{
                    //    // Possible that device doesn't support secure storage on device.
                    //}
                
               
                //App theApp = (App)App.Current;
                //theApp.CurrentUser = user;

                //Check if it is an employer or employee
                Push?.Invoke(new EmployerMainTabView());

                //May Change to profile screen
            }

            

            //עיגול שמסמן את טעינת האפליקציה יש להוסיף בהקדם!
            //ServerStatus = "מתחבר לשרת...";
            //await App.Current.MainPage.Navigation.PushModalAsync(new Views.ServerStatusPage(this));
            //JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            //User user = await proxy.LoginAsync(Email, Password);
            //if (user == null)
            //{
            //    await App.Current.MainPage.DisplayAlert("Alert!", "Log in failed, username or password invalid", "OK");
            //}
            //else
            //{
            //    //ServerStatus = "קורא נתונים...";
            //    //App theApp = (App)App.Current;
            //    //theApp.CurrentUser = user;
            //    //bool success = await LoadPhoneTypes(theApp);
            //    //if (!success)
            //    //{
            //    //await App.Current.MainPage.Navigation.PopModalAsync();
            //    //await App.Current.MainPage.DisplayAlert("שגיאה", "קריאת נתונים נכשלה. נסה שוב מאוחר יותר", "בסדר");
            //    //}
            //    //Initiate all phone types refrence to the same objects of PhoneTypes


            //    Page p = new NavigationPage(new Views.FeedScreen());
            //    App.Current.MainPage = p;



            //}
        }
        public ICommand SignUpCommand => new Command(SignUp);
        private void SignUp()
        {
            //if (Email == "Admin@gmail.com")
            //{
            //    Push?.Invoke(new AdminScreen());//נעביר לדף מנהל

            //}
            //else
            //{
                Push?.Invoke(new BasicUserInfoScreen());

          //  }
        }

        public ICommand ForgotPassCommand => new Command(ForgotPassword);
        private void ForgotPassword()
        {
            Push?.Invoke(new ForgotPasswordScreen());
        }




    }
}

