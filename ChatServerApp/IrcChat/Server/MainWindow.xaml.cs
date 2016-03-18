using System;
using System.Text;
using System.Windows;
using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Service;
using Hik.Samples.Scs.IrcChat.Contracts;

namespace Hik.Samples.Scs.IrcChat.Server
{
    public partial class MainWindow : Window
    {
        private IScsServiceApplication _serviceApplication;

        private ChatService _chatService;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            lblUsers.Text = "";
            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            Environment.Exit(1);
        }

        /// <summary>
        /// Handles Client event of 'Start Server' button.
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void btnStartServer_Click(object sender, RoutedEventArgs e)
        {
            //Get TCP port number from textbox
            int port = Convert.ToInt32(txtPort.Value); 
            try
            {
                _serviceApplication = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(port));
                _chatService = new ChatService();
                _serviceApplication.AddService<IChatService, ChatService>(_chatService);
                _chatService.UserListChanged += chatService_UserListChanged;
                _serviceApplication.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Service can not be started. Exception detail: " + ex.Message);
                return;
            }
            
            txtPort.IsEnabled = false;
        }

        private void chatService_UserListChanged(object sender, EventArgs e)
        {
            Dispatcher.Invoke(new Action(UpdateUserList));
        }

        /// <summary>
        /// Handles Client event of 'Stop Server' button.
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void btnStopServer_Click(object sender, RoutedEventArgs e)
        {
            if (_serviceApplication == null)
            {
                return;
            }

            _serviceApplication.Stop();
            
            txtPort.IsEnabled = true;
        }

        /// <summary>
        /// Updates user list on GUI.
        /// </summary>
        private void UpdateUserList()
        {
            var users = new StringBuilder();
            foreach (var user in _chatService.UserList)
            {
                if (users.Length > 0)
                {
                    users.Append(", ");
                }

                users.Append(user.Nick);
            }

            lblUsers.Text = users.ToString();
        }
    }
}
