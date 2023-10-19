using HRL.Database;
using HRL.Database.FromPlc;
using HRL.Database.Local;
using HRL.Database.ToPlc;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HRL.Classes
{
    public class JobsData
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

        public List<JobsData> GetJobsData()
        {
            using (var connection = new HRLContext())
            {
                var result = new List<JobsData>();
                try
                {
                    foreach(var jobs in connection.Jobs) 
                    {
                        result.Add(jobs.ToJobsData());
                    }
                }
                catch (Exception exception)
                {
                    FehlerMeldung(exception.Message);
                }
                return result;
            }
        }

        public JobsData FindJobsData(int id)
        {
            var result = new JobsData();
            using (var connection = new HRLContext())
            {
                try
                {

                    var jobs = connection.Find<Jobs>(id);
                    result = jobs.ToJobsData();
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

        public void DeleteEntry(int id)
        {
            using (var connection = new HRLContext())
            {
                try
                {
                    var JobsEntry = connection.Find<Jobs>(id);
                    connection.Remove(JobsEntry);
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

        public Jobs ToJobs(Jobs jobs)
        {
            jobs.Id = this.Id;
            jobs.Status = this.Status;
            jobs.Priority = this.Priority;
            jobs.Content = this.Content;
            jobs.NumberOfItems = this.NumberOfItems;
            jobs.TransportDateTime = this.TransportDateTime;
            jobs.Remarks = this.Remarks;
            jobs.Position = this.Position;
            jobs.Art = this.Art;
            jobs.LagerId = this.LagerId;
            jobs.PositionXP = this.PositionXP;
            jobs.PositionYP = this.PositionYP;
            jobs.PositionZP = this.PositionZP;
            jobs.Gewicht = this.Gewicht;
            return jobs;
        }

        public Jobs ToJobs()
        {
            var jobs = new Jobs();
            jobs.Id = this.Id;
            jobs.Status = this.Status;
            jobs.Priority = this.Priority;
            jobs.Content = this.Content;
            jobs.NumberOfItems = this.NumberOfItems;
            jobs.TransportDateTime = this.TransportDateTime;
            jobs.Remarks = this.Remarks;
            jobs.Position = this.Position;
            jobs.Art = this.Art;
            jobs.LagerId = this.LagerId;
            jobs.PositionXP = this.PositionXP;
            jobs.PositionYP = this.PositionYP;
            jobs.PositionZP = this.PositionZP;
            jobs.Gewicht = this.Gewicht;
            return jobs;
        }

    }

}
