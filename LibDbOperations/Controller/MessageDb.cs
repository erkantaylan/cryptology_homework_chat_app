using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;

using LibDbOperations.Model;

namespace LibDbOperations.Controller {

    public class MessageDb : IMessageDb {

        public List<ViewMessage> GetMessages(string receiverUsername, string senderUsername) {
            var query = $"SELECT * FROM viewMessagesWithUserNames " +
                        $"WHERE (sender='{senderUsername}' AND receiver='{receiverUsername}') OR " +
                        $"(receiver='{senderUsername}' AND sender='{receiverUsername}')";
            return GetMessages(query);
        }

        public List<ViewMessage> GetMessages() {
            var query = $"SELECT * FROM viewMessagesWithUserNames ";
            return GetMessages(query);
        }

        public int AddMessage(Message message) {
            var query = $"INSERT INTO tblMessage(fromId, toId, message) VALUES(" +
                        $"{message.FromId},{message.ToId},'{message.Text}')";
            var c = new SqlConnector();
            var result = c.runCommand(query);
            if (result == -1) {
                throw new Exception("The message cannot be added to database!");
            }
            return GetMessageId(message.FromId, message.ToId, message.Text);
        }

        private int GetMessageId(int senderId, int receiverId, string text) {
            var query = $"SELECT messageId FROM tblMessage " +
                        $"WHERE " +
                        $"fromId={senderId} AND " +
                        $"toId={receiverId} AND " +
                        $"message='{text}'";
            var table = GetTable(query);
            if (table.Rows.Count > 0) {
                return Convert.ToInt32(table.Rows[0][0].ToString());
            }
            throw new SqlNotFilledException();
        }

        private List<ViewMessage> GetMessages(string query) {
            var table = GetTable(query);
            var rowsCount = table.Rows.Count;
            if (rowsCount > 0) {
                var messages = new List<ViewMessage>(rowsCount);
                for (var i = 0; i < rowsCount; i++) {
                    var currentRow = table.Rows[i];
                    messages.Add(
                        new ViewMessage {
                            MessageId = Convert.ToInt32(currentRow[0].ToString()),
                            SenderUsername = currentRow[2].ToString(),
                            ReceiverUsername = currentRow[3].ToString(),
                            Text = currentRow[1].ToString()
                        });
                }
                return messages;
            }
            return null;
        }

        private DataTable GetTable(string query) {
            var c = new SqlConnector();
            var table = c.SelectTable(query);
            return table;
        }

    }

}