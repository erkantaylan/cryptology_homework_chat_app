namespace LibDbOperations.Model {

    public class MessageKey {

        public int MessageKeyId { get; set; }
        public int MessageId { get; set; }
        public int CryptingTypeId { get; set; } = 1;
        public int KeyId { get; set; }
    }

}