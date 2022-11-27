using AppUserData.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AppUserData.ViewModel
{
    public class AppUserDataViewModel : BaseViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public string FirstName { get; set; }
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
            for (var i=0; i <=6; i++)
            {
                var user = new User() 
                { 
                    FirstName = "User " + i.ToString(),
                    SecoundName = "LastName " + i.ToString(),
                };
                Users.Add(user);
            }
            
        }
    }
}
