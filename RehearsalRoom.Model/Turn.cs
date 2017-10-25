using System;

namespace RehearsalRoom.Model
{
    public class Turn
    {
        public int TurnId { get; set; }
        public DateTime DateFrom { get; set; }
        public int IntervalId { get; set; }
        public DateTime DateTo {
            get
            {
                return DateTo;
            }
            set
            {
                this.DateTo = DateTo.AddHours(this.TurnInterval.Duration);
            }
        }
        public int RoomId { get; set; }
        public int BandId { get; set; }

        public Interval TurnInterval { get; set; }
        public Room TurnRoom { get; set; }
        public Band TurnBand { get; set; }
    }
}