using AppUserData.Services;
using AppUserData.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppUserData.ViewModel
{
    internal class EditUserDataViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string TitleFormEdit { get; }
        public string FirstNameLabel { get; }
        public string SecoundNameLabel { get; }
        public EditUserDataViewModel()
        {
            TitleFormEdit = "Change user name or lastname";
            FirstNameLabel = "Enter name:";
            SecoundNameLabel = "Enter last name:";
            
            EditUserCommand = new LambdaCommand(OnEditUserCommandExecute, CanEditUserCommandExecute);
            
        }

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

            /*if (p != null)
            {
                var user = p as User;
                Name = user.FirstName;
                LastName = user.SecoundName;
            }*/
        }
        #endregion
    }
}
