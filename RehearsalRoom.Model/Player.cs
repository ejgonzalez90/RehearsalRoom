using System.Collections.Generic;

namespace RehearsalRoom.Model
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string NickName { get; set; }

        public ICollection<Instrument> PlayerInstruments { get; set; }

        public ICollection<BandPlayer> PlayerBands { get; set; }
    }
}