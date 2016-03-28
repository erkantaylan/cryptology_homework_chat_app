using System;
using System.Security.Cryptography;
using System.Text;

namespace Lib3DES {

    public static class ThreeDesEngine {

        public static string Encrypt(string text, string key) {
            var toEncryptArray = Encoding.UTF8.GetBytes(text);

            var keyArray = Encoding.UTF8.GetBytes(key);
            var tdes = new TripleDESCryptoServiceProvider {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var cTransform = tdes.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string text, string key) {
            var toEncryptArray = Convert.FromBase64String(text);

            var keyArray = Encoding.UTF8.GetBytes(key);
            var tdes = new TripleDESCryptoServiceProvider {
                Key = keyArray,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            var cTransform = tdes.CreateDecryptor();

            var resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();

            return Encoding.UTF8.GetString(resultArray);
        }

    }

}