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
    class AddJobOfferViewModel : ViewModelBase
    {
        public event Action<Page> Push;
        public event Action Pop;

        
        public event Action OnAppearing;
        #region Constructor
        public AddJobOfferViewModel()
        {
            JobTitle = "";
            JobOfferDescription = "";
            StartingDate = DateTime.Today;
            EndingDate = DateTime.Today;
            //Category = "";
            IsPrivate = false;
            SelectedEmployee = null;//לבדוק אם הגיע פרמטר אז לשים פה אם לא אז ככה
            MyCategories = new ObservableCollection<string>();
            GetCategories();
            JobOfferImgSrc = DEFAULT_PHOTO_SRC;

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

        private DateTime startingDate;
        public DateTime StartingDate
        {
            get => startingDate;
            set
            {
                startingDate = value;
                OnPropertyChanged("StartingDate");
            }
        }

        private DateTime endingDate;
        public DateTime EndingDate
        {
            get => endingDate;
            set
            {
                endingDate = value;
                OnPropertyChanged("EndingDate");
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
                    if (categories!=null)
                    {
                        PickCategory();
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

        private bool isPrivate;
        public bool IsPrivate
        {
            get { return isPrivate; }
            set
            {
                isPrivate = value;
                OnPropertyChanged("IsPrivate");
            }
        }

        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set 
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }







        #endregion

        #region Validators

        #endregion

        #region ValidationFunctions

        #endregion

        #region Image Source
        private string jobOfferImgSrc;

        public string JobOfferImgSrc
        {
            get => jobOfferImgSrc;
            set
            {
                jobOfferImgSrc = value;
                OnPropertyChanged("JobOfferImgSrc");
            }
        }

        private const string DEFAULT_PHOTO_SRC = "NormalScaleLogo.png";
        #endregion

        #region Commands

        public ICommand AddJobOfferCommand => new Command(AddJobOffer);

        #endregion

        #region Functions
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
        public void OnAppearingFunc()
        {
            OnAppearing?.Invoke();
        }

        private void PickCategory()
        {
            selectedCategory = categories.Where(c => c.CategoryName == category).FirstOrDefault();


        }

        public async void AddJobOffer()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();

            JobOffer MyJobOffer = new JobOffer() { 
                Applied = false,
                CategoryId = selectedCategory.CategoryId, 
                EmployerId = this.currentApp.CurrentUser.UserId, 
                IsPrivate = false, 
                JobOfferDescription = JobOfferDescription, 
                JobTitle = JobTitle,
                NumApplied = 0,
                RequiredEmployees = RequiredEmployees, 
                RequiredAge = RequiredAge,
                JobOfferStatusId = 1,
                StartingDate = StartingDate,
                EndingDate=EndingDate
                 };
             
            JobOffer j = await proxy.AddJobOfferAsync(MyJobOffer);

            if (j == null)
            {
                await Application.Current.MainPage.DisplayAlert("Adding job offer Failed!", "Invalid input", "I'LL FIX IT!");
            }
            else
            {
                //Insert Job Offer Image
                if (imageFileResult != null)
                {
                    bool success = await proxy.UploadImage(new FileInfo()
                    {
                        Name = this.imageFileResult.FullPath

                    }, $"{j.JobOfferId}.jpg", true);

                }
                
                //App theApp = (App)App.Current;
                //theApp.CurrentUser = user;
                await Application.Current.MainPage.DisplayAlert("SUCCESS!", "You've successfully uploaded a job offer", "Yay");

                Pop?.Invoke();
            }

            //Push?.Invoke(new FeedScreen());


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
        #endregion



    }
}
