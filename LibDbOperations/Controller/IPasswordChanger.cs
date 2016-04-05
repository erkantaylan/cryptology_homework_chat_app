namespace LibDbOperations.Controller {

    public interface IPasswordChanger {

        void ChangePassword(string username, string oldPassword, string newPassword);

    }

}