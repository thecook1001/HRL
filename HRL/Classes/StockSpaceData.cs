using HRL.Database;
using HRL.Database.FromPlc;
using HRL.Database.Local;
using HRL.Database.ToPlc;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HRL.Classes
{
    public class StockSpaceData
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
        public string Remarks { get; set; }

        public List<StockSpaceData> GetStockData()
        {
            using (var connection = new HRLContext())
            {
                var result = new List<StockSpaceData>();
                try
                {
                    foreach(var stockSpace in connection.StockSpaces) 
                    {
                        result.Add(stockSpace.ToStockSpaceData());
                    }
                }
                catch (Exception exception)
                {
                    FehlerMeldung(exception.Message);
                }
                return result;
            }
        }

        public StockSpaceData FindCreateStockData(int id)
        {
            var result = new StockSpaceData();
            using (var connection = new HRLContext())
            {
                try
                {
                    
                    var stockSpace = connection.Find<StockSpace>(id);
                    if (stockSpace == null)
                    {
                        stockSpace = new StockSpace();
                        stockSpace.Id = id;
                        stockSpace.TransportId = 0;
                        stockSpace.Position = id;
                        stockSpace.Position = stockSpace.Position -1;
                        stockSpace.Status = "0";
                        stockSpace.Weight = 0;
                        stockSpace.Priority = 0;
                        stockSpace.Content = "Artikel Name";
                        stockSpace.NumberOfItems = 0;
                        stockSpace.PostingDateTime = DateTime.Now;
                        stockSpace.PostingUser = "USER";
                        stockSpace.TransportDateTime = DateTime.Now;
                        stockSpace.TransportUser = "USER";
                        stockSpace.Remarks = "Beschreibung";

                        connection.StockSpaces.Add(stockSpace);
                        connection.SaveChanges();
                    }
                    stockSpace = connection.Find<StockSpace>(id);
                    result = stockSpace.ToStockSpaceData();
                    connection.SaveChanges();
                }
                catch (Exception exception)
                {
                    FehlerMeldung(exception.Message);
                    FehlerMeldung(exception.InnerException.Message);
                }
                return result;
            }
        }

        public int FindStockData(int id)
        {
            var result = new StockSpaceData();
            using (var connection = new HRLContext())
            {
                try
                {

                    var stockSpace = connection.Find<StockSpace>(id);
                    stockSpace = connection.Find<StockSpace>(id);
                    if (stockSpace == null)
                    {
                        return 0;
                    }
                    else
                        return int.Parse(stockSpace.Status);
                }
                catch (Exception exception)
                {
                    FehlerMeldung(exception.Message);
                    FehlerMeldung(exception.InnerException.Message);
                    return 0;
                }
            }
        }

        public void AddEntry(StockSpaceData stockSpaceData)
        {
            using (var connection = new HRLContext())
            {
                try
                {
                    var StockSpaceResult = new StockSpace();
                    StockSpaceResult = stockSpaceData.ToStockSpace();
                    connection.StockSpaces.Add(StockSpaceResult);
                    connection.SaveChanges();
                }
                catch (Exception exception)
                {
                    FehlerMeldung(exception.Message);
                }
            }
        }

        public void ChangeEntry(int id, StockSpaceData stockSpaceData)
        {
            using (var connection = new HRLContext())
            {
                try
                {
                    var StockSpaceResult = connection.Find<StockSpace>(id);
                    StockSpaceResult = stockSpaceData.ToStockSpace();
                    connection.SaveChanges();
                }
                catch (Exception exception)
                {
                    FehlerMeldung(exception.Message);
                }
            }
        }

        public void DeleteEntry(int id)
        {
            using (var connection = new HRLContext())
            {
                try
                {
                    var StockSpaceEntry = connection.Find<StockSpace>(id);
                    connection.Remove(StockSpaceEntry);
                    connection.SaveChanges();
                }
                catch (Exception exception)
                {
                    FehlerMeldung(exception.Message);
                }
            }
        }

        private void FehlerMeldung(string fehlerText)
        {
            using (var connection = new HRLContext())
            {
                try
                {
                    var FehlerLogResult = new FehlerLog();
                    FehlerLogResult.Meldung = fehlerText;
                    FehlerLogResult.DatumUhrzeit = DateTime.Now;
                    connection.FehlerLogs.Add(FehlerLogResult);
                    connection.SaveChanges();
                }
                catch (Exception exception)
                {
                    FehlerMeldung(exception.Message);
                }
            }
        }

        public StockSpace ToStockSpace(StockSpace stockSpace)
        {
            stockSpace.Id = this.Id;
            stockSpace.TransportId = this.TransportId;
            stockSpace.Position = this.Position;
            stockSpace.Status = this.Status;
            stockSpace.Weight = this.Weight;
            stockSpace.Priority = this.Priority;
            stockSpace.Content = this.Content;
            stockSpace.NumberOfItems = this.NumberOfItems;
            stockSpace.PostingDateTime = this.PostingDateTime;
            stockSpace.PostingUser = this.PostingUser;
            stockSpace.TransportDateTime = this.TransportDateTime;
            stockSpace.TransportUser = this.TransportUser;
            stockSpace.Remarks = this.Remarks;
            return stockSpace;
        }

        public StockSpace ToStockSpace()
        {
            var data = new StockSpace();
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
