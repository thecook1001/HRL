﻿using HRL.Database.FromPlc;
using HRL.Database.Local;
using HRL.Database.ToPlc;
using Microsoft.EntityFrameworkCore;
using HRL.Classes;

namespace HRL.Database
{
    public class HRLContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS; Database = HRL; Integrated Security = true; TrustServerCertificate = True;");
            //"server=127.0.0.1; database=test; Integrated Security=true; Encrypt=false; TrustServerCertificate=true"
        }
        public DbSet<TransportmaschineVonSps> TransportmaschinenVonSps { get; set; }
        public DbSet<FehlerlisteVonSps> FehlerlistenVonSps { get; set; }
        public DbSet<AllgemeinVonSps> AllgemeinesVonSps { get; set; }
        public DbSet<AllgemeinAnSps> AllgemeinesAnSps { get; set; }
        public DbSet<AuftragAnSps> AuftragAnSps { get; set; }
        public DbSet<FehlerLog> FehlerLogs { get; set; }
        public DbSet<StockSpace> StockSpaces { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
    }
}

//Nach Änderung Update-Database -Migration InitialCreate ausführen und eventuell Datenbank löschen im ManagmentStudio
//dotnet ef migrations add InitialCreate
//(Du hast letztes mal 3,5 Stunden nach dem Befehl gesucht...)