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
    class AddJobOfferViewModel : ViewModelBase
    {
        #region Constructor
        public AddJobOfferViewModel()
        {

        }
        #endregion


        #region Properties
        private string jobTitle;
        public string JobTitle
        {
            get { return jobTitle; }
            set
            {
                jobTitle = value;
                OnPropertyChanged("JobTitle");
            }
        }

        private string jobOfferDescription;
        public string JobOfferDescription
        {
            get { return jobOfferDescription; }
            set
            {
                jobOfferDescription = value;
                OnPropertyChanged("JobOfferDescription");
            }
        }
        public event Action<Page> Push;

        private string profession;
        public string Profession
        {
            get { return profession; }
            set
            {
                profession = value;
                OnPropertyChanged("Profession");
            }
        }

        //Must be from this age and above
        private int requiredAge;
        public int RequiredAge
        {
            get { return requiredAge; }
            set
            {
                requiredAge = value;
                OnPropertyChanged("RequiredAge");
            }
        }

        private int requiredEmployees;
        public int RequiredEmployees
        {
            get { return requiredEmployees; }
            set
            {
                requiredEmployees = value;
                OnPropertyChanged("RequiredEmployees");
            }
        }



        #endregion

        #region Validators

        #endregion

        #region ValidationFunctions

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

        #region Commands

        public ICommand LoginCommand => new Command(AddJobOffer);

        #endregion

        #region Functions

        public async void AddJobOffer()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();

            JobOffer MyJobOffer = new JobOffer() {Applied = false, Category= profession, Profession = Profession, CategoryId=3, Employer = this.currentApp.CurrentUser.UserId, IsPrivate=false, JobOfferDescription = JobOfferDescription, JobTitle=JobTitle, NumApplied = RequiredEmployees, RequiredAge = RequiredAge};
             u = await proxy.SignUpAsync(MyUser);

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
                Push?.Invoke(new MainTabView());
            }

            //Push?.Invoke(new FeedScreen());


        }
        #endregion



    }
}
