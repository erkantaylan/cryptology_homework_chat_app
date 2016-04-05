using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using LibDbOperations.Controller;

namespace Login {

    public partial class ChangePassword : UserControl {

        public ChangePassword() {
            InitializeComponent();
        }

        private void txt_OnKeyUp(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {
                Change();
            }
        }

        private void btnChangePassword_OnClick(object sender, RoutedEventArgs e) {
            Change();
        }

        private void Change() {
            var username = this.txtUsername.Text;
            var oldPass = this.txtPassword.Text;
            var newPass = this.txtNewPassword.Text;
            var newPassAgain = this.txtNewPasswordAgain.Text;
            if (newPass != newPassAgain) {
                MessageBox.Show("New passwords not equal");
            } else {
                var udb = new SaltyUserDb();
                try {
                    udb.ChangePassword(username, oldPass, newPass);
                    ClearTextboxes();
                    MessageBox.Show("Password Changed");
                } catch (Exception exp) {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void ClearTextboxes() {
            this.txtNewPasswordAgain.Text = string.Empty;
            this.txtNewPassword.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.txtUsername.Text = string.Empty;
        }

    }

}