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
    }
}
