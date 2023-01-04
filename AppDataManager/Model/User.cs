using System;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace AppDataManager.Model
{
    public class User : ObservableObject
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  
        
        //public string ConfirmPassword { get; set; }    

        //public UserSettings UserSettings { get; set; }

    }
}
