using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RehearsalRoom.Model
{
    public class Room
    {
        public int RoomId { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        public ICollection<Instrument> Instruments { get; set; }
        public ICollection<Turn> Turns { get; set; }
    }
}
