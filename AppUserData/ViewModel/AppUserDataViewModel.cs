using AppUserData.Common.Enums;
using AppUserData.Model;
using AppUserData.Services;
using AppUserData.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppUserData.ViewModel
{
    public class AppUserDataViewModel : BaseViewModel
    {
        ObservableCollection<Model.User> _users;
        public ObservableCollection<Model.User> Users {
            get { return _users; }

            set
            {
                if (value != _users)
                {
                    _users = value;
                    OnPropertyChanged();
                }
            }
        }
        public UserManager UserManager { get; set; }
        string _firstName;
        public string FirstName {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged();
                }
            } 
        }
        string _lastName;
        public string LastName 
        {
            get { return _lastName; }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public AppUserDataViewModel()
        {
            UserManager = new UserManager();
            Users = new ObservableCollection<Model.User>(UserManager.GetUsers());
            
            AddUserCommand = new LambdaCommand(OnAddUserCommandExecute, CanAddUserCommandExecute);
            EditUserCommand = new LambdaCommand(OnEditUserCommandExecute, CanEditUserCommandExecute);
            SaveUserCommand = new LambdaCommand(OnSaveUserCommandExecute, CanSaveUserCommandExecute);
            DeleteUserCommand = new LambdaCommand(OnDeleteUserCommandExecute, 
                CanDeleteUserCommandExecute);
            ChangeLangCommand = new LambdaCommand(OnChangeLangCommandExecute,
                CanChangeLangCommandExecute);
        }
        private void ClearDataFieldUser()
        {
            FirstName = String.Empty;
            LastName = String.Empty;
        }
       
        #region Commands
        #region AddUserCommand
        public ICommand AddUserCommand { get; }
        private bool CanAddUserCommandExecute(object p) => true;
        private async void OnAddUserCommandExecute(object p)
        {
            try
            {
                UserManager.AddUser(new Model.User { FirstName = FirstName,
                    LastName = LastName,
                    UserSettings = new UserSettings { CanNotEdit = true, 
                        VisibilityEditButton = TypeVisibility.Visible.ToString(), 
                        VisibilitySaveButton = TypeVisibility.Collapsed.ToString()
                    }});
                Users = new ObservableCollection<Model.User>(UserManager.GetUsers());
                ClearDataFieldUser();
            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                await messageDialog.ShowAsync();
            }
        }
        #endregion
        
        #region EditUserCommand
        public ICommand EditUserCommand { get; }
        private bool CanEditUserCommandExecute(object p) 
        {
            var user = p as Model.User;
            return user != null;
        }
        private void OnEditUserCommandExecute(object p)
        {
            var user = p as Model.User;
            UserManager.EditUser(user);
            Users = new ObservableCollection<Model.User>(UserManager.GetUsers());
        }
        #endregion
        #region SaveUserCommand
        public ICommand SaveUserCommand { get; }
        private bool CanSaveUserCommandExecute(object p) => true;
        private async void OnSaveUserCommandExecute(object p)
        {
            try
            {
                var user = p as Model.User;
                UserManager.UpdateUser(user);
                Users = new ObservableCollection<Model.User>(UserManager.GetUsers());
            }
            catch (Exception ex)
            {
                MessageDialog messageDialog = new MessageDialog(ex.Message);
                await messageDialog.ShowAsync();
            }
        }
        #endregion
        #region DeleteUserCommand
        public ICommand DeleteUserCommand { get; }
        private bool CanDeleteUserCommandExecute(object p)
        {
            return p != null;
        }
        private async void OnDeleteUserCommandExecute(object p)
        {
            var user = p as Model.User;
            DeleteUserDialog deleteUserDialog = new DeleteUserDialog();
            var result = await deleteUserDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                UserManager.DeleteUser(user);
                Users = new ObservableCollection<Model.User>(UserManager.GetUsers());
            }
        }
        #endregion
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
				rootFrame.CacheSize = 0;
				Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
				Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
				rootFrame.Navigate(typeof(MainPage));
			}
			catch (Exception ex)
			{
				MessageDialog messageDialog = new MessageDialog(ex.Message);
				await messageDialog.ShowAsync();      
			}
		}
        #endregion

        #endregion
    }
}
