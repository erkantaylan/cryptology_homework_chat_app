using System;

using LibDbOperations.Model;

namespace LibDbOperations.Controller {

    public class MessageKeyDb : IMessageKeyDb {

        public void AddMessageKey(MessageKey messageKey) {
            var query =
                "INSERT INTO tblMessageKey(messageId, cryptingTypeId, keyId) VALUES(" +
                $"{messageKey.MessageId}" +
                $",{messageKey.CryptingTypeId}" +
                $",{messageKey.KeyId})";
            var c = new SqlConnector();
            var result = c.runCommand(query);
            if (result == -1) {
                throw new Exception("MessageKey cannot added to database");
            }
        }

    }

}