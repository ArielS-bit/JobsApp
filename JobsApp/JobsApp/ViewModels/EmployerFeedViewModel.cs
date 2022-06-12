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
    class EmployerFeedViewModel:ViewModelBase
    {

        public EmployerFeedViewModel()
        {
            JobOffersList = new ObservableCollection<JobOffer>();
            CreateJobOffersList();
            isRefresh = false;
            JobTitle = "";
            JobOfferDescription = "";
            Category = "";
            

        }


        public event Action<Page> Push;
        public event Action Pop;
        public event Action ClearSelection;
       

        #region Properties

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


        public ObservableCollection<JobOffer> JobOffersList { get; set; }


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



        #endregion

        private async void CreateJobOffersList()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            List<JobOffer> m = await proxy.GetAllJobOffersAsync(currentApp.CurrentUser.UserId);
            foreach (JobOffer j in m)
            {
                JobOffersList.Add(j);
            }
        }

        #region Commands and functions 

        public ICommand RefreshCommand => new Command(Refresh);
        private void Refresh()
        {
            JobOffersList.Clear();
            
            CreateJobOffersList();

            IsRefresh = false;
        }

        public ICommand SelectionChanged => new Command<JobOffer>(OnSelectionChanged);

        private void OnSelectionChanged(JobOffer j)
        {
            Page w = new WatchJobOfferScreen();
            w.BindingContext = new WatchJobOfferViewModel()
            {
                SelectedJobOffer = j,
                JobTitle = j.JobTitle,
                JobOfferDescription=j.JobOfferDescription,
                EndingDate=j.EndingDate,
                StartingDate=j.StartingDate,
                Category=j.Category.CategoryName,
                IsPrivate=j.IsPrivate,
                RequiredEmployees=(int)j.RequiredEmployees,
                RequiredAge=(int)j.RequiredAge,
                NumApplied=j.NumApplied
                
            };
            Push?.Invoke(w);



        }

        public ICommand NavigateToAddJobOfferCommand => new Command(NavigateToAddJobOffer);
        private void NavigateToAddJobOffer()
        {
            Push?.Invoke(new AddJobOffer());
            if (ClearSelection != null)
            {
                ClearSelection();
            }
        }

        #endregion


    }
}
