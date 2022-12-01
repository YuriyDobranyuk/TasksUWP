using AppUserData.Model;
using Windows.UI.Xaml.Controls;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppUserData.View.Pages
{
    public sealed partial class DeleteUserDialog : ContentDialog
    {
        private User SelectUser{get; set;}
        public DeleteUserDialog(User user)
        {
            SelectUser = user;
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            SelectUser.MarkToDelete();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            SelectUser.UnMarkToDelete();
        }
    }
}
