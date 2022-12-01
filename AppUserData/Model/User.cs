using System;

namespace AppUserData.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecoundName { get; set; }
        public bool IsCanDelete { get; set; }
        public void Edit(string name, string lastName)
        {
            FirstName = name;
            SecoundName = lastName;
        }
        public void MarkToDelete()
        {
            IsCanDelete = true;
        }
        public void UnMarkToDelete()
        {
            IsCanDelete = false;
        }
        /*public User Search(Guid id)
        {
            User user = null;
            return user;
        }*/
        public User()
        {
            Id = Guid.NewGuid();
            IsCanDelete = false;
        }
    }
}
