using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARS.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public int ReservationID { get; set; }
        [ForeignKey("ReservationID")]
        public Reservation Reservation { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string CardNumberMasked { get; set; }
        public string Type { get; set; }
        public string TransactionRef { get; set; }
    }
}
