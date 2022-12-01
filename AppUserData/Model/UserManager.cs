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
            user.FirstName = u.FirstName;
            user.LastName = u.LastName;
        }
    }
}
