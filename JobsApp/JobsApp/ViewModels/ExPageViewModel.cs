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

namespace JobsApp.ViewModels
{
    class ExPageViewModel : INotifyPropertyChanged
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
        

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public ICommand ShowCommand { get; set; }

        public ExPageViewModel()
        {
            str = "Hello World!!!";
            ShowCommand = new Command(OnShow);
        }

        public async void OnShow()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            str = await proxy.ExFuncAsync();
           
        }

       



    }
}

