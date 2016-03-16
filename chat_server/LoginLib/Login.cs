using System.Collections.Generic;
using System.IO;
using System.Linq;

using JsonConverterLib;

using User;

namespace LoginLib {

    public class Login {

        private readonly string jsonFilePath;

        public Login(string jsonFilePath) {
            this.jsonFilePath = jsonFilePath;
        }

        public bool Check(UserInfo userinfo) {
            var json = ReadFromFile(this.jsonFilePath);
            var userInfos = GetUserInfos(json);
            return CheckUserFromList(userinfo, userInfos);
        }

        private bool CheckUserFromList(UserInfo userinfo, List<UserInfo> userInfos) {
            return userInfos.Any(t => CheckUsername(userinfo.Username, t.Username) && CheckPassword(userinfo.Password, t.Password));
        }

        private bool CheckPassword(string password, string s) {
            return password == s;
        }

        private static bool CheckUsername(string username, string u) {
            return username == u;
        }

        private string ReadFromFile(string path) {
            if (File.Exists(path)) {
                return File.ReadAllText(path);
            }
            throw new FileNotFoundException();
        }

        private List<UserInfo> GetUserInfos(string json) {
            var parent = JsonConverter<ParentUserInfo>.JsonToObject(json);
            return parent.UserInfos;
        }

    }

}