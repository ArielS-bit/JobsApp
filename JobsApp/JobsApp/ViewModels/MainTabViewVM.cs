using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading;
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
    public class MainTabViewVM : ViewModelBase
    {
        #region Image Source
        private string userImgSrc;

        public string UserImgSrc
        {
            get
            {
                User u = ((App)Application.Current).CurrentUser;
                return u.ImagePath;
            }
            //set
            //{
            //    userImgSrc = value;
            //    OnPropertyChanged("UserImgSrc");
            //}
        }

        private const string DEFAULT_PHOTO_SRC = "HugePicture.png";//DefaultPhoto.png
        #endregion
        public ObservableCollection<SideMenuItem> MyMenu { get; set; }

        public MainTabViewVM()
        {
            MyMenu = new ObservableCollection<SideMenuItem>();

            // MyMenu = GetMenus();
            MyMenu.Add(new SideMenuItem { Name = "About Us", Icon = "InfoIcon.png", Command = new Command(TransferToAbout) });
            MyMenu.Add(new SideMenuItem { Name = "Know Your Rights", Icon = "RightsIcon.png", Command = new Command(TransferToRights) });
            MyMenu.Add(new SideMenuItem { Name = "Sign Out", Icon = "SignOutIcon.png", Command = new Command(TransferToSignOut) });


        }


        // public List<Menu> MyMenu { get; set; }
        //private List<SideMenuItem> GetMenus()
        //{
        //    return new List<SideMenuItem>
        //    {
        //        new SideMenuItem{Name="Home", Icon="HomeIcon.png"},//IconImageSource="{OnPlatform Android=ic_SerachIcon}"
        //        new SideMenuItem{Name="Notifications", Icon="bellOffIcon.png"},
        //        new SideMenuItem{Name="Jobs", Icon="JobsIcon.png"},
        //        new SideMenuItem{Name="Profile", Icon="ProfileIcon.png"}


        //    };
        //}

        public ICommand MoveToProfileCommand => new Command(TransferToProfile);

        //Transfer to pages functions
       

        private void TransferToAbout()
        {
            Push?.Invoke(new AboutUsScreen());
        }

        private void TransferToRights()
        {
            Push?.Invoke(new RightsScreen());
        }

        private void TransferToSignOut()
        {
            Push?.Invoke(new SignOutScreen());
        }

        public void TransferToProfile()
        {
            Page p = new ProfileScreen();
            User u = ((App)Application.Current).CurrentUser;
            p.BindingContext = new ProfileViewModel()
            {
                IsEditVisible=true,
                FirstName=u.FirstName,
                LastName=u.LastName,
                Age=u.Age, 
                Bday=u.Birthday, 
                Nickname=u.Nickname, 
                Password=u.Pass, 
                Email=u.Email, 
                FullName=u.FirstName+ " "+u.LastName, 
                Gender=u.Gender

            };
            Push?.Invoke(p);
        }

        public event Action<Page> Push;

    }

    public class SideMenuItem
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public Command Command { get; set; }

    }

}

