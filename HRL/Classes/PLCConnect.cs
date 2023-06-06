using Sharp7;

namespace HRL.Classes
{
    public class PLCConnect
    {
        public void OpenConnection()
        {
            bool keepRunning = true;
            int result = 0;
            int maxConnErrors = 5; //Max Anzahl an Versuchen bevor Abbruch
            S7Client client = new S7Client();

            keepRunning = VerbinbdungAufbauen(client, "192.168.1.10", 0, 1);
            if (!keepRunning)
                return;


            while (true)
            {

                //daten Lesen
                bool WatchdogR = false;
                int int1R, int2R, int3R, int4R = 0;
                short int1W = 100;
                short int2W = 200;
                short int3W = 300;
                short int4W = 400;
                byte[] db1BufferR = new byte[10];
                byte[] db2BufferW = new byte[10];
                int connErrors = 0;

                result = client.DBRead(1, 0, 10, db1BufferR);
                if (result == 0)
                {
                    Console.WriteLine("Daten Gelesen !");
                }
                else
                {
                    Console.WriteLine("Fehler beim Lesen !");
                    Console.Write("Fehler Code: ");
                    Console.WriteLine(result);
                    Console.Write("Fehler Text: ");
                    Console.WriteLine(client.ErrorText(result));
                    connErrors++;
                    if (connErrors >= maxConnErrors)
                    {
                        return;
                    }
                }
                WatchdogR = S7.GetBitAt(db1BufferR, 0, 0);
                int1R = S7.GetIntAt(db1BufferR, 2);
                int2R = S7.GetIntAt(db1BufferR, 4);
                int3R = S7.GetIntAt(db1BufferR, 6);
                int4R = S7.GetIntAt(db1BufferR, 8);

                Console.WriteLine("Daten:");
                Console.WriteLine(WatchdogR);
                Console.WriteLine(int1R);
                Console.WriteLine(int2R);
                Console.WriteLine(int3R);
                Console.WriteLine(int4R);

                // Schreiben :D

                S7.SetBitAt(ref db2BufferW, 0, 0, true);
                S7.SetIntAt(db2BufferW, 2, int1W);
                S7.SetIntAt(db2BufferW, 4, int2W);
                S7.SetIntAt(db2BufferW, 6, int3W);
                S7.SetIntAt(db2BufferW, 8, int4W);


                result = client.DBWrite(2, 0, 10, db2BufferW);
                if (result == 0)
                {
                    Console.WriteLine("Daten Geschrieben !");
                }
                else
                {
                    Console.WriteLine("Fehler beim Schreiben !");
                    Console.Write("Fehler Code: ");
                    Console.WriteLine(result);
                    Console.Write("Fehler Text: ");
                    Console.WriteLine(client.ErrorText(result));
                    connErrors++;
                    if (connErrors >= maxConnErrors)
                    {
                        return;
                    }
                }

            }



            //client.WriteArea();
            //client.ReadArea();
            Console.WriteLine("Programm Ende");
            Console.ReadLine();

        }



        #region Methoden

        public static bool VerbinbdungAufbauen(S7Client client, string ip, int rack, int slot)
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

        #endregion
    }
}

