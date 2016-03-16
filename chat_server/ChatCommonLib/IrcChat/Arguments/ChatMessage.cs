using System;

namespace ChatCommonLib.IrcChat.Arguments {

    [Serializable]
    public class ChatMessage {

        public string MessageText { get; set; }
        public MessageTextStyle TextStyle { get; set; }

        public ChatMessage() {
            this.TextStyle = new MessageTextStyle();
        }

        public ChatMessage(string messageText, MessageTextStyle textStyle) {
            this.TextStyle = textStyle;
            this.MessageText = messageText;
        }
    }

}