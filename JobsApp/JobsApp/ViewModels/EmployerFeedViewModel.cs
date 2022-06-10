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
            MyCategories = new ObservableCollection<string>();
            OnAppearing += GetCategories;
            JobTitle = "";
            JobOfferDescription = "";
            Category = "";
            JobOfferID = 0;
            

        }



        public event Action<Page> Push;
        public event Action Pop;
        public event Action OnAppearing;

        public void OnAppearingFunc()
        {
            OnAppearing?.Invoke();
        }

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

        
      
        public ObservableCollection<string> MyCategories { get; set; }

        private int categoryID;
        public int CategoryID
        {
            get => categoryID;

            set
            {
                if (categoryID != value)
                {
                    categoryID = value;
                    //if (categories != null)
                    //{
                    //    PickCategory();
                    //}

                    OnPropertyChanged("CategoryID");
                }

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
                    if (categories != null)
                    {
                        CategoryID = JobOffersList.Where(j=> j.JobOfferId==jobOfferID).FirstOrDefault().CategoryId;
                        GetCategoryName();
                    }
                    else
                    {
                        Category = "Unable to load specific category, try again later!";
                    }

                    OnPropertyChanged("Category");
                }

            }
        }

        private List<Category> categories;



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
        private int jobOfferID;
        public int JobOfferID
        {
            get { return jobOfferID; }
            set
            {
                jobOfferID = value;
                OnPropertyChanged("JobOfferID");
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
                PreSelectedJobOffer = j
            };
            Push?.Invoke(w);



        }

        public ICommand NavigateToAddJobOfferCommand => new Command(NavigateToAddJobOffer);
        private void NavigateToAddJobOffer()
        {
            Push?.Invoke(new AddJobOffer());
        }

        #endregion

        private async void GetCategories()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            categories = await proxy.GetCategories();
            MyCategories = new ObservableCollection<string>();
            foreach (Category category in categories)
            {
                MyCategories.Add(category.CategoryName);

            }

        }
        

        private void GetCategoryName()
        {
            
            Category = categories.Where(c => c.CategoryId == categoryID).FirstOrDefault().CategoryName;
            

        }



    }
}
