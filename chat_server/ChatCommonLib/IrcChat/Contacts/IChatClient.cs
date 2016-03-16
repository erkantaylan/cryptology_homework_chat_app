using ChatCommonLib.IrcChat.Arguments;

namespace ChatCommonLib.IrcChat.Contacts {

    public interface IChatClient {

        void GetUserList(UserInfo[] users);

        void OnMessageToRoom(string username, ChatMessage message);

        void OnPrivateMessage(string username, ChatMessage message);

        void OnUserLogin(UserInfo userInfo);

        void OnUserLogout(string username);

        void OnUserStatusChange(string username, UserStatus newStatus);

    }

}