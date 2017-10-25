using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RehearsalRoom.Model
{
    public class BandPlayer
    {
        public int BandId { get; set; }
        public Band Band { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
