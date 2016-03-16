using System;

namespace ChatCommonLib.IrcChat.Arguments {

    [Serializable]
    public class UserInfo {

        public string Username { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
        public UserStatus Status { get; set; }

    }

}