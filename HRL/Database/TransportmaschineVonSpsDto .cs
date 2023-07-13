namespace HRL.Database
{
    public class TransportmaschineVonSpsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float SollPositionX { get; set; }
        public float SollPositionY { get; set; }
        public float SollPositionZ { get; set; }
        public int SollPositionXP { get; set; }
        public int SollPositionYP { get; set; }
        public int SollPositionZP { get; set; }
        public float IstPositionX { get; set; }
        public float IstPositionY { get; set; }
        public float IstPositionZ { get; set; }
        public int IstPositionXP { get; set; }
        public int IstPositionYP { get; set; }
        public int IstPositionZP { get; set; }
        public int Zustand { get; set; }
        public bool BelegungPhysisch { get; set; }
    }
}