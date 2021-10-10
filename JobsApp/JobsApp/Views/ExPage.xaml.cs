﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using JobsApp.ViewModels;

namespace JobsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExPage : ContentPage
    {
        public ExPage()
        {
            this.BindingContext = new ExPageViewModel();
            InitializeComponent();
        }
    }
}