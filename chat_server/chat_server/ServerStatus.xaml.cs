using ServerLib;

namespace chat_server {

    public partial class MainWindow {

        public MainWindow() {
            InitializeComponent();
        }

        private void OpenServer() {
            var server = new Server();
            server.Start();
        }
    }

}