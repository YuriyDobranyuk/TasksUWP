using AppUserData.Common.Enums;
using System.Collections.Generic;
using System.Linq;

namespace AppUserData.Model
{
    public class UserManager
    {
        private List<User> Users { get; set; } = new List<User>();

        public List<User> GetUsers()
        {
            return Users;
        }

        public void AddUser(User user)
        {
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.LastName))
            {
                throw new System.Exception("FirstName and LastName are required.");
            }

            Users.Add(user);
        }

        public void EditUser(User u)
        {
            var user = Users.FirstOrDefault(x => x.Id == u.Id);
            if (user != null)
            {
                user.UserSettings.CanNotEdit = false;
                user.UserSettings.VisibilityEditButton = TypeVisibility.Collapsed.ToString();
                user.UserSettings.VisibilitySaveButton = TypeVisibility.Visible.ToString();
            }
        }
        public void DeleteUser(User user)
        {
            Users.Remove(user);
        }

        public void UpdateUser(User u)
        {
            if (string.IsNullOrEmpty(u.FirstName) || string.IsNullOrEmpty(u.LastName))
            {
                throw new System.Exception("FirstName and LastName are required.");
            }
            var user = Users.FirstOrDefault(x => x.Id == u.Id);
            if (user != null)
            {
                user.FirstName = u.FirstName;
                user.LastName = u.LastName;
                user.UserSettings.CanNotEdit = true;
                user.UserSettings.VisibilityEditButton = TypeVisibility.Visible.ToString();
                user.UserSettings.VisibilitySaveButton = TypeVisibility.Collapsed.ToString();
            }
        }

    }
}
