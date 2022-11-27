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

        #region Commands
        #region AddUserCommand
        public ICommand AddUserCommand { get; }
        private bool CanAddUserCommandExecute(object p) => true;
        private void OnAddUserCommandExecute(object p)
        {
            var user = new User
            {
                FirstName = Name,
                SecoundName = LastName
            };
            Users.Add(user);

            /*var figure = p as Figure;
            var nameFigure = figure.Name;

            figure.AddTimerFigure();

            figure.Move();

            figure.AddFigureToManagerFigure();

            Figures.Add(figure);
            FiguresShape.Add(figure.Shape);

            ResetParameters(nameFigure);*/


        }
        #endregion
        #endregion
    }
}
