﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

using Hik.Samples.Scs.IrcChat.Arguments;
using Hik.Samples.Scs.IrcChat.Client;
using Hik.Samples.Scs.IrcChat.Controls;

using Microsoft.Win32;

namespace Hik.Samples.Scs.IrcChat.Windows {

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IChatRoomView, ILoginFormView, IMessagingAreaContainer {
        #region IMessagingAreaContainer implementation

        /// <summary>
        ///     Sends a message to the room.
        /// </summary>
        public void SendMessage(ChatMessage message) {
            this._controller.SendMessageToRoom(message);
        }

        #endregion

        #region ILoginFormView implementation

        /// <summary>
        ///     IP address of server to be connected.
        /// </summary>
        public string ServerIpAddress {
            get { return (string) this.Dispatcher.Invoke(new Func<string>(() => this.txtServerIpAddress.Text)); }
        }

        /// <summary>
        ///     TCP Port number of server to be connected.
        /// </summary>
        public int ServerTcpPort {
            get { return (int) this.Dispatcher.Invoke(new Func<int>(() => Convert.ToInt32(this.txtServerPort.Text))); }
        }

        /// <summary>
        ///     User Login informations to be used while logging on to the server.
        /// </summary>
        public UserInfo CurrentUserInfo {
            get {
                return (UserInfo) this.Dispatcher.Invoke(
                    new Func<UserInfo>(
                                      () => new UserInfo {
                                          Nick = this.txtNick.Text,
                                          Status = UserStatus.Available,
                                          AvatarBytes = GetBytesOfCurrentUserAvatar()
                                      }));
            }
        }

        #endregion

        #region IChatRoomView implementation

        /// <summary>
        ///     This method is called when a message is sent to chat room.
        /// </summary>
        /// <param name="nick">Nick of sender</param>
        /// <param name="message">Message</param>
        public void OnMessageReceived(string nick, ChatMessage message) {
            this.Dispatcher.Invoke(new Action(() => this.messagingArea.MessageReceived(nick, message)));
        }

        /// <summary>
        ///     This method is called when a private message is sent to the current user.
        /// </summary>
        /// <param name="nick">Nick of sender</param>
        /// <param name="message">The message</param>
        public void OnPrivateMessageReceived(string nick, ChatMessage message) {
            this.Dispatcher.Invoke(new Action(() => OnPrivateMessageReceivedInternal(nick, message)));
        }

        /// <summary>
        ///     This method is called when user successfully logged in to chat server.
        /// </summary>
        public void OnLoggedIn() {
            this.Dispatcher.Invoke(new Action(OnLoggedInInternal));
        }

        /// <summary>
        ///     This method is used to inform view if login is failed.
        /// </summary>
        /// <param name="errorMessage">Detail of error</param>
        public void OnLoginError(string errorMessage) {
            MessageBox.Show(errorMessage, "Login Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        ///     This method is called when connection to server is closed.
        /// </summary>
        public void OnLoggedOut() {
            this.Dispatcher.Invoke(new Action(OnLoggedOutInternal));
        }

        /// <summary>
        ///     This methos is used to add a new user to user list in room view.
        /// </summary>
        /// <param name="userInfo">Informations of new user</param>
        public void AddUserToList(UserInfo userInfo) {
            this.Dispatcher.Invoke(new Action(() => AddUserToListInternal(userInfo)));
        }

        /// <summary>
        ///     This metrhod is used to remove a user (that is disconnected from server) from user list in room view.
        /// </summary>
        /// <param name="nick">Nick of user to remove</param>
        public void RemoveUserFromList(string nick) {
            this.Dispatcher.Invoke(new Action(() => RemoveUserFromListInternal(nick)));
        }

        /// <summary>
        ///     This method is called from chat server to inform that a user changed his/her status.
        /// </summary>
        /// <param name="nick">Nick of the user</param>
        /// <param name="newStatus">New status of the user</param>
        public void OnUserStatusChange(string nick, UserStatus newStatus) {
            this.Dispatcher.Invoke(new Action(() => OnUserStatusChangeInternal(nick, newStatus)));
        }

        #endregion

        #region Private fields

        /// <summary>
        ///     Reference to the controller object.
        /// </summary>
        private readonly IChatController _controller;

        /// <summary>
        ///     List of open private chat windows.
        /// </summary>
        private readonly SortedList<string, PrivateChatWindow> _privateChatWindows;

        /// <summary>
        ///     Reference to the user preferences.
        /// </summary>
        private readonly UserPreferences _userPreferences;

        #endregion

        #region Constructor and Initialize methods

        /// <summary>
        ///     Creates a new form with a reference to the controller object.
        /// </summary>
        /// <param name="controller">Reference to the controller object</param>
        public MainWindow(IChatController controller) {
            this._controller = controller;
            this._privateChatWindows = new SortedList<string, PrivateChatWindow>();
            this._userPreferences = UserPreferences.Current;

            InitializeComponent();
            InitializeControls();
        }

        /// <summary>
        ///     Initializes some controls.
        /// </summary>
        private void InitializeControls() {
            this.messagingArea.MessagingAreaContainer = this;
            this.txtNick.Text = this._userPreferences.Nick;
            this.txtServerIpAddress.Text = this._userPreferences.ServerIpAddress;
            this.txtServerPort.Text = this._userPreferences.ServerTcpPort.ToString();
            InitializeUserAvatar();
        }

        /// <summary>
        ///     Initializes and shows user avatar.
        /// </summary>
        private void InitializeUserAvatar() {
            try {
                ChangeCurrentUserAvatar(this._userPreferences.AvatarFile);
            } catch (Exception ex) {
                MessageBox.Show(
                    "Can not load avatar image. Error Detail: " + ex.Message,
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        #endregion

        #region Handlers for events of window and controls

        /// <summary>
        ///     Handles Loaded event of this Window.
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void Window_Loaded(object sender, RoutedEventArgs e) {
            this.txtNick.Focus();
            this.txtNick.SelectAll();
        }

        /// <summary>
        ///     Hansles Closing event of this window.
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void Window_Closing(object sender, CancelEventArgs e) {
            this._userPreferences.Save();
            this._controller.Disconnect();
        }

        /// <summary>
        ///     Handles TextChanged event of txtNick (on login screen).
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void txtNick_TextChanged(object sender, TextChangedEventArgs e) {
            this.lblCurrentUserNick.Content = this.txtNick.Text;
        }

        /// <summary>
        ///     Handles Click event of 'Change to female' right menu item of avatar menu.
        ///     Changes login avatar to default female avatar.
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void ChangeToFemale_Click(object sender, RoutedEventArgs e) {
            try {
                ChangeCurrentUserAvatar(Path.Combine(ClientHelper.GetCurrentDirectory(), @"Images\user_female.png"));
            } catch (Exception ex) {
                MessageBox.Show(
                    "Can not load avatar image. Error Detail: " + ex.Message,
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        ///     Handles Click event of 'Change to male' right menu item of avatar menu.
        ///     Changes login avatar to default male avatar.
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void ChangeToMale_Click(object sender, RoutedEventArgs e) {
            try {
                ChangeCurrentUserAvatar(Path.Combine(ClientHelper.GetCurrentDirectory(), @"Images\user_male.png"));
            } catch (Exception ex) {
                MessageBox.Show(
                    "Can not load avatar image. Error Detail: " + ex.Message,
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        ///     Handles Click event of 'Select a picture...' menu item.
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void SelectAvatar_Click(object sender, RoutedEventArgs e) {
            try {
                var avatarSelectDialog = new OpenFileDialog();
                avatarSelectDialog.Filter =
                    "JPG Files|*.jpg|JPEG Files|*.jpeg|GIF Files|*.gif|PNG files|*.png|BMP Files|*.bmp";
                if (avatarSelectDialog.ShowDialog() == true) {
                    var selectedFile = avatarSelectDialog.FileName;
                    if (ClientHelper.GetFileSize(selectedFile) > (100 * 1024)) {
                        MessageBox.Show(
                            "You can not select avatar file larger than 100 KB.",
                            "Warning!",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);
                        return;
                    }

                    ChangeCurrentUserAvatar(selectedFile);
                }
            } catch (Exception ex) {
                MessageBox.Show(
                    "Can not load avatar image. Error Detail: " + ex.Message,
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        ///     Handles Client event of Login button.
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            ConnectToServer();
        }

        /// <summary>
        ///     Handles KeyDown of Login form (actually the Border named brdConnect that contains login controls)
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void LoginForm_KeyDown(object sender, KeyEventArgs e) {
            //If user pressed to enter in login form, connect to server
            if (e.Key == Key.Enter) {
                ConnectToServer();
            }
        }

        /// <summary>
        ///     Handles SelectionChanged event of user status combobox
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void cmbCurrentUserStatus_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (!this.IsInitialized
                || this.cmbCurrentUserStatus.SelectedIndex < 0
                || this._controller == null) {
                return;
            }

            try {
                var newStatus = GetCurrentUserStatus();

                this._controller.ChangeStatus(newStatus);

                //Change user's status on all open private chat windows
                foreach (var chatWindow in this._privateChatWindows.Values.ToList()) {
                    chatWindow.CurrentUserStatus = newStatus;
                }
            } catch (Exception ex) {
                MessageBox.Show(
                    "Can not changes status. Error Detail: " + ex.Message,
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        ///     Handles MouseDoubleClick event of all User cards.
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void UserCard_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton != MouseButton.Left) {
                return;
            }

            var userCard = e.Source as UserCardControl;
            if (userCard == null) {
                return;
            }

            if (this._privateChatWindows.ContainsKey(userCard.UserNick)) {
                this._privateChatWindows[userCard.UserNick].Activate();
            } else {
                this._privateChatWindows[userCard.UserNick] = CreatePrivateChatWindow(userCard);
            }
        }

        /// <summary>
        ///     Handles Closed event of Private chat windows.
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="e">Event arguments</param>
        private void PrivateChatWindow_Closed(object sender, EventArgs e) {
            var privateChatWindow = sender as PrivateChatWindow;
            if (privateChatWindow == null) {
                return;
            }

            if (this._privateChatWindows.ContainsKey(privateChatWindow.RemoteUserNick)) {
                this._privateChatWindows.Remove(privateChatWindow.RemoteUserNick);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Connects to the server.
        ///     This method is called on login.
        /// </summary>
        private void ConnectToServer() {
            if (string.IsNullOrEmpty(this.txtNick.Text)) {
                MessageBox.Show(
                    "You must enter a nick to login to server.",
                    "Warning!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(this.txtServerIpAddress.Text)) {
                MessageBox.Show(
                    "You must enter IP address to connect to server.",
                    "Warning!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(this.txtServerPort.Text)) {
                MessageBox.Show(
                    "You must enter TCP port to connect to server.",
                    "Warning!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            try {
                this._controller.Connect();
                this._userPreferences.Nick = this.txtNick.Text;
                this._userPreferences.ServerIpAddress = this.txtServerIpAddress.Text;
                try {
                    this._userPreferences.ServerTcpPort = Convert.ToInt32(this.txtServerPort.Text);
                } catch {
                }
                this._userPreferences.Save();
            } catch (Exception ex) {
                MessageBox.Show(
                    "Can not connected to the server. Check Server IP and port. Error Detail: " + ex.Message,
                    "Error!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        /// <summary>
        ///     This method is used to hide Login form when user succussfully logged into server.
        /// </summary>
        private void OnLoggedInInternal() {
            //this.grdConnect.Visibility = Visibility.Collapsed;
            this.brdConnect.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        ///     This method is used to show Login form when connection to server is broken/closed.
        /// </summary>
        private void OnLoggedOutInternal() {
            foreach (var privateChatWindow in this._privateChatWindows.Values.ToList()) {
                privateChatWindow.Close();
            }

            this.spUsers.Children.Clear();
            //grdConnect.Visibility = Visibility.Visible;
            this.brdConnect.Visibility = Visibility.Visible;
        }

        /// <summary>
        ///     This method is used to send private message to proper private messaging window.
        /// </summary>
        /// <param name="nick">Nick of sender</param>
        /// <param name="message">Message</param>
        private void OnPrivateMessageReceivedInternal(string nick, ChatMessage message) {
            var userCard = FindUserInList(nick);
            if (userCard == null) {
                return;
            }

            if (!this._privateChatWindows.ContainsKey(nick)) {
                //Create new private chat window
                this._privateChatWindows[nick] = CreatePrivateChatWindow(userCard);

                //Set initial state as minimized
                this._privateChatWindows[nick].WindowState = WindowState.Minimized;

                //Flash the window button on taskbar to inform user
                WindowsHelper.FlashWindow(
                    new WindowInteropHelper(this._privateChatWindows[nick]).Handle,
                    WindowsHelper.FlashWindowFlags.FLASHW_ALL,
                    2,
                    1000);
            }

            this._privateChatWindows[nick].MessageReceived(message);
        }

        /// <summary>
        ///     Creates a new PrivateChatWindow from a user card.
        /// </summary>
        /// <param name="userCard">User card to use while creating window</param>
        /// <returns>Created window</returns>
        private PrivateChatWindow CreatePrivateChatWindow(UserCardControl userCard) {
            var window = new PrivateChatWindow(this._controller) {
                CurrentUserNick = this.txtNick.Text,
                CurrentUserStatus = GetCurrentUserStatus(),
                CurrentUserAvatar = this.imgCurrentUserAvatar.Source,
                RemoteUserNick = userCard.UserNick,
                RemoteUserStatus = userCard.UserStatus,
                RemoteUserAvatar = userCard.AvatarImageSource
            };
            window.Closed += PrivateChatWindow_Closed;
            window.Show();
            return window;
        }

        /// <summary>
        ///     Adds user to user list in right area of the window.
        /// </summary>
        /// <param name="userInfo">New user informations</param>
        private void AddUserToListInternal(UserInfo userInfo) {
            //Do not add the current user (that is using the application) to user list
            if (userInfo.Nick == this.CurrentUserInfo.Nick) {
                return;
            }

            //Do not add user to list if it is already exists.
            if (FindUserInList(userInfo.Nick) != null) {
                return;
            }

            //Find correct order (by name) to insert the user
            var orderedIndex = 0;
            foreach (UserCardControl userCardControl in this.spUsers.Children) {
                if (userInfo.Nick.CompareTo(userCardControl.UserNick) < 0) {
                    break;
                }
                orderedIndex++;
            }

            //Create user control
            var userCard = new UserCardControl {
                UserNick = userInfo.Nick,
                UserStatus = userInfo.Status,
                AvatarBytes = userInfo.AvatarBytes,
                Height = 60
            };
            userCard.MouseDoubleClick += UserCard_MouseDoubleClick;

            //Insert user to user list
            this.spUsers.Children.Insert(
                orderedIndex,
                userCard
                );

            //Enable private messaging window if any open with that user
            if (this._privateChatWindows.ContainsKey(userInfo.Nick)) {
                this._privateChatWindows[userInfo.Nick].UserLoggedIn();
                this._privateChatWindows[userInfo.Nick].RemoteUserStatus = userInfo.Status;
                this._privateChatWindows[userInfo.Nick].RemoteUserAvatar = userCard.AvatarImageSource;
            }
        }

        /// <summary>
        ///     Removes an existing user from user list.
        /// </summary>
        /// <param name="nick"></param>
        private void RemoveUserFromListInternal(string nick) {
            //Enable private messaging window is any open with that user
            if (this._privateChatWindows.ContainsKey(nick)) {
                this._privateChatWindows[nick].UserLoggedOut();
            }

            //Find user in list
            var userCard = FindUserInList(nick);

            //Remove if found
            if (userCard != null) {
                this.spUsers.Children.Remove(userCard);
                userCard.MouseDoubleClick -= UserCard_MouseDoubleClick;
            }
        }

        /// <summary>
        ///     Changes status of a user in user list.
        /// </summary>
        /// <param name="nick">Nick of the user</param>
        /// <param name="newStatus">New status of the user</param>
        public void OnUserStatusChangeInternal(string nick, UserStatus newStatus) {
            //Find user in list
            var userCard = FindUserInList(nick);

            //Change status of user if found
            if (userCard != null) {
                userCard.UserStatus = newStatus;
            }

            //Change status of user if any private chat window is open
            if (this._privateChatWindows.ContainsKey(nick)) {
                this._privateChatWindows[nick].RemoteUserStatus = newStatus;
            }
        }

        /// <summary>
        ///     Searches a user (by nick) in user list and gets user card control of user.
        /// </summary>
        /// <param name="nick">Nick to search</param>
        /// <returns>Found user card of user</returns>
        private UserCardControl FindUserInList(string nick) {
            return
                this.spUsers.Children.Cast<UserCardControl>()
                    .FirstOrDefault(userCardControl => userCardControl.UserNick == nick);
        }

        /// <summary>
        ///     Changes avatar of the current user by a file.
        /// </summary>
        /// <param name="avatarPath">File path of new avatar</param>
        private void ChangeCurrentUserAvatar(string avatarPath) {
            this.imgLoginAvatar.Source = new BitmapImage(new Uri(avatarPath));
            this.imgCurrentUserAvatar.Source = this.imgLoginAvatar.Source;
            this._userPreferences.AvatarFile = avatarPath;
        }

        /// <summary>
        ///     Gets status of the current user from combobox.
        /// </summary>
        /// <returns>Status of current user</returns>
        private UserStatus GetCurrentUserStatus() {
            switch (this.cmbCurrentUserStatus.SelectedIndex) {
                case 0:
                    return UserStatus.Available;
                case 1:
                    return UserStatus.Busy;
                default:
                    return UserStatus.Out;
            }
        }

        /// <summary>
        ///     Gets bytes of current user avatar.
        /// </summary>
        /// <returns>Bytes of user avatar file</returns>
        private byte[] GetBytesOfCurrentUserAvatar() {
            if (string.IsNullOrEmpty(this._userPreferences.AvatarFile)) {
                return null;
            }

            try {
                if (!File.Exists(this._userPreferences.AvatarFile)) {
                    return null;
                }

                return File.ReadAllBytes(this._userPreferences.AvatarFile);
            } catch (Exception) {
                return null;
            }
        }

        #endregion
    }

}