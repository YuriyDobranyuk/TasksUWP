using AppUserData.Model;
using AppUserData.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppUserData.View.Pages
{
    public sealed partial class EditUserDialog : ContentDialog
    {
        private Model.User SelectUser { get; set; }

        public EditUserDialog(Model.User user)
        {
            SelectUser = user;
            this.InitializeComponent();
            FirstName.Text = user.FirstName;
            SecoundName.Text = user.SecoundName;
            DataContext = new EditUserDataViewModel();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var user = SelectUser;
            var name = FirstName.Text;
            var lastName = SecoundName.Text;
            if (name != "" && lastName != "")
            {
                user.FirstName = name;
                user.SecoundName = lastName;
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
