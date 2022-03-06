using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;


namespace JobsApp.ViewModels
{
    public class ToolsVM:ViewModelBase
    {
        public ObservableCollection<Menu> MyMenu { get; set; }

        public ToolsVM()
        {
            MyMenu = new ObservableCollection<Menu>();

            //MyMenu = GetMenus();
            MyMenu.Add(new Menu { Name = "Home", Icon = "HomeIcon.png" });
            MyMenu.Add(new Menu { Name = "Notifications", Icon = "bellOffIcon.png" });
            MyMenu.Add(new Menu { Name = "Jobs", Icon = "JobsIcon.png" });
            MyMenu.Add(new Menu { Name = "Profile", Icon = "ProfileIcon.png" });

        }


        //public List<Menu> MyMenu { get; set; }
        //private List<Menu> GetMenus()
        //{
        //    return new List<Menu>
        //    {
        //        new Menu{Name="Home", Icon="HomeIcon.png"},
        //        new Menu{Name="Notifications", Icon="bellOffIcon.png"},
        //        new Menu{Name="Jobs", Icon="JobsIcon.png"},
        //        new Menu{Name="Profile", Icon="ProfileIcon.png"}


        //    };
        //}


    }
    public class Menu
    {
        public string Name { get; set; }
        public string Icon { get; set; }

    }
}

