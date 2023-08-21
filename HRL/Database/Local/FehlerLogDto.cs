namespace HRL.Database.Local
{
    public class FehlerLogDto
    {
        public int Id { get; set; }
        public string? Meldung { get; set; }
        public DateTime DatumUhrzeit { get; set; }
    }
}