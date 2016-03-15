using System.Windows;

using User;

//todo change name
namespace Login {

    public partial class MainWindow {
        //todo make this better
        private const string jsonPath = "src/userInfos.json";

        public MainWindow() {
            InitializeComponent();
        }

        private void btnLogin_OnClick(object sender, RoutedEventArgs e) {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            UserInfo user = new UserInfo {
                Username = username,
                Password = password
            };

            if (CheckUser(user)) {
                //TODO  open another window
            } else {
                MessageBox.Show("Password or Username is wrong");
            }
        }

        private bool CheckUser(UserInfo user) {
            LoginLib.Login login = new LoginLib.Login(jsonPath);
            return login.Check(user);
        }


    }

}