using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using Lib3DES;

using LibDbOperations.Controller;
using LibDbOperations.Model;

using Key = LibDbOperations.Model.Key;

namespace wpf_crypted_messaging {


    public partial class ChatMainWindow {

        public ChatMainWindow(User currentUser) {
            this.CurrentUser = currentUser;
            this.Title = currentUser.Username;
            InitializeComponent();
        }

        private User CurrentUser { get; }
        private User CurrentReceiverUser { get; set; }
        public Key CurrentKey { get; set; }
        private List<User> Users { get; set; }
        private List<ViewMessage> PrivateMessages { get; set; }
        private List<ViewMessage> PublicMessages { get; set; }
        private List<Key> Keys { get; set; }

        private void ChatMainWindow_OnContentRendered(object sender, EventArgs e) {
            FillListWithUsers();
            FillListWithKeys();
            SelectFirstUser();
            UpdateMessagesEverySecond();
        }

        private void FillListWithKeys() {
            var kdb = new KeyDb();
            var k = new Key {
                KeyString = "Şifresiz Metin"
            };
            this.Keys = kdb.GetKeys();
            this.Keys.Insert(0, k);

            if (this.Keys.Count > 0) {
                this.Dispatcher.Invoke(
                    () => {
                        this.cbxKeys.ItemsSource = this.Keys;
                    });
                this.cbxKeys.SelectedIndex = 0;
            }
        }

        private void UpdateMessagesEverySecond() {
            var timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 1000;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            UpdatePrivateMessages();
            UpdatePublicMessages();
        }

        private void btnSend_OnClick(object sender, RoutedEventArgs e) {
            SendMessage();
        }

        private void SendMessage() {
            var from = this.CurrentUser.UserId;
            var to = this.CurrentReceiverUser.UserId;
            var text = this.txtMessage.Text.Trim();
            if (this.cbxKeys.SelectedIndex > 0) {
                text = EncryptText(text);
            }

            var m = new Message {
                Text = text,
                ToId = to,
                FromId = @from
            };
            SendMessage(m);
            this.txtMessage.Text = string.Empty;
        }

        private string EncryptText(string text) {
            return ThreeDesEngine.Encrypt(text, GetSelectedKey().KeyString);
        }

        private Key GetSelectedKey() {
            return this.CurrentKey;
        }

        private string DecryptText(string text, string key) {
            try {
                return ThreeDesEngine.Decrypt(text, key);
            } catch (Exception ex) {
                Debug.WriteLine(ex.Message);
                return text;
            }
        }

        private void lstUsers_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            ChangeCurrentReceiverUser(e);
        }

        private void SelectFirstUser() {
            if (this.lstUsers.Items.Count > 0) {
                this.lstUsers.SelectedIndex = 0;
            }
        }

        private void UpdatePublicMessages() {
            if (this.PublicMessages == null) {
                this.PublicMessages = GetMessages();
            } else {
                var newPublicMessages = GetMessages();
                if (IsMessagesEqual(this.PublicMessages, newPublicMessages)) {
                    return;
                }
                this.PublicMessages = newPublicMessages;
            }
            this.Dispatcher.Invoke(
                () => {
                    this.lstPublicChat.ItemsSource = this.PublicMessages;
                    SetScrollPositionToEnd(this.lstPublicChat);
                });
        }

        private static List<ViewMessage> GetMessages() {
            return new MessageDb().GetMessages();
        }

        private void UpdatePrivateMessages() {
            var from = this.CurrentUser.Username;
            var currentReceiverUser = this.CurrentReceiverUser;
            if (currentReceiverUser != null) {
                var to = currentReceiverUser.Username;

                if (this.PrivateMessages == null) {
                    this.PrivateMessages = GetMessages(to, @from);
                } else {
                    var newPrivateMessages = GetMessages(to, @from);
                    if (IsMessagesEqual(this.PrivateMessages, newPrivateMessages)) {
                        return;
                    }
                    this.PrivateMessages = newPrivateMessages;
                }
                this.Dispatcher.Invoke(
                    () => {
                        this.lstPrivateChat.ItemsSource = this.PrivateMessages;
                        SetScrollPositionToEnd(this.lstPrivateChat);
                    });
            }
        }

        private List<ViewMessage> DecryptPrivateMessages(List<ViewMessage> messages, string key) {
            if (messages != null) {
                for (var i = 0; i < messages.Count; i++) {
                    messages[i].Text = DecryptText(messages[i].Text, key);
                }
            }
            return messages;
        }

        private void SetScrollPositionToEnd(ListBox listBox) {
            var border = VisualTreeHelper.GetChild(listBox, 0) as Decorator;
            // Get scrollviewer
            var scrollViewer = border?.Child as ScrollViewer;
            if (scrollViewer != null) {
                // center the Scroll Viewer...
                var end = scrollViewer.ScrollableHeight;
                scrollViewer.ScrollToVerticalOffset(scrollViewer.ExtentHeight);
            }
        }

        private List<ViewMessage> GetMessages(string to, string from) {
            var messages = new MessageDb().GetMessages(to, from);
            if (GetSelectedKey().KeyId > 0) {
                DecryptPrivateMessages(messages, GetSelectedKey().KeyString);
            }
            return messages;
        }

        private void FillListWithUsers() {
            FillUsers();
            this.lstUsers.ItemsSource = this.Users;
        }

        private void FillUsers() {
            var udb = new UserDb();
            this.Users = udb.GetUserInfos();
        }

        private void SendMessage(Message message) {
            var mdb = new MessageDb();
            var messageId = mdb.AddMessage(message);

            AddMessageKey(GetSelectedKey().KeyId, messageId);
        }

        private void AddMessageKey(int keyId, int messageId) {
            var messageKey = new MessageKey {
                KeyId = keyId,
                MessageId = messageId
            };
            var mkdb = new MessageKeyDb();
            mkdb.AddMessageKey(messageKey);
        }

        private bool IsMessagesEqual(List<ViewMessage> m1, List<ViewMessage> m2) {
            return m1.Count == m2.Count;
        }

        private void ChangeCurrentReceiverUser(SelectionChangedEventArgs e) {
            this.CurrentReceiverUser = ((User) e.AddedItems[0]);
        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.Enter) {
                SendMessage();
            }
        }

        private void cbxkeys_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            this.Dispatcher.Invoke(
                () => {
                    if (this.cbxKeys.SelectedIndex > 0) {
                        this.CurrentKey = (Key) this.cbxKeys.SelectedItem;
                        this.lstPrivateChat.ItemsSource = null;
                        this.lstPrivateChat.ItemsSource = DecryptPrivateMessages(
                            this.PrivateMessages,
                            GetSelectedKey().KeyString);
                        //    this.PrivateMessages = DecryptPrivateMessages(this.PrivateMessages, GetSelectedKey().KeyString);
                    } else {
                        this.CurrentKey = new Key {
                            KeyId = -1
                        };
                    }
                });
        }

    }

}