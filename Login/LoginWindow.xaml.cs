using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

using LibCaptcha;

using LibDbOperations.Controller;
using LibDbOperations.Model;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

using wpf_crypted_messaging;

using Key = System.Windows.Input.Key;

namespace Login {

    public partial class LoginWindow {

        public LoginWindow() {
            InitializeComponent();
            this.txtUsername.Focus();
            this.lblCaptcha.Text = GetCaptcha();
        }

        private int LoginErrorCount { get; set; } = 1;

        private string GetCaptcha() {
            return new CaptchaGenerator().GetCaptcha(5);
        }

        private void btnLogin_OnClick(object sender, RoutedEventArgs e) {
            TryLogin();
        }

        private void TryLogin() {
            if (CheckCaptcha()) {
                CheckuserLogin();
                CheckErrorCount();
            } else {
                System.Windows.MessageBox.Show("Wrong Captcha");
            }
            ResetCaptcha();
        }

        private void CheckErrorCount() {
            if (this.LoginErrorCount >= 5) {
                Wait(int.MaxValue - 1);
            } else if (this.LoginErrorCount >= 3) {
                Wait(10);
            }
        }

        private void CheckuserLogin() {
            var result = CheckUsernamePassword();
            this.LoginErrorCount = result ? this.LoginErrorCount : this.LoginErrorCount + 1;
            if (result) {
                Close();
            } else {
                System.Windows.MessageBox.Show("Wrong Username or Password");
            }
        }

        private void ResetCaptcha() {
            this.txtCaptcha.Text = string.Empty;
            this.lblCaptcha.Text = GetCaptcha();
        }

        private void Wait(int second) {
            SuspendWindow();
            SetTimer(second);
        }

        private void SuspendWindow() {
            this.grdMain.Visibility = Visibility.Hidden;
            this.progressRing.IsActive = true;
        }

        private void SetTimer(int second) {
            var timer = new DispatcherTimer {
                Interval = TimeSpan.FromSeconds(second)
            };
            timer.Start();
            timer.Tick += (sender, args) => {
                timer.Stop();
                ResumeWindow();
            };
        }

        private void ResumeWindow() {
            this.grdMain.Visibility = Visibility.Visible;
            this.progressRing.IsActive = false;
        }

        private bool CheckCaptcha() {
            return this.lblCaptcha.Text == this.txtCaptcha.Text;
        }

        private bool CheckUsernamePassword() {
            var username = this.txtUsername.Text.Trim();
            var password = this.txtPassword.Text.Trim();
            if (CheckUsernameAndPasswordEmptyness(username, password)) {
                var db = new SaltyUserDb();
                var id = db.CanLogin(username, password);
                if (id != -1) {
                    OpenChatMainWindow(id, username);
                    return true;
                }
                return false;
            }
            return false;
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

        private void txt_OnKeyUp(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                TryLogin();
            }
            
        }


        private void btnChangePassword_OnClick(object sender, RoutedEventArgs e) {
            grdMain.Visibility = Visibility.Collapsed;
            grdChangePassword.Visibility = Visibility.Visible;
        }


        private void btnBack_OnClick(object sender, RoutedEventArgs e) {
            grdMain.Visibility = Visibility.Visible;
            grdChangePassword.Visibility = Visibility.Collapsed;
        }

    }

}