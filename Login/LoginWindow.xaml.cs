using System.Windows;

using LibDbOperations.Controller;
using LibDbOperations.Model;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

using wpf_crypted_messaging;

namespace Login {

    public partial class MainWindow {

        public MainWindow() {
            InitializeComponent();
        }

        private void btnLogin_OnClick(object sender, RoutedEventArgs e) {
            TryUserLogin();
        }

        private void TryUserLogin() {
            var username = this.txtUsername.Text.Trim();
            var password = this.txtPassword.Text.Trim();
            if (CheckUsernameAndPasswordEmptyness(username, password)) {
                var db = new UserDb();
                var id = db.CanLogin(username, password);
                if (id != -1) {
                    OpenChatMainWindow(id, username);
                    Close();
                } else {
                    MessageBox("ERROR!", "Incorrect username or password!");
                }
            } else {
                MessageBox("Error!", "Username or password cannot be empty!");
            }
        }

        private static void OpenChatMainWindow(int id, string username) {
            var user = new User {
                UserId = id,
                Username = username
            };
            var cmw = new ChatMainWindow(user);
            cmw.Show();
        }

        private static bool CheckUsernameAndPasswordEmptyness(string username, string password) {
            return username.Length > 0 && password.Length > 0;
        }

        private async void MessageBox(string title, string message) {
            var window = this.TryFindParent<MetroWindow>();
            await window.ShowMessageAsync(title, message);
        }

    }

}