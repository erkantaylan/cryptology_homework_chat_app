using System;

namespace ChatCommonLib.IrcChat.Arguments {
    [Serializable]
    public class MessageTextStyle {

        public bool IsBold { get; set; }
        public bool IsItalic { get; set; }
        public string FontFamily { get; set; }
        public Color TextColor { get; set; }
        public int TextSize { get; set; }

        public MessageTextStyle() {
            FontFamily = "Verdana";
            //Guess White or Black? 
            TextColor = new Color {Blue = 255, Green = 255, Red = 255};
        }
    }

    [Serializable]
    public class Color {

        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
    }

}