using Windows.UI.Xaml.Controls;

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
            SecoundName.Text = user.LastName;
            //DataContext = new EditUserDataViewModel();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var user = SelectUser;
            var name = FirstName.Text;
            var lastName = SecoundName.Text;
            if (name != "" && lastName != "")
            {
                user.FirstName = name;
                user.LastName = lastName;
            }
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
