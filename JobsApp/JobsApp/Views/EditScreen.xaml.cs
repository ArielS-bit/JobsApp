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
    public partial class EditScreen : ContentView
    {
        public EditScreen()
        {
            InitializeComponent();
            EditViewModel e = new EditViewModel();
            e.Push += (p) => Navigation.PushAsync(p);
            this.BindingContext = e;
        }
    }
}