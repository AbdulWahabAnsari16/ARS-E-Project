using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARS.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerID { get; set; }
        public int ReservationID { get; set; }
        [ForeignKey("ReservationID")]
        public Reservation Reservation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AgeCategory { get; set; }
    }
}
