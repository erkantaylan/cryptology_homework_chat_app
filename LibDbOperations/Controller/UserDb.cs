using System;
using System.Collections.Generic;
using System.Data;

using LibDbOperations.Model;

namespace LibDbOperations.Controller {

    public class UserDb : IUserDb {

        public int CanLogin(string username, string password) {
            string query = $"SELECT userId FROM tblUser WHERE username = '{username}' AND password = '{password}'";
            var table = GetTableFromDatabase(query);
            if (table.Rows.Count > 0) {
                return Convert.ToInt32(table.Rows[0][0].ToString());
            }
            return -1;
        }

        public List<User> GetUserInfos() {
            var query = "SELECT userId, username, password FROM tblUser";
            var table = GetTableFromDatabase(query);
            var rowsCount = table.Rows.Count;
            if (rowsCount > 0) {
                var users = new List<User>(rowsCount);
                for (var i = 0; i < rowsCount; i++) {
                    var currentRow = table.Rows[i];
                    users.Add(
                        new User {
                            UserId = Convert.ToInt32(currentRow[0].ToString()),
                            Username = currentRow[1].ToString(),
                            Password = currentRow[2].ToString()
                        });
                }
                return users;
            }
            return null;
        }

        public void AddUser(User user) {
            if (user != null) {
                string query = $"INSERT INTO tblUser(username, passwrod) VALUES ('{user.Username}','{user.Password}')";
                var c = new SqlConnector();
                var result = c.runCommand(query);
                if (result == -1) {
                    throw new Exception("User cannot be added to database");
                }
            } else {
                throw new NullReferenceException("Your user is NULL");
            }
        }

        private static DataTable GetTableFromDatabase(string query) {
            var conn = new SqlConnector();
            return conn.SelectTable(query);
        }

    }

}