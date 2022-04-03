﻿using System;
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
    class EmployerFeedViewModel:ViewModelBase
    {
        public EmployerFeedViewModel()
        {

        }

        public event Action<Page> Push;
    }
}
