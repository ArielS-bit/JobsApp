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

        #region Propreties
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
              ((Command) SignUpCommand).ChangeCanExecute();
                    OnPropertyChanged("FirstName");
            }
        }

        private bool firstNameErrorShown;

        public bool FirstNameErrorShown
        {
            get => firstNameErrorShown;
            set
            {
                firstNameErrorShown = value;
                OnPropertyChanged("FirstNameErrorShown");
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

        private bool lastNameErrorShown;

        public bool LastNameErrorShown
        {
            get => lastNameErrorShown;
            set
            {
                lastNameErrorShown = value;
                OnPropertyChanged("LastNameErrorShown");
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

        private bool genderNameErrorShown;

        public bool GenderNameErrorShown
        {
            get => genderNameErrorShown;
            set
            {
                genderNameErrorShown = value;
                OnPropertyChanged("GenderNameErrorShown");
            }
        }


        private DateTime bday;

        public DateTime Bday
        {
            get { return bday; }
            set
            {
                bday = value;
                //BdayValidation();
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
                //BdayValidation();
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
                //EmailVaidation();
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
                //PassValidation();
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
                //NicknameValidation();
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

        private bool userTypeIDNameErrorShown;

        public bool UserTypeIDNameErrorShown
        {
            get => userTypeIDNameErrorShown;
            set
            {
                userTypeIDNameErrorShown = value;
                OnPropertyChanged("UserTypeIDNameErrorShown");
            }
        }

        private string privateAnswer;
        public string PrivateAnswer
        {
            get => privateAnswer;
            set
            {
                privateAnswer = value;
                //AnswerValidation();
                OnPropertyChanged("PrivateAnswer");
            }
        }

        private bool privateAnswerIDNameErrorShown;

        public bool PrivateAnswerIDNameErrorShown
        {
            get => privateAnswerIDNameErrorShown;
            set
            {
                privateAnswerIDNameErrorShown = value;
                OnPropertyChanged("PrivateAnswerIDNameErrorShown");
            }
        }

        private bool enableBtn;
        public bool EnableBtn
        {
            get => enableBtn;
            set
            {
                enableBtn = value;

                OnPropertyChanged("EnableBtn");
            }
        }
        #endregion Properties

        private void BdayValidation()
        {
            this.BdayErrorShown = (Bday == DateTime.Now || bday.Year>2011);

        }
        private void EmailVaidation()
        {
            this.EmailErrorShown = (string.IsNullOrEmpty(Email) || !(Email.Contains('@') && email.Contains('.')));
            //this.EmailErrorShown = Check it's not already exist and change the label accordng it 

        }

        public bool EnableBtnValidation()
        {
            return (this.EmailErrorShown && this.PassErrorShown&& this.NicknameErrorShown&& this.BdayErrorShown && this.FirstNameErrorShown && this.LastNameErrorShown && this.GenderNameErrorShown && this.UserTypeIDNameErrorShown);
        }

        private void PassValidation()
        {
            this.PassErrorShown = (pass.Length < 8);


        }

        private void NicknameValidation()
        {
            //this.NicknameErrorShown = if already exists
        }

        public User MyUser {get;set;}

        public ICommand CountinueCommand => new Command(Continue);
        public ICommand SignUpCommand { get; set; }

        public BasicUserInfoViewModel()
        {
            this.firstName = "";
            this.lastName = "";
            this.nickname = "";
            this.email = "";
            this.gender = "";
            this.bday = DateTime.Today;
            this.pass = "";
            this.privateAnswer = "";
            SignUpCommand = new Command(SignUp, EnableBtnValidation);
        }

        public async void Continue()
        {
            Push?.Invoke(new UserCredentialsScreen() { BindingContext = this });
        }

        public async void SignUp()
        {
            
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();

            User MyUser = new User() { FirstName = firstName, LastName = lastName, Birthday = bday, Email = email, Gender = gender, Nickname = nickname, Pass = pass, PrivateAnswer = privateAnswer };  
            User u = await proxy.SignUpAsync(MyUser);


            if (u == null)
            {
                await Application.Current.MainPage.DisplayAlert("Sign Up Failed!", "Email or username invalid", "OK");
            }
            else
            {
                ((App)App.Current).CurrentUser = u;
                //App theApp = (App)App.Current;
                //theApp.CurrentUser = user;
                Push?.Invoke(new FeedScreen());
            }

            Push?.Invoke(new FeedScreen());

        }


    }
}
