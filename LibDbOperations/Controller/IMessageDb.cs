using System.Collections.Generic;

using LibDbOperations.Model;

namespace LibDbOperations.Controller {

    public interface IMessageDb {

        List<ViewMessage> GetMessages(string senderUsername, string receiverUsername);
        List<ViewMessage> GetMessages();
        int AddMessage(Message message);
        //int GetMessageId(string senderUsername, string receiverUsername, string text);

    }

}