using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

using Lib3DES;

using LibCaptcha;

using LibDbOperations.Controller;

using LibHashing;

using LibRSA;

using LibStegonografi;

namespace TestCmd {

    internal static class Program {

        private static string key = "MCym6O8sN8UZug2GgLSE8aK8";

        private static void Main(string[] args) {
            //TextXOR();
            //StegaConvert();

            //Picture3DES();

            //CompareImageHashs();

            RSA();

            Console.WriteLine(7 ^ 7);
            //TestImage();
            //TestCaptchaGenerator();
            //Console.WriteLine("paswd=1234");
            //HashingTest("12345");

            //UpdateEveryonesHashAndSalt();

            //TryEveryoneLogin();

            Console.ReadKey();
        }

        private static void TextXOR() {
            var binary = ConvertToByteArray("!", Encoding.ASCII);
            var binary2 = ConvertToByteArray("#", Encoding.ASCII);

            Console.WriteLine(ToBinary(binary));
            Console.WriteLine(ToBinary(binary2));

            var result = binary[0] ^ binary2[0];

            Console.WriteLine(result);
        }

        private static void TryEveryoneLogin() {
            var sud = new SaltyUserDb();
            var users = sud.GetUserInfos();
            foreach ( var t in users ) {
                var result = sud.CanLogin(t.Username, t.Password);
                Console.WriteLine($"username:{t.Username}");
                Console.WriteLine($"password:{t.Password}");
                Console.WriteLine(result);
                Console.WriteLine();
            }
        }

        private static void HashingTest(string password) {
            var hws = new HashingWithSalt();
            /*GayBlBIN2gvW6E4NDl2srUFe7BY=*/
            var salt = hws.CreateSalt();
            //var salt = "GayBlBIN2gvW6E4NDl2srUFe7BY";
            /*000102030405060708090a0b0c0d0e0f101112131415161718191a1b1c1d1e1f*/
            /**/
            var hash = hws.GenerateSHa256Hash(password, salt);
            Console.WriteLine($"salt:{salt}");
            Console.WriteLine($"hash:{hash}");
        }

        private static void UpdateEveryonesHashAndSalt() {
            var sud = new SaltyUserDb();
            var users = sud.GetUserInfos();
            foreach ( var t in users ) {
                sud.ChangePassword(t.UserId, t.Password);
            }
        }

        private static void TestCaptchaGenerator() {
            var generator = new CaptchaGenerator();

            for ( var i = 0; i < 100; i++ ) {
                Console.WriteLine(generator.GetCaptcha(5));
            }
        }

        private static void TestImage() {
            var path = @"C:\Users\erkan\Pictures\Saved Pictures\eric.png";
            var bitmap = new Bitmap(path);
            for ( var i = 0; i < bitmap.Height; i++ ) {
                for ( var j = 0; j < bitmap.Width; j++ ) {
                    var pixel = bitmap.GetPixel(i, j);
                    Console.Write($"{pixel.R} {pixel.G} {pixel.B} | ");
                }

                Console.WriteLine();
            }
        }

        public static byte[] ConvertToByteArray(string str, Encoding encoding) {
            return encoding.GetBytes(str);
        }

        public static string ToBinary(byte[] data) {
            return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }

        public static void StegaConvert() {
            var path = @"C:\Users\erkan\Pictures\Saved Pictures\eric.png";
            var bitmap = new Bitmap(path);
            StegaCrypter crypter = new StegaCrypter();

            var ed = crypter.Encrypt(bitmap, "resim icinde metin");
            ed.Save(@"C:\Users\erkan\Pictures\Saved Pictures\eric2.png");
            var message= crypter.Decrypt(ed);
            Console.WriteLine(message);

        }

        public static void WriteBitmap(Bitmap bitmap) {
            for ( var i = 0; i < bitmap.Height; i++ ) {
                for ( var j = 0; j < bitmap.Width; j++ ) {
                    var pixel = bitmap.GetPixel(i, j);
                    Console.Write($"{pixel.R} {pixel.G} {pixel.B} | ");
                }

                Console.WriteLine();
            }
        }

        public static void Picture3DES() {
            var path = @"C:\Users\erkan\Pictures\Saved Pictures\eric.png";
            var bitmap = new Bitmap(path);
            var text = ImageToBase64(bitmap, ImageFormat.Png);

            var encrypt = ThreeDesEngine.Encrypt(text, key);
            var dec = ThreeDesEngine.Decrypt(encrypt, key);
            Console.WriteLine(encrypt);
            var image = Base64ToImage(dec);
            image.Save(@"C:\Users\erkan\Pictures\Saved Pictures\eric3.png");
        }

        public static string ImageToBase64(Bitmap image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public static Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            var image = Image.FromStream(ms, true);
            return image;
        }

        public static void CompareImageHashs() {
            var path1 = @"C:\Users\erkan\Pictures\Saved Pictures\eric.png";
            var path2 = @"C:\Users\erkan\Pictures\Saved Pictures\eric2.png";
            var img1 = new Bitmap(path1);
            var img2 = new Bitmap(path2);
            var img1String = ImageToBase64(img1, ImageFormat.Png);
            var img2String = ImageToBase64(img2, ImageFormat.Png);

            HashingWithSalt hws = new HashingWithSalt();
            var hash1 = hws.GenerateSHa256Hash(img1String, "");
            var hash2 = hws.GenerateSHa256Hash(img2String, "");
            Console.WriteLine(hash1);
            Console.WriteLine(hash2);

        }

        public static void RSA() {
            RSAProvider rsa = new RSAProvider();
            var cyper = rsa.Encrypt("1234");
            Console.WriteLine(cyper);
            Console.WriteLine(rsa.Decrypt(cyper));
        }
    }

}