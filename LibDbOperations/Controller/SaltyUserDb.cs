using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;

using LibDbOperations.Model;

using LibHashing;

namespace LibDbOperations.Controller {

    public class SaltyUserDb : UserDb, IUserDb {

        public override int CanLogin(string username, string password) {
            var user = GetUser(username);
            if (user != null) {
                var salt = user.Salt;
                var hash = GetHash(password, salt);
                var hashFromDb = user.Hash;
                if (hash == hashFromDb) {
                    return user.UserId;
                }
            }
            return -1;
        }

        public override List<User> GetUserInfos() {
            return base.GetUserInfos();
        }

        private string CreateSalt() {
            return new HashingWithSalt().CreateSalt();
        }

        private string GetHash(string input, string salt) {
            return new HashingWithSalt().GenerateSHa256Hash(input, salt);
        }

        private SaltyUser GetUser(string username) {
            var query = "SELECT userId, username, password, salt, hash FROM tblUser " +
                        $"WHERE username='{username}'";
            var table = GetTableFromDatabase(query);
            if (table.Rows.Count > 0) {
                return new SaltyUser {
                    UserId = Convert.ToInt32(table.Rows[0][0].ToString()),
                    Username = table.Rows[0][1].ToString(),
                    Password = table.Rows[0][2].ToString(),
                    Salt = table.Rows[0][3].ToString(),
                    Hash = table.Rows[0][4].ToString()
                };
            }
            return null;
        }

        public void AddUser(SaltyUser user) {
            if (user != null) {
                var query = "INSERT INTO tblUser(username, password, salt, hash) VALUES(" +
                            $"'{user.Username}'" +
                            $", '{user.Password}'" +
                            $", '{user.Salt}'" +
                            $", '{user.Hash}');";
                var c = new SqlConnector();

                var result = c.runCommand(query);
                if (result == -1) {
                    throw new Exception("User cannot be added to database");
                }
            } else {
                throw new NullReferenceException("Your user is NULL");
            }
        }

        public override void ChangePassword(string username, string oldPassword, string newPassword) {
            var userId = CanLogin(username, oldPassword);
            if (userId == -1) {
                throw new Exception("Username or password wrong!");
            }
            ChangePassword(userId, newPassword);
        }

        public void ChangePassword(int userId, string password) {
            var salt = CreateSalt();
            var hash = GetHash(password, salt);
            var query = $"UPDATE tblUser " +
                        $"SET tblUser.password='{password}'" +
                        $", tblUser.hash='{hash}'" +
                        $", tblUser.salt='{salt}'" +
                        $"WHERE userId={userId}";
            var conn = new SqlConnector();
            var result = conn.runCommand(query);
            if (result == -1) {
                throw new SqlNotFilledException("Password cannot be changed");
            }
        }
        
        private static DataTable GetTableFromDatabase(string query) {
            var conn = new SqlConnector();
            return conn.SelectTable(query);
        }

    }

}