using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel.Activation;
using Windows.Networking;

namespace AppUserData.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecoundName { get; set; }
        public void Add(string name, string lastName) {
            FirstName = name;
            SecoundName = lastName;
        }
        public void Edit(string name, string lastName)
        {
            FirstName = name;
            SecoundName = lastName;
        }
        public void Delete(Guid id)
        {
            var currentUser = Search(id);
            //currentUser.Delete();
        }
        public User Search(Guid id)
        {
            User user = null;
            return user;
        }
        public User()
        {
            Id = Guid.NewGuid();
        }
    }
}
