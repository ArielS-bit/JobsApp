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
    public partial class AddJobOffer : ContentPage
    {
        public AddJobOffer()
        {
            InitializeComponent();
            AddJobOfferViewModel a = new AddJobOfferViewModel();
            this.BindingContext = a;
            a.Push += (p) => Navigation.PushAsync(p);
            a.Pop += () => Navigation.PopAsync();

            var professionsList = new List<string>();
            professionsList.Add("Dog Walking");
            professionsList.Add("Babysitter");
            professionsList.Add("Other");
            //Add using this list on the DB


            var picker = new Picker { Title = "Select a profession", TitleColor = Color.Red };
            picker.ItemsSource = professionsList;
        }

        protected override void OnAppearing()
        {
            ((AddJobOfferViewModel)this.BindingContext).OnAppearingFunc();
        }
    }
}