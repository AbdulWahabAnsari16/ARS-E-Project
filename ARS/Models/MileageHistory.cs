using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARS.Models
{
    public class MileageHistory
    {
        [Key]
        public int EntryID { get; set; }
        public int ReservationID { get; set; }
        [ForeignKey("ReservationID")]
        public Reservation Reservation { get; set; }
        public int MilesDelta { get; set; }
        public DateOnly EntryDate { get; set; }
        public string Reason { get; set; }
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
    }
}
