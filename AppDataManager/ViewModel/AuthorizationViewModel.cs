using AppDataManager.Model;
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

namespace AppDataManager.ViewModel
{
    public class AuthorizationViewModel : ObservableValidator
    {
        private string email;
        private string masterPassword;
        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        [EmailAddress]
        [CustomValidation(typeof(AuthorizationViewModel), nameof(ValidateEmail))]
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
                new RelayCommand<object>((par) => OnChangePageAuthRegCommandExecute(par), 
                (p)=> CanChangePageAuthRegCommandExecute(p));
        }

        public static ValidationResult ValidateEmail(string name, ValidationContext context)
        {
            AuthorizationViewModel instance = (AuthorizationViewModel)context.ObjectInstance;
            //bool isValid = instance.service.Validate(name);
            bool isValid = true;
            var errors = instance.GetErrors(name);

            if (isValid)
            {
                return ValidationResult.Success;
            }

            ValidationResult validationResult = new ValidationResult("The name was not validated by the fancy service");
            return validationResult;
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
