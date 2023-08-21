namespace HRL.Database.Local
{
    public class FehlerLog
    {
        public int Id { get; set; }
        public string? Meldung { get; set; }
        public DateTime DatumUhrzeit { get; set; }
    }
}