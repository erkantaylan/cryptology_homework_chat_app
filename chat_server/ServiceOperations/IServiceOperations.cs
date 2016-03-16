using Hik.Communication.ScsServices.Service;

using MessageLib;

using User;

namespace ServiceLib {

    [ScsService]
    public interface IServiceOperations {

        void SendMessage(UserInfo sender, string receiverUsername, Message message);

        //TODO MessageReceived Event
    }

}