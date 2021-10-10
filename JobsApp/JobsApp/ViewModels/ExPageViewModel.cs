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
            get
            {
                return str;
            }

            set
            {
                str = value;
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
            ShowCommand = new Command(OnShow);
        }

        public async void OnShow()
        {
            JobsAPIProxy proxy = JobsAPIProxy.CreateProxy();
            str = await proxy.ExFuncAsync();
           
            
        }

       



    }
}

