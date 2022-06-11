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
    class WatchJobOfferViewModel:ViewModelBase
    {
        public WatchJobOfferViewModel()
        {
            JobOfferEmployees = new ObservableCollection<Employee>();
            GetJobOfferEmployees();
           

        }

        public event Action<Page> Push;

        #region Properties
        //Properties of job offer

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


        //Properties of job offer's employee
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        private string nickname;
        public string Nickname
        {
            get => nickname;
            set
            {
                nickname = value;
                OnPropertyChanged("Nickname");
            }
        }
        private int age;
        public int Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public ObservableCollection<Employee> JobOfferEmployees { get; set; }



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



        #region Functions
        public async void GetJobOfferEmployees()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            List<Employee> employees = await proxy.GetJobOfferEmployeesAsync(selectedJobOffer.JobOfferId);
            foreach (Employee e in employees)
            {
                JobOfferEmployees.Add(e);
            }


        }

        #endregion
    }
}

