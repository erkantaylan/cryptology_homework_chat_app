using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;

using LibDbOperations.Model;

namespace LibDbOperations.Controller {

    public class UserDb : IUserDb, IPasswordChanger {

        public virtual void ChangePassword(string username, string oldPassword, string newPassword) {
            var userId = CanLogin(username, oldPassword);
            if (userId == -1) {
                throw new Exception("Username or password wrong!");
            }
            ChangePassword(userId, newPassword);
        }

        private void ChangePassword(int userId, string password) {
            string query = $"UPDATE tblUser " +
                           $"SET tblUser.password='{password}' " +
                           $"WHERE userId={userId}";
            SqlConnector conn = new SqlConnector();
            int result = conn.runCommand(query);
            if (result == -1) {
                throw new SqlNotFilledException("Password cannot be changed");
            }
        }

        public virtual int CanLogin(string username, string password) {
            string query = $"SELECT userId FROM tblUser WHERE username = '{username}' AND password = '{password}'";
            var table = GetTableFromDatabase(query);
            if (table.Rows.Count > 0) {
                return Convert.ToInt32(table.Rows[0][0].ToString());
            }
            return -1;
        }

        public virtual List<User> GetUserInfos() {
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

        public virtual void AddUser(User user) {
            if (user != null) {
                string query = $"INSERT INTO tblUser(username, password) VALUES ('{user.Username}','{user.Password}')";
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