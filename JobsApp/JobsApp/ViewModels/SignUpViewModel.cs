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
    class SignUpViewModel:ViewModelBase
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
                FirstNameValidation();
                ((Command)CountinueCommand).ChangeCanExecute();
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
                LastNameValidation();
                ((Command)CountinueCommand).ChangeCanExecute();
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
                GenderValidation();
                ((Command)CountinueCommand).ChangeCanExecute();
                OnPropertyChanged("Gender");
            }
        }

        private bool genderErrorShown;

        public bool GenderErrorShown
        {
            get => genderErrorShown;
            set
            {
                genderErrorShown = value;
                OnPropertyChanged("GenderErrorShown");
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
                ((Command)CountinueCommand).ChangeCanExecute();
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
                ((Command)SignUpCommand).ChangeCanExecute();
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
                ((Command)SignUpCommand).ChangeCanExecute();
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
                ((Command)SignUpCommand).ChangeCanExecute();
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
                UserTypeIDValidation();
                ((Command)SignUpCommand).ChangeCanExecute();
                OnPropertyChanged("UserTypeID");
            }
        }

        private bool userTypeIDErrorShown;

        public bool UserTypeIDErrorShown
        {
            get => userTypeIDErrorShown;
            set
            {
                userTypeIDErrorShown = value;
                OnPropertyChanged("UserTypeIDErrorShown");
            }
        }

        private string privateAnswer;
        public string PrivateAnswer
        {
            get => privateAnswer;
            set
            {
                privateAnswer = value;
                PrivateAnswerValidation();
                ((Command)SignUpCommand).ChangeCanExecute();
                OnPropertyChanged("PrivateAnswer");
            }
        }

        private bool privateAnswerErrorShown;

        public bool PrivateAnswerErrorShown
        {
            get => privateAnswerErrorShown;
            set
            {
                privateAnswerErrorShown = value;
                OnPropertyChanged("PrivateAnswerErrorShown");
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

        #region Validation Functions
        private void FirstNameValidation()
        {
            this.FirstNameErrorShown = string.IsNullOrEmpty(FirstName); 
        }

        private void LastNameValidation()
        {
            this.LastNameErrorShown = string.IsNullOrEmpty(LastName);
        }

        private void GenderValidation()
        {
            this.GenderErrorShown = string.IsNullOrEmpty(Gender);
        }
        private void UserTypeIDValidation()
        {
            if (userTypeID == 0)
                this.UserTypeIDErrorShown = true;

        }
        public void PrivateAnswerValidation()
        {
            this.PrivateAnswerErrorShown = string.IsNullOrEmpty(PrivateAnswer);//שתהיה מילה הגיונית 
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
            this.NicknameErrorShown = false;// check if already exists
            

        }

        public bool EnableBtnValidation()
        {
            return (this.EmailErrorShown && this.PassErrorShown && this.NicknameErrorShown && this.BdayErrorShown && this.FirstNameErrorShown
                && this.LastNameErrorShown && this.GenderErrorShown && this.UserTypeIDErrorShown && this.FirstNameErrorShown
                && this.LastNameErrorShown && this.UserTypeIDErrorShown && this.PrivateAnswerErrorShown);
        }

        #endregion

        public User MyUser {get;set;}

        public ICommand CountinueCommand => new Command(Continue);
        public ICommand SignUpCommand { get; set; }
        //public Command<string> GetGenderCommand { get; set; }

        public SignUpViewModel()
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
            //GetGenderCommand = new Command<string>((g)=>GenderInput(g));//sending a parameter additionly to the function
        }

        public async void Continue()
        {

            if (gender.Length == 0) 
            {
                this.genderErrorShown = true;
            }
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

        //public async void GenderInput(string g)
        //{
        //    this.gender = g;

        //}
    }
}
