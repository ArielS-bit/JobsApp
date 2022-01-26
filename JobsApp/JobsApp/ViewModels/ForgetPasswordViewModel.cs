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
    class ForgetPasswordViewModel : ViewModelBase
    {
        #region Properties
        private string email;

        public string Email
        {
            get { return email; }

            set
            {
                email = value;
                CheckEmailFunc();
                OnPropertyChanged("Email");
            }

        }

        private string newPass;

        public string NewPass
        {
            get { return newPass; }

            set
            {
                newPass = value;
                OnPropertyChanged("NewPass");
            }

        }

        private string petName;

        public string PetName
        {
            get { return petName; }

            set
            {
                petName = value;
                CheckPetNameFunc();
                OnPropertyChanged("PetName");
            }

        }

        private bool isVisibleCorrectEmail;

        public bool IsVisibleCorrectEmail
        {
            get { return isVisibleCorrectEmail; }

            set
            {
                isVisibleCorrectEmail = value;
                OnPropertyChanged("IsVisibleCorrectEmail");
            }

        } 
        
        private bool isVisibleCorrectPetName;

        public bool IsVisibleCorrectPetName
        {
            get { return IsVisibleCorrectPetName; }

            set
            {
                isVisibleCorrectPetName = value;
                OnPropertyChanged("IsVisibleCorrectPetName");
            }

        }

        private string emailError;

        public string EmailError
        {
            get { return EmailError; }

            set
            {
                emailError = value;
                OnPropertyChanged("EmailError");
            }

        }
        private bool emailErrorShown;

        public bool EmailErrorShown
        {
            get { return EmailErrorShown; }

            set
            {
                emailErrorShown = value;
                OnPropertyChanged("EmailErrorShown");
            }

        }

        private string petNameError;

        public string PetNameError
        {
            get { return PetNameError; }

            set
            {
                petNameError = value;
                OnPropertyChanged("PetNameError");
            }

        }
        private bool petNameErrorShown;

        public bool PetNameErrorShown
        {
            get { return PetNameErrorShown; }

            set
            {
                petNameErrorShown = value;
                OnPropertyChanged("PetNameErrorShown");
            }

        }


        #endregion

        public ForgetPasswordViewModel()
        {
            NewPass = "";
            IsVisibleCorrectPetName = false;
            IsVisibleCorrectEmail = false;
            PetName = "";
            EmailErrorShown = false;
            EmailError = "Invalid Email!";
            PetNameErrorShown = false;
            PetNameError = "Invalid Answer";

        }

        public ICommand CheckEmailCommand => new Command(CheckEmailFunc);
        public ICommand CheckPetNameCommand => new Command(CheckPetNameFunc);
        public ICommand SubmitCommand => new Command(Submit);

        public event Action<Page> Push;

        private async void CheckEmailFunc()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            IsVisibleCorrectEmail = await proxy.IsEmailExistAsync(Email);
            if (!IsVisibleCorrectEmail)
            {
                EmailErrorShown = true;              
            }         
        }

        private async void CheckPetNameFunc()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            IsVisibleCorrectPetName = await proxy.IsPetNameExistAsync(email,PetName);
            if (!IsVisibleCorrectEmail)
            {
                PetNameErrorShown = true;
            }
        }

        //private async bool SubmitPermission()
        //{
        //    JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
        //    User u = await proxy.GetUserAsync(Email);
        //    //change password
        //    bool success = await proxy.ChangePassAsync(Email,NewPass);

        //    ((App)App.Current).CurrentUser = u;
           
        //    Push?.Invoke(new MainTabPage());
        //    return success;

        //}

        private void Submit()
        { 

        }




    }
}
