using System.ComponentModel.DataAnnotations;

namespace VerstaMain.Models
{
    public class AddOrderModel
    {
        [Required(ErrorMessage = "Введите город отправителя")]
        public string SenderCity { get; set; } = null!;
        [Required(ErrorMessage = "Введите адрес отправителя")]
        public string SenderHomeAddress { get; set; } = null!;
        [Required(ErrorMessage = "Введите город получателя")]
        public string ReceiverCity { get; set; } = null!;
        [Required(ErrorMessage = "Введите адрес получателя")]
        public string ReceiverHomeAddress { get; set; } = null!;
        [Required(ErrorMessage = "Введите вес груза")]
        public float OrderWeight { get; set; }
        [Required(ErrorMessage = "Введите дату забора груза")]
        public DateTimeOffset OrderPickupTime { get; set; }
    }
}
