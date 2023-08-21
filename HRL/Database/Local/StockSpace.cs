using HRL.Classes;

namespace HRL.Database
{
    public class StockSpace
    {
        public int Id { get; set; }
        public short TransportId { get; set; }
        public int Position { get; set; }
        public string Status { get; set; }
        public float Weight { get; set; }
        public int Priority { get; set; }
        public string Content { get; set; }
        public int NumberOfItems { get; set; }
        public DateTime PostingDateTime { get; set; }
        public string PostingUser { get; set; }
        public DateTime TransportDateTime { get; set; }
        public string TransportUser { get; set; }
        public string? Remarks { get; set; }

        public StockSpaceData ToStockSpaceData()
        {
            var data = new StockSpaceData();
            data.Id = this.Id;
            data.TransportId = this.TransportId;
            data.Position = this.Position;
            data.Status = this.Status;
            data.Weight = this.Weight;
            data.Priority = this.Priority;
            data.Content = this.Content;
            data.NumberOfItems = this.NumberOfItems;
            data.PostingDateTime = this.PostingDateTime;
            data.PostingUser = this.PostingUser;
            data.TransportDateTime = this.TransportDateTime;
            data.TransportUser = this.TransportUser;
            data.Remarks = this.Remarks;
            return data;
        }
    }
}