using HRL.Classes;

namespace HRL.Database.Local
{
    public class Jobs
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int Priority { get; set; }
        public string Content { get; set; }
        public int NumberOfItems { get; set; }
        public DateTime TransportDateTime { get; set; }
        public string? Remarks { get; set; }
        public int Position { get; set; }
        public short Art { get; set; }
        public short LagerId { get; set; }
        public short PositionXP { get; set; }
        public short PositionYP { get; set; }
        public short PositionZP { get; set; }
        public float Gewicht { get; set; }

        public JobsData ToJobsData()
        {
            var data = new JobsData();
            data.Id = this.Id;
            data.Status = this.Status;
            data.Priority = this.Priority;
            data.Content = this.Content;
            data.NumberOfItems = this.NumberOfItems;
            data.TransportDateTime = this.TransportDateTime;
            data.Remarks = this.Remarks;
            data.Position = this.Position;
            data.PositionXP = this.PositionXP;
            data.PositionYP = this.PositionYP;
            data.PositionZP = this.PositionZP;
            data.Gewicht = this.Gewicht;
            return data;
        }
    }
}