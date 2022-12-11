using System;

namespace AppUserData.Model
{
    public class User
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserSettings UserSettings { get; set; }
       
    }
}
