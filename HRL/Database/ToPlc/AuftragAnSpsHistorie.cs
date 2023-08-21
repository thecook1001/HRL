namespace HRL.Database.ToPlc
{
    public class AuftragAnSpsHistorie
    {
        public int Id { get; set; }
        public short Art { get; set; }
        public short LagerId { get; set; }
        public short PositionXP { get; set; }
        public short PositionYP { get; set; }
        public short PositionZP { get; set; }
        public float Gewicht { get; set; }
        public DateTime ZeitStempel { get; set; }
    }
}