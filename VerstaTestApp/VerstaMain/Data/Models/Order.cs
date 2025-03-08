namespace VerstaMain.Data.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string SenderCity { get; set; } = null!;
        public string SenderHomeAddress { get; set; } = null!;
        public string ReceiverCity { get; set; } = null!;
        public string ReceiverHomeAddress { get; set; } = null!;
        public float OrderWeight { get; set; }
        public DateTimeOffset OrderPickupTime { get; set; }
        public DateTimeOffset CreationDate { get; set; }
    }
}
