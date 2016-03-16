using System;
using System.Collections.Generic;
using System.Windows;

using ChatCommonLib.IrcChat.Arguments;
using ChatCommonLib.IrcChat.Contacts;

using Hik.Communication.Scs.Communication.EndPoints.Tcp;
using Hik.Communication.ScsServices.Service;

namespace ChatServer {

    public partial class MainWindow {

        private readonly List<UserInfo> _users = new List<UserInfo>();
        private ChatService _chatService;
        private IScsServiceApplication _serviceApplication;

        public MainWindow() {
            InitializeComponent();

            //Test_UserListboxItems();
        }

        private void Test_UserListboxItems() {
            var userInfo1 = new UserInfo {
                Username = "name1",
                IpAddress = "127.0.0.1"
            };
            var userInfo2 = new UserInfo {
                Username = "name2",
                IpAddress = "127.0.0.12"
            };
            var userInfo3 = new UserInfo {
                Username = "name3",
                IpAddress = "127.0.0.123"
            };
            var userInfo4 = new UserInfo {
                Username = "name4",
                IpAddress = "127.011.0.123"
            };
            var list = new List<UserInfo> {
                userInfo1,
                userInfo4,
                userInfo2,
                userInfo3
            };
            BindListBoxToUserList(list);
        }

        private void tsServerStarter_OnChecked(object sender, RoutedEventArgs e) {
            StartServer();
        }

        private void StartServer() {
            var value = this.nudPort.Value;
            if (value != null) {
                var port = (int) value;

                try {
                    this._serviceApplication = ScsServiceBuilder.CreateService(new ScsTcpEndPoint(port));
                    this._chatService = new ChatService();
                    this._serviceApplication.AddService<IChatService, ChatService>(this._chatService);
                    this._chatService.UserListChanged += _chatService_UserListChanged;
                    this._serviceApplication.Start();
                } catch (Exception exception) {
                    MessageBox.Show(
                        "Service can not be started. You did something wrongly!\n" +
                        "This is only I can give it to you: ",
                        exception.Message);
                }
            } else {
                MessageBox.Show("Your port number somehow NULL");
            }
        }

        private void _chatService_UserListChanged(object sender, EventArgs e) {
            this.Dispatcher.Invoke(new Action(UpdateUserList));
            this.nudPort.IsReadOnly = true;
        }

        private void UpdateUserList() {
            ClearUsersList();
            for (var i = 0; i < this._chatService.UserList.Count; i++) {
                this._users.Add(this._chatService.UserList[i]);
            }
            BindListBoxToUserList(this._users);
        }

        private void BindListBoxToUserList(List<UserInfo> users) {
            this.lsbOnlineUsers.ItemsSource = users;
        }

        private void ClearUsersList() {
            this._users.Clear();
        }

        private void tsServerStarter_OnUnchecked(object sender, RoutedEventArgs e) {
            StopServer();
            this.nudPort.IsReadOnly = false;
        }

        private void StopServer() {
            this._serviceApplication?.Stop();
        }

    }

}