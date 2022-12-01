using AppUserData.Model;
using AppUserData.Services;
using AppUserData.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.System;
using Windows.UI.Xaml.Controls;

namespace AppUserData.ViewModel
{
    public class AppUserDataViewModel : BaseViewModel
    {
        public ObservableCollection<Model.User> Users { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FormAddUserLabel { get; }
        public string FirstNameLabel { get; }
        public string SecoundNameLabel { get; }

        public AppUserDataViewModel()
        {
            FormAddUserLabel = "Add user:";
            FirstNameLabel = "Enter name:";
            SecoundNameLabel = "Enter last name:";
            Users = new ObservableCollection<Model.User>();

            AddUserCommand = new LambdaCommand(OnAddUserCommandExecute, CanAddUserCommandExecute);
            EditUserCommand = new LambdaCommand(OnEditUserCommandExecute, CanEditUserCommandExecute);
            CanEditUserCommand = new LambdaCommand(OnCanEditUserCommandExecute, CanCanEditUserCommandExecute);
            DeleteUserCommand = new LambdaCommand(OnDeleteUserCommandExecute, CanDeleteUserCommandExecute);

            for (var i = 0; i <= 3; i++)
            {
                var user = new Model.User()
                {
                    FirstName = "User " + i.ToString(),
                    SecoundName = "LastName " + i.ToString(),
                };
                Users.Add(user);
            }

        }
        private void ClearDataFieldUser()
        {
            /*Name = "";
            LastName = "";*/
        }

        #region Commands
        #region AddUserCommand
        public ICommand AddUserCommand { get; }
        private bool CanAddUserCommandExecute(object p) => true;
        private void OnAddUserCommandExecute(object p)
        {
            if (Name != null & Name != "" & LastName != null & LastName != "")
            {
                var user = new Model.User
                {
                    FirstName = Name,
                    SecoundName = LastName
                };
                Users.Add(user);
                ClearDataFieldUser();
            }
        }
        #endregion
        #region CanEditUserCommand #not use#
        public ICommand CanEditUserCommand { get; }
        private bool CanCanEditUserCommandExecute(object p) => true;
        private void OnCanEditUserCommandExecute(object p)
        {
            var user = p as Model.User;
            user.Edit(Name, LastName);
            ClearDataFieldUser();
        }
        #endregion
        #region EditUserCommand
        public ICommand EditUserCommand { get; }
        private bool CanEditUserCommandExecute(object p) 
        {
            var user = p as Model.User;
            return user != null;
        }
        private async void OnEditUserCommandExecute(object p)
        {
            var user = p as Model.User;
            EditUserDialog editUserDialog = new EditUserDialog(user);
            await editUserDialog.ShowAsync();

            user.FirstName = "yura";
            user.SecoundName = "det";
            OnPropertyChanged(nameof(Users));


            /*if (p != null)
            {
                var user = p as User;
                Name = user.FirstName;
                LastName = user.SecoundName;
            }*/
        }
        #endregion
        #region DeleteUserCommand
        public ICommand DeleteUserCommand { get; }
        private bool CanDeleteUserCommandExecute(object p)
        {
            var user = p as Model.User;
            return user != null;
        }
        private async void OnDeleteUserCommandExecute(object p)
        {
            var user = p as Model.User;
            DeleteUserDialog deleteUserDialog = new DeleteUserDialog(user);
            await deleteUserDialog.ShowAsync();

            if (user.IsCanDelete)
            {
                Users.Remove(user);
            }
        }
        #endregion

        #endregion
    }
}
