using System;
using System.Drawing;

namespace TestCmd
{
    internal class StegoTests
    {
        public static Bitmap Encode(string path, string message)
        {
            var img = new Bitmap(path);

            for (var i = 0; i < img.Width; i++)
            {
                for (var j = 0; j < img.Height; j++)
                {
                    var pixel = img.GetPixel(i, j);

                    if (i < 1 && j < message.Length)
                    {
                        Console.WriteLine("R = [" + i + "][" + j + "] = " + pixel.R);
                        Console.WriteLine("G = [" + i + "][" + j + "] = " + pixel.G);
                        Console.WriteLine("G = [" + i + "][" + j + "] = " + pixel.B);

                        var letter = Convert.ToChar(message.Substring(j, 1));
                        var value = Convert.ToInt32(letter);
                        Console.WriteLine("letter : " + letter + " value : " + value);

                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, value));
                    }

                    if (i == img.Width - 1 && j == img.Height - 1)
                    {
                        img.SetPixel(i, j, Color.FromArgb(pixel.R, pixel.G, message.Length));
                    }
                }
            }
            return img;
        }
    }
}