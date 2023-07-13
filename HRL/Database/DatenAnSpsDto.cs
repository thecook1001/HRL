namespace HRL.Database
{
    public class DatenAnSpsDto
    {
        public int Id { get; set; }
        public bool AllgemeinWatchDog { get; set; }
        public bool AllgemeinStoerungQuittieren { get; set; }
        public int Auftraege0Art { get; set; }
        public int Auftraege0LagerId { get; set; }
        public int Auftraege0PositionXP { get; set; }
        public int Auftraege0PositionYP { get; set; }
        public int Auftraege0PositionZP { get; set; }
        public double Auftraege0Gewicht { get; set; }
    }
}