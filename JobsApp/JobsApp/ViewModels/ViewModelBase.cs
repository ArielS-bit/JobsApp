using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using JobsApp.Services;
using Xamarin.Forms;

namespace JobsApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        JobsAPIProxy proxy;
        protected App currentApp;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       public ViewModelBase()
        {
            currentApp = ((App)Application.Current);
            proxy = JobsAPIProxy.CreateProxy();
        }
    }
}
