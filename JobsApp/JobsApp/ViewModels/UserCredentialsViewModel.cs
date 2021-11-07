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
    class UserCredentialsViewModel:ViewModelBase
    {
        private int userTypeID;

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                EmailVaidation();
                OnPropertyChanged("Email");
            }
        }

        private bool emailErrorShown;

        public bool EmailErrorShown
        {
            get => emailErrorShown;
            set
            {
                emailErrorShown = value;
                OnPropertyChanged("EmailErrorShown");
            }
        }

        private string pass;

        public string Pass
        {
            get { return pass; }
            set
            {
                pass = value;
                EmailVaidation();
                OnPropertyChanged("Pass");
            }
        }

        private bool passErrorShown;

        public bool PassErrorShown
        {
            get => passErrorShown;
            set
            {
                passErrorShown = value;
                OnPropertyChanged("PassErrorShown");
            }
        }

        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set
            {
                nickname = value;
                EmailVaidation();
                OnPropertyChanged("Nickname");
            }
        }
        private bool nicknameErrorShown;

        public bool NicknameErrorShown
        {
            get => nicknameErrorShown;
            set
            {
                nicknameErrorShown = value;
                OnPropertyChanged("NicknameErrorShown");
            }
        }

        public int UserTypeID
        {
            get { return userTypeID; }
            set
            {
                userTypeID = value;
                OnPropertyChanged("UserTypeID");
            }
        }

        

        public event Action<Page> Push;



        public UserCredentialsViewModel()
        {
        }

        private void EmailVaidation()
        {
            this.EmailErrorShown = (string.IsNullOrEmpty(Email) || !(Email.Contains('@') && email.Contains('.')));

        }
    }
}
