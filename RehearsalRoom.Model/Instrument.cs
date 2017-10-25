namespace RehearsalRoom.Model
{
    public enum InstrumentState
    {
        Ok,
        OnRepair        
    }

    public class Instrument
    {
        public int InstrumentId { get; set; }
        public int BrandId { get; set; }
        public int BrandModelId { get; set; }
        public int? RoomId { get; set; }
        public InstrumentState State { get; set; }

        public InstrumentBrand InstrumentBrand { get; set; }
        public BrandModel InstrumentModel { get; set; }
        public Room InstrumentCurrentRoom { get; set; }
    }
}