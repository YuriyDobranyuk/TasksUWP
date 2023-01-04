using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using AppDataManager.Model;
using Microsoft.Toolkit.Mvvm;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace AppDataManager.ViewModel
{
    public class AppDataManagerViewModel : ObservableObject 
    {
        ObservableCollection<Model.Secret> _secrets;
        public ObservableCollection<Model.Secret> Secrets
        {
            get { return _secrets; }

            set
            {
                SetProperty(ref _secrets, value);
            }
        }
        public User CurrentUser { get; set; }
        public ICommand IncrementCounterCommand { get; }
        public AppDataManagerViewModel()
        {
            IncrementCounterCommand = new RelayCommand(IncrementCounter);
        }
        private void IncrementCounter()
        {
            //Counter++;
        }
    }
}
