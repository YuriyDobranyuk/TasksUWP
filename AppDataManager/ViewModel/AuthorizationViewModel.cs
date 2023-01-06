using AppDataManager.Model;
using AppDataManager.View.Pages;
using AppUserData.View.Pages;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Windows.Networking;
using Windows.Security.Credentials;
using Windows.UI.Xaml.Controls;

namespace AppDataManager.ViewModel
{
    public class AuthorizationViewModel : ObservableValidator
    {
        private string email;
        private string masterPassword;
        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        [EmailAddress]
        public string Email {
            get => email;
            set => SetProperty(ref email, value, true);
        }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string MasterPassword {
            get => masterPassword;
            set => SetProperty(ref masterPassword, value, true);
        }

        public User CurrentUser { get; set; }

        //AuthorizeUserCommand
        public AuthorizationViewModel()
        {
            //UserManager = new UserManager();
            //Users = new ObservableCollection<Model.User>(UserManager.GetUsers());

            AuthorizeUserCommand = 
                new RelayCommand(OnAuthorizeUserCommandExecute, CanAuthorizeUserCommandExecute);
            ChangePageAuthRegCommand = 
                new RelayCommand<object>((p) => OnChangePageAuthRegCommandExecute(p), 
                (p)=> CanChangePageAuthRegCommandExecute(p));
        }

        private string resourceName = "My App";
        private string defaultUserName = "test@rest.com";

        private async void Login()
        {
            var loginCredential = GetCredentialFromLocker();

            if (loginCredential != null)
            {
                loginCredential.RetrievePassword();
                if (loginCredential.Password.Equals(MasterPassword))
                {
                    MessageDialog messageDialog = new MessageDialog("The user is authorize in the app.");
                    await messageDialog.ShowAsync();

                    //Frame.Navigate(typeof(MainPage));
                }
                else
                {
                    MessageDialog messageDialog = new MessageDialog("Your password isn`t correct.");
                    await messageDialog.ShowAsync();
                }
            }
            else
            {
                MessageDialog messageDialog = new MessageDialog("This user isn`t registrated in this app.");
                await messageDialog.ShowAsync();
                //loginCredential = GetLoginCredentialUI();
            }

            
            //AppLogin(loginCredential.UserName, loginCredential.Password);
        }


        private Windows.Security.Credentials.PasswordCredential GetCredentialFromLocker()
        {
            Windows.Security.Credentials.PasswordCredential credential = null;

            var vault = new Windows.Security.Credentials.PasswordVault();

            IReadOnlyList<PasswordCredential> credentialList = null;

            try
            {
                credentialList = vault.FindAllByResource(resourceName);
            }
            catch (Exception)
            {
                return null;
            }

            if (credentialList.Count > 0)
            {
                var credentialUser = credentialList.Where(x => x.UserName == Email).FirstOrDefault();
                if (credentialUser != null)
                {
                    credential = vault.Retrieve(resourceName, defaultUserName);
                }
                else
                {
                    credential = credentialUser;
                }
            }

            return credential;
        }




        #region Commands
        #region AuthorizeUserCommand
        public ICommand AuthorizeUserCommand { get; }
        private bool CanAuthorizeUserCommandExecute() => true;
        private async void OnAuthorizeUserCommandExecute()
        {
            try
            {
                var ps = this.MasterPassword;

                /*var vault = new Windows.Security.Credentials.PasswordVault();
                vault.Add(new Windows.Security.Credentials.PasswordCredential(
                    "My App", Email, MasterPassword));*/

                Login();


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

        #region ChangePageAuthRegCommand
        public ICommand ChangePageAuthRegCommand { get; }
        private bool CanChangePageAuthRegCommandExecute(object p) => true;
        private async void OnChangePageAuthRegCommandExecute(object p)
        {
            var obj = this;
            try
            {
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
