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
    class WatchJobOfferViewModel:ViewModelBase
    {
        public WatchJobOfferViewModel()
        {
           

        }

        public event Action<Page> Push;

        #region Properties
        //JobOffer that has been selected in the previous page (FeedView)
        private JobOffer selectedJobOffer;
        public JobOffer SelectedJobOffer
        {
            get => selectedJobOffer;
            set 
            {
                selectedJobOffer = value;
                OnPropertyChanged("SelectedJobOffer");
            }
        }


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

        private string category;
        public string Category
        {
            get => category;

            set
            {
                if (category != value)
                {
                    category = value;
                    OnPropertyChanged("Category");
                }

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

        private int numApplied;
        public int NumApplied
        {
            get { return numApplied; }
            set
            {
                numApplied = value;
                OnPropertyChanged("NumApplied");
            }
        }

        private DateTime startingDate;
        public DateTime StartingDate
        {
            get { return startingDate; }
            set
            {
                startingDate = value;
                OnPropertyChanged("StartingDate");
            }
        }

        private DateTime endingDate;
        public DateTime EndingDate
        {
            get { return endingDate; }
            set
            {
                endingDate = value;
                OnPropertyChanged("EndingDate");
            }
        }

        private bool isPrivate;
        public bool IsPrivate
        {
            get => isPrivate;
            set
            {
                isPrivate = value;
                OnPropertyChanged("IsPrivate");
            }
        }


        #endregion

        #region Image Source
        private string jobOfferImgSrc;

        public string JobOfferImgSrc
        {
            get
            {
                return null;
                //User u = ((App)Application.Current).CurrentUser;
                //return u.ImagePath;
            }
            //set
            //{
            //    userImgSrc = value;
            //    OnPropertyChanged("UserImgSrc");
            //}
        }

        private const string DEFAULT_PHOTO_SRC = "HugePicture.png";//DefaultPhoto.png
        #endregion
    }
}

