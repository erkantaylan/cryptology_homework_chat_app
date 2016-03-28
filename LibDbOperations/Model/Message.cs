namespace LibDbOperations.Model {

    public class Message {

        public int MessageId { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public string Text { get; set; }

    }

}