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
    class BasicUserInfoViewModel:ViewModelBase
    {
        public event Action<Page> Push;

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private DateTime bday;

        public DateTime Bday
        {
            get { return bday; }
            set
            {
                bday = value;
                BdayValidation();
                OnPropertyChanged("Bday");
            }
        }

        private bool bdayErrorShown;

        public bool BdayErrorShown
        {
            get => bdayErrorShown;
            set
            {
                bdayErrorShown = value;
                BdayValidation();
                OnPropertyChanged("BdayErrorShown");
            }
        }
        

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

        private string pass;

        public string Pass
        {
            get { return pass; }
            set
            {
                pass = value;
                PassValidation();
                OnPropertyChanged("Pass");
            }
        }

        private bool passErrorShown;

        public bool PassErrorShown
        {
            get => passErrorShown;
            set
            {
                passErrorShown = value;
                OnPropertyChanged("PassErrorShown");
            }
        }

        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set
            {
                nickname = value;
                NicknameValidation();
                OnPropertyChanged("Nickname");
            }
        }
        private bool nicknameErrorShown;

        public bool NicknameErrorShown
        {
            get => nicknameErrorShown;
            set
            {
                nicknameErrorShown = value;
                OnPropertyChanged("NicknameErrorShown");
            }
        }

        private int userTypeID;
        public int UserTypeID
        {
            get { return userTypeID; }
            set
            {
                userTypeID = value;
                OnPropertyChanged("UserTypeID");
            }
        }

        private string privateAnswer;
        public string PrivateAnswer
        {
            get => privateAnswer;
            set
            {
                privateAnswer = value;
                AnswerValidation();
                OnPropertyChanged("PrivateAnswer");
            }
        }
        private void BdayValidation()
        {
            this.BdayErrorShown = (Bday == DateTime.Now || bday.Year>2011);

        }
        private void EmailVaidation()
        {
            this.EmailErrorShown = (string.IsNullOrEmpty(Email) || !(Email.Contains('@') && email.Contains('.')));
            //this.EmailErrorShown = Check it's not already exist and change the label accordng it 

        }

        private void PassValidation()
        {
            this.PassErrorShown = (pass.Length < 8);


        }

        private void NicknameValidation()
        {
            //this.NicknameErrorShown = if already exists
        }


        public ICommand CountinueCommand => new Command(Continue);

        public BasicUserInfoViewModel(string first, string last, string nickname, string email, string gender, DateTime bday, string pass, string privateAnswer)
        {
            this.firstName = first;
            this.lastName = last;
            this.nickname = nickname;
            this.email = email;
            this.gender = gender;
            this.bday = bday;
            this.pass = pass;
            this.privateAnswer = privateAnswer;
        }

        public async void Continue()
        {
            //JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();

            //User u = await proxy.SignUpAsync(Email, Password);

            //if (u == null)
            //{
            //    await Application.Current.MainPage.DisplayAlert("Login Failed!", "Email or username invalid", "OK");
            //}
            //else
            //{
            //    ((App)App.Current).CurrentUser = u;
            //    //App theApp = (App)App.Current;
            //    //theApp.CurrentUser = user;
                Push?.Invoke(new UserCredentialsScreen());
            //}
        }


    }
}
