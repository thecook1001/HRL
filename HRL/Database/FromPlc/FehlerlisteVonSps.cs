namespace HRL.Database.FromPlc
{
    public class FehlerlisteVonSps
    {
        public int Id { get; set; }
        public int Nr { get; set; }
        public bool Aktiv { get; set; }
        public DateTime DatumUhrzeit { get; set; }
        public string? Beschreibung { get; set; }
    }
}