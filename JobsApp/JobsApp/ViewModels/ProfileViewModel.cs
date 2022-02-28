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




        #endregion

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

        private const string DEFAULT_PHOTO_SRC = "HugePicture.png";//DefaultPhoto.png
        #endregion

        public event Action<Page> Push;

        #region Commands


        public ICommand EditCommand => new Command(EditUser);

        #endregion

        public ProfileViewModel()
        {
            User u = ((App)Application.Current).CurrentUser;
            this.UserImgSrc = DEFAULT_PHOTO_SRC;//proxy function that brings the photo via a path using the user ID
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
            this.Age = DateTime.Today.Year - u.Birthday.Year;
            this.EditMode = false;//change here
            //EditCommand = new Command(EditUser);
            this.Connections = 10;//Chnage it
            this.Rating = 0;
          





        }

        public async void EditUser()
        {

            Push?.Invoke(new EditScreen());
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




    }
}
