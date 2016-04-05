namespace LibDbOperations.Model {

    public class SaltyUser : User {

        public string Salt { get; set; }
        public string Hash { get; set; }
        
    }

}