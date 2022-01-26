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
    class ProfileViewModel:ViewModelBase
    {
        public event Action<Page> Push;

        #region Propreties
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }


        private string lastName;

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                  
                   
                    OnPropertyChanged("LastName");
                }
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
                OnPropertyChanged("Bday");
            }
        }

       

        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {


                    email = value;
                 
                    OnPropertyChanged("Email");
                }
            }
        }

      

        private string pass;

        public string Pass
        {
            get { return pass; }
            set
            {
                if (pass != value)
                {
                    pass = value;
                  
                    OnPropertyChanged("Pass");

                }
            }
        }
      

        private string nickname;

        public string Nickname
        {
            get { return nickname; }
            set
            {
                if (nickname != value)
                {


                    nickname = value;
                   
                    OnPropertyChanged("Nickname");
                }

            }
        }
     
        private int userTypeID;
        public int UserTypeID
        {
            get { return userTypeID; }
            set
            {
                userTypeID = value;
               
                OnPropertyChanged("UserTypeID");
            }
        }

     
        private string privateAnswer;
        public string PrivateAnswer
        {
            get => privateAnswer;
            set
            {
                privateAnswer = value;
               
                OnPropertyChanged("PrivateAnswer");
            }
        }

        //Ad an image

      



       
        #endregion Properties

        public ProfileViewModel()
        {

            //User u = ((App)Application.Current).CurrentUser;
            //this.FirstName = u.FirstName;
            //this.LastName = u.LastName;
            //this.Gender = u.Gender;
            //this.Bday = u.Birthday;
            //this.Email = u.Email;
            //this.Nickname = u.Nickname;
            //this.Pass = u.Pass;
            //this.UserTypeID = u.UserTypeId;
            //this.PrivateAnswer = u.PrivateAnswer;
            




        }
    }
}
