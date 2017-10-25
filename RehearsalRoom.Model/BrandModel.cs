namespace RehearsalRoom.Model
{
    public class BrandModel
    {
        public int BrandModelId { get; set; }        
        public string Name { get; set; }
        public int InstrumentBrandId { get; set; }

        public InstrumentBrand BrandModelInstrumentBrand { get; set; }
    }
}