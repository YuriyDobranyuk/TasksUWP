using AppUserData.View.Pages;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppDataManager.ViewModel
{
    internal class RegistrationViewModel : BaseViewModel
    {
        private string email;
        private string masterPassword;
        private string confirmMasterPassword;
        private bool isValidPassword = false;

        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        [EmailAddress]
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value, true);
        }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string MasterPassword
        {
            get => masterPassword;
            set => SetProperty(ref masterPassword, value, true);
        }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string ConfirmMasterPassword
        {
            get => confirmMasterPassword;
            set => SetProperty(ref confirmMasterPassword, value, true);
        }
        public RegistrationViewModel()
        {
            RegistrationUserCommand =
                new RelayCommand(OnRegistrationUserCommandExecute, CanRegistrationUserCommandExecute);
        }

        #region Commands
        #region RegistrationUserCommand
        public ICommand RegistrationUserCommand { get; }
        private bool CanRegistrationUserCommandExecute() => true;
        private async void OnRegistrationUserCommandExecute()
        {
            try
            {
                var ps = this.MasterPassword;

                /*var vault = new Windows.Security.Credentials.PasswordVault();
                vault.Add(new Windows.Security.Credentials.PasswordCredential(
                    "My App", Email, MasterPassword));*/

                //Login();


                /*UserManager.AddUser(new Model.User
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    UserSettings = new UserSettings
                    {
                        CanNotEdit = true,
                        VisibilityEditButton = TypeVisibility.Visible.ToString(),
                        VisibilitySaveButton = TypeVisibility.Collapsed.ToString()
                    }
                });
                Users = new ObservableCollection<Model.User>(UserManager.GetUsers());
                ClearDataFieldUser();*/
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
