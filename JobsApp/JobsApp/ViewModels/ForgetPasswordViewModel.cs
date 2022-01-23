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

namespace JobsApp.ViewModels
{
    class ForgetPasswordViewModel : ViewModelBase
    {
        #region Properties
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

        #endregion

        public ForgetPasswordViewModel()
        {
            NewPass = "";
            IsVisibleCorrectPetName = false;
            IsVisibleCorrectEmail = false;
            PetName = "";

        }

        //public ICommand CheckEmailCommand => new Command(CheckEmailFunc);
        //public ICommand CheckPetNameFunc => new Command(CheckPetNameFunc);


        //private bool CheckEmailFunc()
        //{
        //    JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
        //    //bool IsEmailExist = proxy.IsEmailExistAsync(Email);


        //}
        
        //private bool CheckPetNameFunc()
        //{
        //    JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
        //    //bool IsEmailExist = proxy.IsPetNameExist(Email);


        //}
    }
}
