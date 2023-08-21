using HRL.Database;
using HRL.Database.FromPlc;
using HRL.Database.Local;
using HRL.Database.ToPlc;
using Sharp7;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DatenbankInBVLazor
{
    public class DataCrawler
    {
        public DataCrawler()
        {

        }

        public void Crawl()
        {
            S7Client client = new S7Client();
            //@See https://snap7.sourceforge.net/
            int result;
            var ip = "192.168.1.10";
            var rack = 0;
            var slot = 1;
            client.SetConnectionType(3);
            client.ConnectTo(ip, rack, slot);
            result = client.Connect();
            if (result == 0)
            {
                Console.WriteLine("Verbindung zu CPU Aufgebaut !");
            }
            else
            {
                Console.WriteLine("Fehler beim Verbindungs Aufbau !");
                Console.Write("Fehler Code: ");
                Console.WriteLine(result);
                Console.Write("Fehler Text: ");
                Console.WriteLine(client.ErrorText(result));
                Console.ReadKey();
            }
            while (true)
            {
                var sleepTime = 200;
                try
                {
                    Thread.Sleep(sleepTime);
                    {
                        while (true)
                        {
                            DatenLesen(TransportwagenDatenVonSpsLesen, client);
                            DatenLesen(FehlerlisteDatenVonSpsLesen, client);
                            DatenLesen(AllgemeinDatenVonSpsLesen, client);
                            DatenLesen(AllgemeinDatenAnSpsSchreiben, client);
                            DatenLesen(AuftragsDatenAnSpsSchreiben, client);
                        }
                    }
                }
                catch (Exception exception)
                {
                    FehlerMeldung(exception.Message);
                    sleepTime += 1000;
                    throw;
                }
            }
        }

        private void TransportwagenDatenVonSpsLesen(HRLContext connection, S7Client client)
        {
            byte[] db8BufferR = new byte[689];
            client.DBRead(8, 0, 689, db8BufferR);
            var TransportmaschineVonSpsResult = connection.Find<TransportmaschineVonSps>(1);
            if (TransportmaschineVonSpsResult == null)
            {
                TransportmaschineVonSpsResult = new TransportmaschineVonSps();
                connection.TransportmaschinenVonSps.Add(TransportmaschineVonSpsResult);
            }
            TransportmaschineVonSpsResult.Name = S7.GetStringAt(db8BufferR, 0);
            TransportmaschineVonSpsResult.SollPositionX = S7.GetRealAt(db8BufferR, 8);
            TransportmaschineVonSpsResult.SollPositionY = S7.GetRealAt(db8BufferR, 12);
            TransportmaschineVonSpsResult.SollPositionZ = S7.GetRealAt(db8BufferR, 16);
            TransportmaschineVonSpsResult.SollPositionXP = S7.GetIntAt(db8BufferR, 20);
            TransportmaschineVonSpsResult.SollPositionYP = S7.GetIntAt(db8BufferR, 22);
            TransportmaschineVonSpsResult.SollPositionZP = S7.GetIntAt(db8BufferR, 24);
            TransportmaschineVonSpsResult.IstPositionX = S7.GetRealAt(db8BufferR, 26);
            TransportmaschineVonSpsResult.IstPositionY = S7.GetRealAt(db8BufferR, 30);
            TransportmaschineVonSpsResult.IstPositionZ = S7.GetRealAt(db8BufferR, 34);
            TransportmaschineVonSpsResult.IstPositionXP = S7.GetIntAt(db8BufferR, 38);
            TransportmaschineVonSpsResult.IstPositionYP = S7.GetIntAt(db8BufferR, 40);
            TransportmaschineVonSpsResult.IstPositionZP = S7.GetIntAt(db8BufferR, 42);
            TransportmaschineVonSpsResult.Zustand = S7.GetIntAt(db8BufferR, 44);
            TransportmaschineVonSpsResult.BelegungPhysisch = S7.GetBitAt(db8BufferR, 46, 0);
            connection.SaveChanges();
        }

        private void FehlerlisteDatenVonSpsLesen(HRLContext connection, S7Client client)
        {
            byte[] db8BufferR = new byte[689];
            client.DBRead(8, 0, 689, db8BufferR);
            int j = 48;
            for (int i = 1; i < 11; i++)
            {
                var FehlerlisteVonSpsResult1 = connection.Find<FehlerlisteVonSps>(i);
                if (FehlerlisteVonSpsResult1 == null)
                {
                    FehlerlisteVonSpsResult1 = new FehlerlisteVonSps();
                    connection.FehlerlistenVonSps.Add(FehlerlisteVonSpsResult1);
                }
                FehlerlisteVonSpsResult1.Nr = S7.GetIntAt(db8BufferR, j);
                FehlerlisteVonSpsResult1.Aktiv = S7.GetBitAt(db8BufferR, j + 2, 0);
                FehlerlisteVonSpsResult1.DatumUhrzeit = S7.GetDateTimeAt(db8BufferR, j + 4);
                FehlerlisteVonSpsResult1.Beschreibung = S7.GetStringAt(db8BufferR, j + 12);
                connection.SaveChanges();
                j = j + 64;
            }
        }

        private void AllgemeinDatenVonSpsLesen(HRLContext connection, S7Client client)
        {
            byte[] db8BufferR = new byte[689];
            client.DBRead(8, 0, 689, db8BufferR);
            var AllgemeinVonSpsResult = connection.Find<AllgemeinVonSps>(1);
            if (AllgemeinVonSpsResult == null)
            {
                AllgemeinVonSpsResult = new AllgemeinVonSps();
                connection.AllgemeinesVonSps.Add(AllgemeinVonSpsResult);
            }
            AllgemeinVonSpsResult.Kommunikation = S7.GetBitAt(db8BufferR, 688, 0);
            connection.SaveChanges();
        }

        private void AllgemeinDatenAnSpsSchreiben(HRLContext connection, S7Client client)
        {
            byte[] db7BufferW = new byte[16];
            var AllgemeinAnSpsResult = connection.Find<AllgemeinAnSps>(1);
            if (AllgemeinAnSpsResult == null)
            {
                AllgemeinAnSpsResult = new AllgemeinAnSps();
                connection.AllgemeinesAnSps.Add(AllgemeinAnSpsResult);
            }
            AllgemeinAnSpsResult.WatchDog = true;
            connection.SaveChanges();
            S7.SetBitAt(ref db7BufferW, 0, 0, AllgemeinAnSpsResult.WatchDog);
            S7.SetBitAt(ref db7BufferW, 0, 1, AllgemeinAnSpsResult.StoerungQuittieren);
            client.DBWrite(7, 0, 1, db7BufferW);
        }

        private void AuftragsDatenAnSpsSchreiben(HRLContext connection, S7Client client)
        {
            byte[] db7BufferW = new byte[16];
            var AuftragAnSpsResult = connection.Find<AuftragAnSps>(1);
            if (AuftragAnSpsResult == null)
            {
                AuftragAnSpsResult = new AuftragAnSps();
                connection.AuftraegeAnSps.Add(AuftragAnSpsResult);
            }
            connection.SaveChanges();
            S7.SetIntAt(db7BufferW, 2, AuftragAnSpsResult.Art);
            S7.SetIntAt(db7BufferW, 4, AuftragAnSpsResult.LagerId);
            S7.SetIntAt(db7BufferW, 6, AuftragAnSpsResult.PositionXP);
            S7.SetIntAt(db7BufferW, 8, AuftragAnSpsResult.PositionYP);
            S7.SetIntAt(db7BufferW, 10, AuftragAnSpsResult.PositionZP);
            S7.SetRealAt(db7BufferW, 12, AuftragAnSpsResult.Gewicht);
            client.DBWrite(7, 2, 16, db7BufferW);
        }

        private void DatenLesen(Action<HRLContext,S7Client> verarbeiteDaten, S7Client client)
        {
            using (var connection = new HRLContext())
            {
                try
                {
                    verarbeiteDaten(connection,client);
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
    }
}

