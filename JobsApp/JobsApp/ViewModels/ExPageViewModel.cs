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

namespace JobsApp.ViewModels
{
    class ExPageViewModel : ViewModelBase
    {
        private string str;
        
        public string Str
        {
            get => str;
            

            set
            {
                if (value != str)
                {
                    str = value;
                    OnPropertyChanged("Str");
                }
            }

        }
       
        public ICommand ShowCommand => new Command(OnShow);

      


        public ExPageViewModel()
        {
            Str = "Hello World!!!";
            
        }

        public async void OnShow()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            Str = await proxy.ExFuncAsync();

        }

    }
}

