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
    class ProfileViewModel:ViewModelBase
    {
        #region Properties
        private string firstName;
        public string FirstName
        {
            get{return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
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
                    OnPropertyChanged("LastName");
                }
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
                    OnPropertyChanged("Nickname");
                }
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
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
                    OnPropertyChanged("Email");
                }
            }
        }

        private DateTime bday;
        public DateTime Bday 
        {
            get { return bday; }
            set
            {
                if (bday != value)
                {
                    bday = value;
                    OnPropertyChanged("Bday");
                }
            }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set
            {
                if (gender != value)
                {
                    gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        private int userTypeID;
        public int UserTypeID
        {
            get { return userTypeID; }
            set
            {
                if (userTypeID != value)
                {
                    userTypeID = value;
                    OnPropertyChanged("UserTypeID");
                }
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    age = value;
                    OnPropertyChanged("Age");
                }
            }
        }

        private string privateAnswer;
        public string PrivateAnswer
        {
            get { return privateAnswer; }
            set
            {
                if (privateAnswer != value)
                {
                    privateAnswer = value;
                    OnPropertyChanged("PrivateAnswer");
                }
            }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set
            {
                if (fullName != value)
                {
                    fullName = value;
                    OnPropertyChanged("FullName");
                }
            }
        }

        private int connections;
        public int Connections
        {
            get { return connections; }
            set
            {
                if (connections != value)
                {
                    connections = value;
                    OnPropertyChanged("Connections");
                }
            }
        }

        private bool editMode;
        public bool EditMode
        {
            get { return editMode; }
            set
            {
                if (editMode != value)
                {
                    editMode = value;
                    OnPropertyChanged("EditMode");
                }
            }
        }

        private double rating;
        public double Rating
        {
            get { return rating; }
            set
            {
                if (rating != value)
                {
                    rating = value;
                    OnPropertyChanged("Rating");
                }
            }
        }

        private bool isEditVisible;
        public bool IsEditVisible
        {
            get { return isEditVisible; }
            set
            {

                isEditVisible = value;
                OnPropertyChanged("IsEditVisible");
                
            }
        }






        #endregion

        #region Image Source
        private string userImgSrc;

        public string UserImgSrc
        {
            get
            {
                User u = ((App)Application.Current).CurrentUser;
                return u.ImagePath;
            }
            //set
            //{
            //    userImgSrc = value;
            //    OnPropertyChanged("UserImgSrc");
            //}
        }

        private const string DEFAULT_PHOTO_SRC = "HugePicture.png";//DefaultPhoto.png
        #endregion

        public event Action<Page> Push;

        #region Commands


        public ICommand EditCommand { get; set; }

        #endregion

        public ProfileViewModel()
        {
            User u = ((App)Application.Current).CurrentUser;
            //this.UserImgSrc = DEFAULT_PHOTO_SRC;//proxy function that brings the photo via a path using the user ID

            if (u!=null)
            {
                this.FirstName = u.FirstName;
                this.LastName = u.LastName;
                this.Nickname = u.Nickname;
                this.Gender = u.Gender;
                this.Bday = u.Birthday;
                this.Email = u.Email;
                this.Password = u.Pass;
                this.UserTypeID = u.UserTypeId;
                this.PrivateAnswer = u.PrivateAnswer;
                this.FullName = u.FirstName + " " + u.LastName;
                this.Age = u.Age;
                
                this.EditMode = false;//change here
                //EditCommand = new Command(EditUser);
                this.Connections = 10;//Chnage it
                this.Rating = 1;
                isRefresh = false;
                ContactUserCommand = new Command(ContactWithUser);
                EditCommand = new Command(EditUser);



                //if (currentApp.CurrentUser.UserType.UserTypeName=="Employer" && IsEmployee(directedTo))
                //{
                //    Push?.Invoke(new EmployeeProfileScreen());
                //}
                //if (currentApp.CurrentUser.UserType.UserTypeName == "Employer" && IsEmployer(directedTo))
                //{
                //    Push?.Invoke(new EmployerProfileScreen());

                //}
                //if (currentApp.CurrentUser.UserType.UserTypeName == "Employee" && IsEmployee(directedTo))
                //{
                //    Push?.Invoke(new EmployeeProfileScreen());

                //}
                //if (currentApp.CurrentUser.UserType.UserTypeName == "Employee" && IsEmployer(directedTo))
                //{
                //    Push?.Invoke(new EmployerProfileScreen());

                //}


            }

            //Push?.Invoke(new ErrorScreen());

        }

        private bool isRefresh;
        public bool IsRefresh
        {
            get { return isRefresh; }
            set
            {
                if (IsRefresh != value)
                {
                    isRefresh = value;
                    OnPropertyChanged("IsRefresh");
                }
            }
        }


        private User directedTo;
        public User DirectedTo
        {
            get => directedTo;
            set
            {
                directedTo = value;
                OnPropertyChanged("DirectedTo");
            }
        }

        public async void EditUser()
        {

            //Push?.Invoke(new EditView());
            Page p = new EditView();
            await App.Current.MainPage.Navigation.PushAsync(p);
        }

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

        private bool IsEmployee(User u)
        {
            return false;
        }

        private bool IsEmployer(User u)
        {
            return false;
        }

        public ICommand RefreshCommand => new Command(Refresh);
        private void Refresh()
        {
            GetUpdatedUserInfo();

            IsRefresh = false;
        }

        public void GetUpdatedUserInfo()
        {
            this.FirstName = ((App)Application.Current).CurrentUser.FirstName;
            this.LastName = ((App)Application.Current).CurrentUser.LastName;
            this.Password = ((App)Application.Current).CurrentUser.Pass;
            this.FullName = ((App)Application.Current).CurrentUser.FirstName + " " + ((App)Application.Current).CurrentUser.LastName;

        }

        public ICommand ContactUserCommand { get; set; }

        private async void ContactWithUser()
        {
            await Application.Current.MainPage.DisplayAlert("User's email is shown below:", this.Email, "Alright");

        }


    }
}
