namespace LibDbOperations.Model {

    public class ViewMessage {

        public int MessageId { get; set; }
        public string SenderUsername { get; set; }
        public string ReceiverUsername { get; set; }
        public string Text { get; set; }
        public string ClearText { get; set; }

    }

}