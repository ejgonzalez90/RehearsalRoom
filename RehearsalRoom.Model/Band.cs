using System;
using System.Collections.Generic;
using System.Text;

namespace RehearsalRoom.Model
{
    public class Band
    {
        public int BandId { get; set; }
        public string Name { get; set; }

        public ICollection<BandPlayer> BandPlayers { get; set; }
        public ICollection<Turn> BandTurn { get; set; }
    }
}
