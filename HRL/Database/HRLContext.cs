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

        public DbSet<DatenAnSps> DatenAnSps { get; set; }
        public DbSet<DatenAnSpsHistorie> DatenAnSpsHistorie { get; set; }
        public DbSet<TransportmaschineVonSps> TransportmaschinenVonSps { get; set; }
        public DbSet<FehlerlisteVonSps> FehlerlistenVonSps { get; set; }
        public DbSet<AllgemeinVonSps> AllgemeinesVonSps { get; set; }
    }
}

//Nach Änderung Update-Database -Migration InitialCreate ausführen und eventuell Datenbank löschen im ManagmentStudio
//dotnet ef migrations add InitialCreate
//(Du hast letztes mal 3,5 Stunden nach dem Befehl gesucht...)