using System.Windows;

using LibDbOperations.Model;

namespace wpf_crypted_messaging {
    
    public partial class App : Application {

        public App() {
            ChatMainWindow cmw = new ChatMainWindow(
                new User {
                    UserId = 2,
                    Username = "erkan"
                });
            cmw.Show();
        }
        

    }

}