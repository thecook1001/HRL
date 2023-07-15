using HRL.Database;
using Sharp7;

namespace DatenbankInBVLazor
{
    public class DataCrawler
    {
        public DataCrawler()
        {

        }

        public void Crawl()
        {
            while (true)
            {
                var sleepTime = 200;
                try
                {
                    Thread.Sleep(sleepTime);
                    using (var connection = new HRLContext()) // Funktione auslagern ALLES
                    {
                        bool keepRunning = true;
                        int result = 0;
                        int connErrors = 0;
                        int maxConnErrors = 5; //Max Anzahl an Versuchen bevor Abbruch
                        S7Client client = new S7Client();

                        keepRunning = VerbinbdungAufgbauen(client, "192.168.1.10", 0, 1);
                        if (!keepRunning)
                            return;

                        while (true)
                        {

                            //daten Lesen
                            byte[] db8BufferR = new byte[689];
                            byte[] db7BufferW = new byte[16];

                            result = client.DBRead(8, 0, 689, db8BufferR);
                            if (result != 0)
                            {
                                Console.WriteLine(result);
                                Console.WriteLine(client.ErrorText(result));
                                connErrors++;
                                if (connErrors >= maxConnErrors)
                                {
                                    return;
                                }
                            }


                            //Transportwagen Von SPS
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

                            //Fehlerliste Von SPS
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
                                FehlerlisteVonSpsResult1.Aktiv = S7.GetBitAt(db8BufferR, j+2, 0);
                                FehlerlisteVonSpsResult1.DatumUhrzeit = S7.GetDateTimeAt(db8BufferR, j+4);
                                FehlerlisteVonSpsResult1.Beschreibung = S7.GetStringAt(db8BufferR, j+12);
                                connection.SaveChanges();
                                j = j+64;
                            }

                            //Allgemein Von SPS
                            var AllgemeinVonSpsResult = connection.Find<AllgemeinVonSps>(1);
                            if (AllgemeinVonSpsResult == null)
                            {
                                AllgemeinVonSpsResult = new AllgemeinVonSps();
                                connection.AllgemeinesVonSps.Add(AllgemeinVonSpsResult);
                            }
                            AllgemeinVonSpsResult.Kommunikation = S7.GetBitAt(db8BufferR, 688, 0);
                            connection.SaveChanges();




                            //Allgemein An SPS
                            var AllgemeinAnSpsResult = connection.Find<AllgemeinAnSps>(1);
                            connection.Entry(AllgemeinAnSpsResult).Reload();    
                            if (AllgemeinAnSpsResult == null)
                            {
                                AllgemeinAnSpsResult = new AllgemeinAnSps();
                                connection.AllgemeinesAnSps.Add(AllgemeinAnSpsResult);
                            }
                            AllgemeinAnSpsResult.WatchDog = true;
                            connection.SaveChanges();

                            S7.SetBitAt(ref db7BufferW, 0, 0, AllgemeinAnSpsResult.WatchDog);
                            S7.SetBitAt(ref db7BufferW, 0, 1, AllgemeinAnSpsResult.StoerungQuittieren);
                            result = client.DBWrite(7, 0, 16, db7BufferW);










                            //Auftrag von SPS
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

                            result = client.DBWrite(7, 0, 16, db7BufferW);



                            //// Schreiben :D

                            //S7.SetBitAt(ref db2BufferW, 0, 0, true);
                            //S7.SetIntAt(db2BufferW, 2, int1W);
                            //S7.SetIntAt(db2BufferW, 4, int2W);
                            //S7.SetIntAt(db2BufferW, 6, int3W);
                            //S7.SetIntAt(db2BufferW, 8, int4W);


                            //result = client.DBWrite(2, 0, 10, db2BufferW);
                            //if (result == 0)
                            //{
                            //    Console.WriteLine("Daten Geschrieben !");
                            //}
                            //else
                            //{
                            //    Console.WriteLine("Fehler beim Schreiben !");
                            //    Console.Write("Fehler Code: ");
                            //    Console.WriteLine(result);
                            //    Console.Write("Fehler Text: ");
                            //    Console.WriteLine(client.ErrorText(result));
                            //    connErrors++;
                            //    if (connErrors >= maxConnErrors)
                            //    {
                            //        return;
                            //    }
                            //}

                        }
                        //client.WriteArea();
                        //client.ReadArea();
                    }
                }
                catch (Exception)
                {
                    sleepTime += 1000;
                    throw;
                }
            }
        }

        public static bool VerbinbdungAufgbauen(S7Client client, string ip, int rack, int slot)
        {
            //@See https://snap7.sourceforge.net/
            int result;
            client.SetConnectionType(3); //3 für weil 1=PG 2=OP
            client.ConnectTo(ip, rack, slot); //ConnectTo löst Connect aus!
            result = client.Connect(); //Verbindung Aufbauen
            if (result == 0)
            {
                Console.WriteLine("Verbindung zu CPU Aufgebaut !");
                return true;
            }
            else
            {
                Console.WriteLine("Fehler beim Verbindungs Aufbau !");
                Console.Write("Fehler Code: ");
                Console.WriteLine(result);
                Console.Write("Fehler Text: ");
                Console.WriteLine(client.ErrorText(result));
                Console.ReadKey();
                return false;
            }
        }





    }



}

