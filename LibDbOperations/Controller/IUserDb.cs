using System.Collections.Generic;

using LibDbOperations.Model;

namespace LibDbOperations.Controller {

    public interface IUserDb {

        int CanLogin(string username, string password);
        List<User> GetUserInfos();
        void AddUser(User user);

    }

}