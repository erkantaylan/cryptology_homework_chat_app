using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ChatCommonLib.IrcChat.Arguments;
using ChatCommonLib.IrcChat.Contacts;
using ChatCommonLib.IrcChat.Exceptions;

using Hik.Collections;
using Hik.Communication.Scs.Server;
using Hik.Communication.ScsServices.Service;

namespace ChatServer {

    public class ChatService : ScsService, IChatService {

        private readonly ThreadSafeSortedList<long, ChatClient> _clients;

        public ChatService() {
            this._clients = new ThreadSafeSortedList<long, ChatClient>();
        }

        public List<UserInfo> UserList => (from client in this._clients.GetAllItems() select client.User).ToList();

        #region IChatService Methods

        public void Login(UserInfo userInfo)
        {
            if (FindClientByUsername(userInfo.Username) != null)
            {
                throw new NickInUseException("Try something more funny");
            }
            var client = this.CurrentClient;
            var clientProxy = client.GetClientProxy<IChatClient>();
            var chatClient = new ChatClient(client, clientProxy, userInfo);
            this._clients[client.ClientId] = chatClient;
            client.Disconnected += Client_Disconnected;

            //Lets make some task
            Task.Factory.StartNew(
                () => {
                    OnUserListChanged();
                    SendUserListToClient(chatClient);
                    SendUserLoginInfoToAllClients(userInfo);
                });
        }

        public void SendMessageToRoom(ChatMessage message)
        {
            //TODO Dont do if the teacher dont want
        }

        public void SendPrivateMessage(string destinationUsername, ChatMessage message)
        {
            var senderClient = GetCurrentClient();
            if (senderClient == null)
            {
                throw new ApplicationException("Cannot send message before login.");
            }
            var receiverClient = FindClientByUsername(destinationUsername);
            if (receiverClient != null)
            {
                receiverClient.ClientProxy.OnPrivateMessage(senderClient.User.Username, message);
            }
            else {
                throw new ApplicationException("Sorry your friend is gone. (Dont worry s/he is not death)");
            }
        }

        public void ChangeStatus(UserStatus newStatus)
        {
            var senderClient = GetCurrentClient();
            if (senderClient == null)
            {
                throw new ApplicationException("Cannot change state before login.");
            }

            senderClient.User.Status = newStatus;

            Task.Factory.StartNew(
                () => {
                    foreach (var chatClient in this._clients.GetAllItems())
                    {
                        try
                        {
                            chatClient.ClientProxy.OnUserStatusChange(senderClient.User.Username, newStatus);
                        }
                        catch
                        {
                            //Hide some exceptions
                        }
                    }
                });
        }

        public void Logout()
        {
            ClientLogout(this.CurrentClient.ClientId);
        }
        #endregion

        #region Private Event Raising Methods

        private void OnUserListChanged() {
            var handler = UserListChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        public event EventHandler UserListChanged;

        #region Private Methods

        private void Client_Disconnected(object sender, EventArgs e) {
            var client = (IScsServerClient) sender;
            ClientLogout(client.ClientId);
        }


        private void SendUserListToClient(ChatClient client) {
            //get all users except new one
            var userList = this.UserList.Where(user => (user.Username != client.User.Username)).ToArray();

            //don't send list if no user awaliable but new one
            if (userList.Length > 0) {
                client.ClientProxy.GetUserList(userList);
            }

            //TODO consider this: i can check more then 1 user avaliable and dont control  (user.Username != client.User.Username)
        }

        private void ClientLogout(long clientId) {
            var client = this._clients[clientId];
            if (client != null) {
                this._clients.Remove(client.Client.ClientId);
                client.Client.Disconnected += Client_Disconnected;

                Task.Factory.StartNew(
                    () => {
                        OnUserListChanged();
                        SendUserLogoutInfoToAllClients(client.User.Username);
                    });
            }
        }

        private void SendUserLoginInfoToAllClients(UserInfo userInfo) {
            foreach (var client in this._clients.GetAllItems()) {
                if (client.User.Username != userInfo.Username) {
                    try {
                        client.ClientProxy.OnUserLogin(userInfo);
                    } catch (Exception) {
                        //Hide another exception 
                    }
                }
            }
        }

        private void SendUserLogoutInfoToAllClients(string username) {
            foreach (var client in this._clients.GetAllItems()) {
                try {
                    client.ClientProxy.OnUserLogout(username);
                } catch {
                    //Hide another exception
                }
            }
        }

        private ChatClient FindClientByUsername(string username) { // noway to look pretty or more readable?
            return (from client in this._clients.GetAllItems()
                    where client.User.Username == username
                    select client).FirstOrDefault();
        }


        private ChatClient GetCurrentClient() {
            return this._clients[this.CurrentClient.ClientId];
        }

        #endregion
    }

    /// <summary>
    ///     This class is used to store informations for a connected client.
    /// </summary>
    internal sealed class ChatClient {

        public ChatClient(IScsServiceClient client, IChatClient clientProxy, UserInfo userInfo) {
            this.Client = client;
            this.ClientProxy = clientProxy;
            this.User = userInfo;
        }

        public IScsServiceClient Client { get; }
        public IChatClient ClientProxy { get; }
        public UserInfo User { get; }

    }

}