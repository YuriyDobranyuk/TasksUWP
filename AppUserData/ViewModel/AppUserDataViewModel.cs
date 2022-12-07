using AppUserData.Model;
using AppUserData.Services;
using AppUserData.View.Pages;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace AppUserData.ViewModel
{
    public class AppUserDataViewModel : BaseViewModel
    {
        public ObservableCollection<Model.User> Users { get; set; }
        public UserManager UserManager { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public AppUserDataViewModel()
        {
            Users = new ObservableCollection<Model.User>();

            UserManager = new UserManager();
            Users = new ObservableCollection<Model.User>(UserManager.GetUsers());

            AddUserCommand = new LambdaCommand(OnAddUserCommandExecute, CanAddUserCommandExecute);
            EditUserCommand = new LambdaCommand(OnEditUserCommandExecute, CanEditUserCommandExecute);
            SaveUserCommand = new LambdaCommand(OnSaveUserCommandExecute, CanSaveUserCommandExecute);
            DeleteUserCommand = new LambdaCommand(OnDeleteUserCommandExecute, CanDeleteUserCommandExecute);

        }
        private void ClearDataFieldUser()
        {
            FirstName = String.Empty;
            OnPropertyChanged(nameof(FirstName));
            LastName = String.Empty; ;
            OnPropertyChanged(nameof(LastName));
        }
        private void IncludeUserDataInForm(Model.User user)
        {
            FirstName = user.FirstName;
            OnPropertyChanged(nameof(FirstName));
            LastName = user.LastName;
            OnPropertyChanged(nameof(LastName));
        }

        #region Commands
        #region AddUserCommand
        public ICommand AddUserCommand { get; }
        private bool CanAddUserCommandExecute(object p) => true;
        private async void OnAddUserCommandExecute(object p)
        {
            try
            {
                UserManager.AddUser(new Model.User { FirstName = FirstName, LastName = LastName });
                Users = new ObservableCollection<Model.User>(UserManager.GetUsers());
                OnPropertyChanged(nameof(Users));
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
            IncludeUserDataInForm(user);
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
                user.FirstName = FirstName;
                user.LastName = LastName;
                UserManager.UpdateUser(user);
                Users = new ObservableCollection<Model.User>(UserManager.GetUsers());
                OnPropertyChanged(nameof(Users));
                ClearDataFieldUser();
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
                Users.Remove(user);
            }
        }
        #endregion

        #endregion
    }
}
