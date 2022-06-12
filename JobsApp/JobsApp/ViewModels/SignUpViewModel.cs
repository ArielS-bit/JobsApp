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
    public class SignUpViewModel:ViewModelBase
    {
        public event Action<Page> Push;

        #region Propreties
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    FirstNameValidation();
                    CountinueCommand.ChangeCanExecute();
                    OnPropertyChanged("FirstName");
                }
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
                if (lastName != value)
                {
                    lastName = value;
                    LastNameValidation();
                    CountinueCommand.ChangeCanExecute();
                    OnPropertyChanged("LastName");
                }
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
                
                CountinueCommand.ChangeCanExecute();
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
                CountinueCommand.ChangeCanExecute();
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
                if (email != value)
                {


                    email = value;
                    EmailVaidation();
                    SignUpCommand.ChangeCanExecute();
                    OnPropertyChanged("Email");
                }
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
                if (pass != value)
                {
                    pass = value;
                    PassValidation();
                    SignUpCommand.ChangeCanExecute();
                    OnPropertyChanged("Pass");

                }
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
                if (nickname != value)
                {


                    nickname = value;
                    NicknameValidation();
                    SignUpCommand.ChangeCanExecute();
                    OnPropertyChanged("Nickname");
                }

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
               SignUpCommand.ChangeCanExecute();
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
                SignUpCommand.ChangeCanExecute();
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

        private bool employeeQuestionsShown;
        public bool EmployeeQuestionsShown
        {
            get => employeeQuestionsShown;

            set
            {
                employeeQuestionsShown = value;
                EmployeeQuestionsShownValidation();
                
                OnPropertyChanged("EmployeeQuestionsShown");
            }
        } 
        
        private bool employerQuestionsShown;
        public bool EmployerQuestionsShown
        {
            get => employerQuestionsShown;

            set
            {
                employerQuestionsShown = value;
                EmployerQuestionsShownValidation();
                
                OnPropertyChanged("EmployerQuestionsShown");
            }
        }

        private Category selectedCategory;


        private ObservableCollection<string> myCategories;
        public ObservableCollection<string> MyCategories 
        { 
            get => myCategories;
            set
            {
                myCategories = value;
                OnPropertyChanged("MyCategories");
            }
        }

        private string category;
        public string Category
        {
            get => category;

            set
            {
                if (category != value)
                {
                    category = value;
                    PickCategory();
                    OnPropertyChanged("Category");
                }
               
            }
        }

        private List<Category> categories;

        public event Action OnAppearing;

        #endregion Properties

        #region Image Source
        private string userImgSrc;

        public string UserImgSrc
        {
            get => userImgSrc;
            set
            {
                userImgSrc = value;
                OnPropertyChanged("UserImgSrc");
            }
        }
       
        private const string DEFAULT_PHOTO_SRC = "DefualtProfile.png";
        #endregion

        #region Validation Functions
        private void FirstNameValidation()
        {
            this.FirstNameErrorShown = string.IsNullOrEmpty(FirstName); 
        }

        private void LastNameValidation()
        {
            this.LastNameErrorShown = string.IsNullOrEmpty(LastName);
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
            this.BdayErrorShown = Bday.Year > 2011;

        }

        private async void EmailVaidation()
        {
           if(string.IsNullOrEmpty(Email) || !(Email.Contains('@') && email.Contains('.')))
            {
                this.EmailErrorShown = true;
            }
            else //check if it already exists
            {
                this.EmailErrorShown = await EmailIsExist();
            }
            

        }

        public async Task<bool> EmailIsExist()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            bool isExist = await proxy.IsEmailExistAsync(Email);
            return isExist;
        }

        private void PassValidation()
        {
            this.PassErrorShown = (pass.Length < 8);

        }

        private async void NicknameValidation()
        {

            if (nickname.Length == 0 || nickname.Contains(' '))
            {
                this.NicknameErrorShown = true;

            }
            else
            {
                this.NicknameErrorShown = await NicknameIsExist();
            }



        }

        public async Task<bool> NicknameIsExist()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            bool isExist = await proxy.IsExistNickNameAsync(Nickname);
            return isExist;
        }

        

        public void EmployeeQuestionsShownValidation()
        {
            if (this.userTypeID == 3)
            {
                employeeQuestionsShown = true;
            }
        }

        public void EmployerQuestionsShownValidation()
        {
            if (this.userTypeID == 2)
            {
                employerQuestionsShown = true;
            }
        }

        #endregion

        public User MyUser { get; set; }

        public Command CountinueCommand { get; }
        public Command SignUpCommand { get; }
        //public Command<string> GetGenderCommand { get; set; }
        //public Command<string> GetEmployeeInterests { get; set; }
        //public Command<string> GetEmployerInterests { get; set; }


        public SignUpViewModel()
        {
            SignUpCommand = new Command(SignUp, IsSignUpEnabled);
            CountinueCommand = new Command(Continue, IsContinueEnabled);
            this.FirstName = "";
            this.LastName = "";
            this.Nickname = "";
            this.Email = "";
            this.Gender = "Male";
            this.Bday = new DateTime(2010,1,3);
            BdayValidation();
            this.Pass = "";
            this.PrivateAnswer = "";

           
            //this.EmailErrorShown = false;
            //this.FirstNameErrorShown = false;
            
            //this.BdayErrorShown = false;
            //this.LastNameErrorShown = false;
            //this.NicknameErrorShown = false;
            //this.PassErrorShown = false;
            //this.PrivateAnswerErrorShown = false;
            this.UserImgSrc = DEFAULT_PHOTO_SRC;
            this.UserTypeID = 2;
            MyCategories = new ObservableCollection<string>();
            OnAppearing += GetCategories;


            
            //enableBtn = false;

            //Push += NavigateToPage;
            //GetGenderCommand = new Command<string>((g)=>GenderInput(g));//sending a parameter additionly to the function
            //GetEmployeeInterests = new Command<string>((g)=>EmployeeInterests(g));//sending a parameter additionly to the function
            //GetEmployerInterests = new Command<string>((g)=>EmployerInterests(g));//sending a parameter additionly to the function

        }

        public void ChangeBools()
        {
            this.emailErrorShown = false;
            this.firstNameErrorShown = false;
            this.bdayErrorShown = false;
            this.lastNameErrorShown = false;
            this.nicknameErrorShown = false;
            this.passErrorShown = false;
            this.privateAnswerErrorShown = false;
            
        }

        //private async void NavigateToPage(Page obj)
        //{
        //    await currentApp.MainPage.Navigation.PushAsync(obj);
        //}

        public void Continue()
        {

            
            Push?.Invoke(new UserCredentialsScreen(this));

        }

        private bool IsContinueEnabled()
        {
            return !(BdayErrorShown || FirstNameErrorShown || LastNameErrorShown);
            
            
        }

        private bool IsSignUpEnabled()//change to a better algorithem that covers all situations
        {
           return !(NicknameErrorShown || PassErrorShown || UserTypeIDErrorShown || EmailErrorShown);
           
        
        }

        private async void GetCategories()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            categories = await proxy.GetCategories();
            MyCategories = new ObservableCollection<string>();
            foreach(Category category in categories)
            {
                MyCategories.Add(category.CategoryName);

            }

        }
        public void OnAppearingFunc()
        {
            OnAppearing?.Invoke();
        }

        private void PickCategory()
        {
            selectedCategory = categories.Where(c => c.CategoryName == category).FirstOrDefault();


        }

        public async void SignUp()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();

            User MyUser = new User() {FirstName = firstName, LastName = lastName, Birthday = bday, Age=((DateTime.Today-bday).Days)/365, UserTypeId=userTypeID, Profession = Category, Email = email, Gender = gender, Nickname = nickname, Pass = pass, PrivateAnswer = privateAnswer };  
            User u = await proxy.SignUpAsync(MyUser);

            if (u == null)
            {
                await Application.Current.MainPage.DisplayAlert("Sign Up Failed!", "Email or username invalid", "OK");
            }
            else
            {

                ((App)App.Current).CurrentUser = u;
                if (imageFileResult != null) 
                {
                    bool success = await proxy.UploadImage(new FileInfo()
                    {
                        Name = this.imageFileResult.FullPath

                    }, $"{u.UserId}.jpg");
                        
                }
                else
                {
                   //let's decide for the user the defualt profile picture (might be on the server so not needed in that condition)
                }

                //App theApp = (App)App.Current;
                //theApp.CurrentUser = user;
                bool isEmployer = await proxy.IsEmployer(u.UserId);
                if (isEmployer)
                {
                    Push?.Invoke(new EmployerMainTabView());

                }
                else
                {
                    Push?.Invoke(new EmployeeMainTabView());

                }
            }

            //Push?.Invoke(new FeedScreen());

        }

        //public async void EmployeeInterests(string profession)
        //{
        //    //Adding to employee list 
        //}

        //public async void EmployerInterests(string profession)
        //{
        //    //Adding to employer list 
        //}



        ///The following command handle the pick photo button
        FileResult imageFileResult;
        public event Action<ImageSource> SetImageSourceEvent;
        public ICommand PickImageCommand => new Command(OnPickImage);
        public async void OnPickImage()
        {
            FileResult result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
            {
                Title = "Pick a picture"
            });

            if (result != null)
            {
                this.imageFileResult = result;

                var stream = await result.OpenReadAsync();
                ImageSource imgSource = ImageSource.FromStream(() => stream);
                if (SetImageSourceEvent != null)
                    SetImageSourceEvent(imgSource);
            }
        }

        ///The following command handle the take photo button
        public ICommand CameraImageCommand => new Command(OnCameraImage);
        public async void OnCameraImage()
        {
            var result = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions()
            {
                Title = "Take a picture"
            });

            if (result != null)
            {
                this.imageFileResult = result;
                var stream = await result.OpenReadAsync();
                ImageSource imgSource = ImageSource.FromStream(() => stream);
                if (SetImageSourceEvent != null)
                    SetImageSourceEvent(imgSource);
            }
        }

       


    }
}
