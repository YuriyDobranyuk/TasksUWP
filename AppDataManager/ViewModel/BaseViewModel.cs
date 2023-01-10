using AppDataManager.View.Pages;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using AppUserData.View.Pages;
using Windows.Globalization;

namespace AppDataManager.ViewModel
{
    public class BaseViewModel : ObservableValidator
    {
        public string resourceName = "My App"; //"AppDataManager"

        public BaseViewModel() 
        {
            ChangeLangCommand = new RelayCommand<object>((p) => OnChangeLangCommandExecute(p),
                (p) => CanChangeLangCommandExecute(p));
            
            ChangePageAuthRegCommand =
                new RelayCommand<object>((p) => OnChangePageAuthRegCommandExecute(p),
                (p) => CanChangePageAuthRegCommandExecute(p));
        }

        #region Commands
        #region ChangeLangCommand
        public ICommand ChangeLangCommand { get; }
        private bool CanChangeLangCommandExecute(object p) => true;
        private async void OnChangeLangCommandExecute(object p)
        {
            try
            {
                var lang = p as string;
                ApplicationLanguages.PrimaryLanguageOverride = lang;
                var rootFrame = Window.Current.Content as Frame;
                Type currentPageType = rootFrame.SourcePageType;
                rootFrame.CacheSize = 0;
                Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
                Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
                rootFrame.Navigate(currentPageType);
            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                await messageDialog.ShowAsync();
            }
        }
        #endregion

        #region ChangePageAuthRegCommand
        public ICommand ChangePageAuthRegCommand { get; }
        private bool CanChangePageAuthRegCommandExecute(object p) => true;
        private void OnChangePageAuthRegCommandExecute(object p)
        {
            var namePage = (string)p;
            //var navigationPage = (Page)p;
            //var navigationPageType = typeof(navigationPage);

            Type navigationPageType;
            if (namePage == "RegistrationPage")
            {
                navigationPageType = typeof(RegistrationPage);
            }
            else
            {
                navigationPageType = typeof(AuthorizationPage);
            }

            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content != null)
            {
                rootFrame.Navigate(navigationPageType);
            }
            else
            {
                rootFrame.Navigate(typeof(MainPage));
            }
        }
        #endregion

        #endregion
    }
}
