using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace LibStegonografi {

    public class StegaCrypter {

        public Bitmap Encrypt(Bitmap img, string message) {
            for ( var i = 0; i < img.Width; i++ ) {
                for ( var j = 0; j < img.Height; j++ ) {
                    var pixel = img.GetPixel(i, j);
                    if ( i < 1
                         && j < message.Length ) {
                        var letter = Convert.ToChar(message.Substring(j, 1));
                        var value = Convert.ToInt32(letter);
                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, value));
                        Debug.WriteLine($"Orjinal Deger      : {pixel.B}");
                        Debug.WriteLine($"Degistirilen Deger : {value}");
                        Debug.WriteLine("");
                    }
                    if ( i == img.Width - 1
                         && j == img.Height - 1 ) {
                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, message.Length));
                    }
                }
            }
            return img;
        }

        public string Decrypt(Bitmap encrypted) {
            var message = "";

            var lastpixel = encrypted.GetPixel(encrypted.Width - 1, encrypted.Height - 1);
            int msgLength = lastpixel.B;

            for ( var i = 0; i < encrypted.Width; i++ ) {
                for ( var j = 0; j < encrypted.Height; j++ ) {
                    var pixel = encrypted.GetPixel(i, j);
                    if ( i < 1 && j < msgLength ) {
                        int value = pixel.B;
                        var c = Convert.ToChar(value);
                        var letter = Encoding.ASCII.GetString(
                            new[] {
                                Convert.ToByte(c)
                            });
                        message = message + letter;
                    }
                }
            }
            return message;
        }

    }

}