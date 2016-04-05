using System;

using LibDbOperations.Controller;
using LibDbOperations.Model;

using LibHashing;

namespace TestCmd {

    internal static class Program {

        private static void Main(string[] args) {
            Console.WriteLine("paswd=1234");
            HashingTest("12345");

            //UpdateEveryonesHashAndSalt();

            TryEveryoneLogin();

            Console.ReadKey();
        }

        private static void TryEveryoneLogin() {
            var sud = new SaltyUserDb();
            var users = sud.GetUserInfos();
            foreach (User t in users) {
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
            foreach (var t in users) {
                sud.ChangePassword(t.UserId, t.Password);
            }
        }

    }

}