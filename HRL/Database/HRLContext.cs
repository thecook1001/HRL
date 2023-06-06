using Microsoft.EntityFrameworkCore;

namespace HRL.Database
{
    public class HRLContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (local)\\SQLEXPRESS; Database = HRL; Integrated Security = true; TrustServerCertificate = True; ");
            //"server=127.0.0.1; database=test; Integrated Security=true; Encrypt=false; TrustServerCertificate=true"
        }

        //public DbSet<Human> Humanes { get; set; }
    }
}
