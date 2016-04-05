using System;
using System.Security.Cryptography;
using System.Text;

namespace LibHashing {

    public class HashingWithSalt {

        public String CreateSalt(int size = 20) {
            var rng = new RNGCryptoServiceProvider();
            var buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public String GenerateSHa256Hash(String input, String salt) {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256Managed hashString = new SHA256Managed();
            var hash = hashString.ComputeHash(bytes);
            return ByteArrayToString(hash);
        }

        private string ByteArrayToString(byte[] array) {
            var hex = new StringBuilder(array.Length * 2);
            for (int i = 0; i < array.Length; i++) {
                hex.AppendFormat("{0:x2}", array[i]);
            }
            return hex.ToString();
        }

    }

}