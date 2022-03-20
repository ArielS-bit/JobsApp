﻿using System;
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

        public ObservableCollection<SideMenuItem> MyMenu { get; set; }

        public MainTabViewVM()
        {
            MyMenu = new ObservableCollection<SideMenuItem>();

            // MyMenu = GetMenus();
            MyMenu.Add(new SideMenuItem { Name = "Settings", Icon = "SeetingsIcon.png", Command = new Command(TransferToSettings) });
            MyMenu.Add(new SideMenuItem { Name = "About Us", Icon = "AboutIcon.png", Command = new Command(TransferToAbout) });
            MyMenu.Add(new SideMenuItem { Name = "Know Your Rights", Icon = "RightsIcon.png", Command = new Command(TransferToRights) });
            MyMenu.Add(new SideMenuItem { Name = "Sign Out", Icon = "SignOutIcon.png", Command = new Command(TransferToSignOut) });


        }


        // public List<Menu> MyMenu { get; set; }
        private List<SideMenuItem> GetMenus()
        {
            return new List<SideMenuItem>
            {
                new SideMenuItem{Name="Home", Icon="HomeIcon.png"},//IconImageSource="{OnPlatform Android=ic_SerachIcon}"
                new SideMenuItem{Name="Notifications", Icon="bellOffIcon.png"},
                new SideMenuItem{Name="Jobs", Icon="JobsIcon.png"},
                new SideMenuItem{Name="Profile", Icon="ProfileIcon.png"}


            };
        }

        //Transfer to pages functions
        private void TransferToSettings()
        {
            Push?.Invoke(new SettingsScreen());
        }

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

        public event Action<Page> Push;

    }

    public class SideMenuItem
    {
        public string Name { get; set; }
        public string Icon { get; set; }

        public Command Command { get; set; }

    }

}

