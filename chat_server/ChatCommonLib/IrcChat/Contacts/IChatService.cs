using ChatCommonLib.IrcChat.Arguments;

using Hik.Communication.ScsServices.Service;

namespace ChatCommonLib.IrcChat.Contacts {

    [ScsService(Version = "1.0.0.0")]
    public interface IChatService {

        void Login(UserInfo userInfo);
        void SendMessageToRoom(ChatMessage message);
        void SendPrivateMessage(string destinationUsername, ChatMessage message);
        void ChangeStatus(UserStatus newStatus);
        void Logout();

    }

}