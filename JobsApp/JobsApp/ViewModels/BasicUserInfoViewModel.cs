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
    class BasicUserInfoViewModel:ViewModelBase
    {
        public event Action<Page> Push;

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string gender;

        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private DateTime bday;

        public DateTime Bday
        {
            get { return bday; }
            set
            {
                bday = value;
                BdayValidation();
                OnPropertyChanged("Bday");
            }
        }

        private bool bdayErrorShown;

        public bool BdayErrorShown
        {
            get => bdayErrorShown;
            set
            {
                bdayErrorShown = value;
                OnPropertyChanged("BdayErrorShown");
            }
        }





        public BasicUserInfoViewModel()
        {

        }

        private void BdayValidation()
        {
            this.BdayErrorShown = (Bday == DateTime.Now || bday.Year>2011);

        }


    }
}
