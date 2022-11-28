using AppUserData.Model;
using AppUserData.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AppUserData.ViewModel
{
    public class AppUserDataViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
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
            Users = new ObservableCollection<User>();

            AddUserCommand = new LambdaCommand(OnAddUserCommandExecute, CanAddUserCommandExecute);
            EditUserCommand = new LambdaCommand(OnEditUserCommandExecute, CanEditUserCommandExecute);
            CanEditUserCommand = new LambdaCommand(OnCanEditUserCommandExecute, CanCanEditUserCommandExecute);
            DeleteUserCommand = new LambdaCommand(OnDeleteUserCommandExecute, CanDeleteUserCommandExecute);

            for (var i=0; i <=3; i++)
            {
                var user = new User() 
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
                var user = new User
                {
                    FirstName = Name,
                    SecoundName = LastName
                };
                Users.Add(user);
                ClearDataFieldUser();
            }
        }
        #endregion
        #region CanEditUserCommand
        public ICommand CanEditUserCommand { get; }
        private bool CanCanEditUserCommandExecute(object p) => true;
        private void OnCanEditUserCommandExecute(object p)
        {
            var user = p as User;
            user.Edit(Name, LastName);
            ClearDataFieldUser();
        }
        #endregion
        #region EditUserCommand
        public ICommand EditUserCommand { get; }
        private bool CanEditUserCommandExecute(object p) => true;
        private void OnEditUserCommandExecute(object p)
        {
            if (p != null)
            {
                var user = p as User;
                Name = user.FirstName;
                LastName = user.SecoundName;
            }
        }
        #endregion
        #region DeleteUserCommand
        public ICommand DeleteUserCommand { get; }
        private bool CanDeleteUserCommandExecute(object p) => true;
        private void OnDeleteUserCommandExecute(object p)
        {
            var user = p as User;
            Users.Remove(user);
        }
        #endregion

        #endregion
    }
}
