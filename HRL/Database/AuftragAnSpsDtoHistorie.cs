namespace HRL.Database
{
    public class AuftragAnSpsDtoHistorie
    {
        public int Id { get; set; }
        public int Auftraege0Art { get; set; }
        public int Auftraege0LagerId { get; set; }
        public int Auftraege0PositionXP { get; set; }
        public int Auftraege0PositionYP { get; set; }
        public int Auftraege0PositionZP { get; set; }
        public double Auftraege0Gewicht { get; set; }
        public DateTime ZeitStempel { get; set; }
    }
}