using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARS.Models
{
    public class ItinerarySegment
    {
        [Key]
        public int SegmentID { get; set; }

        public int ReservationID { get; set; }
        [ForeignKey("ReservationID")]
        public Reservation Reservation { get; set; }

        public int ScheduleID { get; set; }
        [ForeignKey("ScheduleID")]
        public FlightSchedule Schedule { get; set; }

        public int SegmentNumber { get; set; }
    }
}
