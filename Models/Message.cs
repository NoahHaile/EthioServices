namespace EthioServices.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string senderName { get; set; }
        public string receiverName { get; set; }
        public string sender { get; set; }
        public string receiver { get; set; }
        public string text { get; set; }
        
        public bool read { get; set; }
    }
}
