using Sharp7;

namespace HRL.Service
{
    public class PlcConnectionService : IPlcConnectionService
    {
        private readonly ILogger<PlcConnectionService> logger;
        private S7Client _client;
        int result = 0;
        int maxConnErrors = 5; //Max Anzahl an Versuchen bevor Abbruch

        public PlcConnectionService(ILogger<PlcConnectionService> logger)
        {
            this.logger = logger;
        }


        public void Connect()
        {
            bool keepRunning = true;
            this._client = new S7Client();

            keepRunning = OpenConnection(this._client, "192.168.1.10", 0, 1);
            if (!keepRunning)
                return;
        }

        public bool OpenConnection(S7Client client, string ip, int rack, int slot)
        {
            //@See https://snap7.sourceforge.net/
            int result;
            client.SetConnectionType(3); //3 für weil 1=PG 2=OP
            client.ConnectTo(ip, rack, slot); //ConnectTo löst Connect aus!
            result = client.Connect(); //Verbindung Aufbauen
            if (result == 0)
            {
                logger.LogDebug("Verbindung zu CPU Aufgebaut !");
                return true;
            }
            else
            {
                logger.LogDebug("Fehler beim Verbindungs Aufbau !");
                Console.Write("Fehler Code: ");
                logger.LogDebug($"{result}");
                Console.Write("Fehler Text: ");
                logger.LogDebug(client.ErrorText(result));
                Console.ReadKey();
                return false;
            }
        }


        public void PollData()
        {
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

                result = this._client.DBRead(1, 0, 10, db1BufferR);
                if (result == 0)
                {
                    logger.LogDebug("Daten Gelesen !");
                }
                else
                {
                    logger.LogDebug("Fehler beim Lesen !");
                    Console.Write("Fehler Code: ");
                    logger.LogDebug($"{result}");
                    Console.Write("Fehler Text: ");
                    logger.LogDebug(this._client.ErrorText(result));
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

                logger.LogDebug("Daten:");
                logger.LogDebug($"{WatchdogR}");
                logger.LogDebug($"{int1R}");
                logger.LogDebug($"{int2R}");
                logger.LogDebug($"{int3R}");
                logger.LogDebug($"{int4R}");

                // Schreiben :D

                S7.SetBitAt(ref db2BufferW, 0, 0, true);
                S7.SetIntAt(db2BufferW, 2, int1W);
                S7.SetIntAt(db2BufferW, 4, int2W);
                S7.SetIntAt(db2BufferW, 6, int3W);
                S7.SetIntAt(db2BufferW, 8, int4W);


                result = this._client.DBWrite(2, 0, 10, db2BufferW);
                if (result == 0)
                {
                    logger.LogDebug("Daten Geschrieben !");
                }
                else
                {
                    logger.LogDebug("Fehler beim Schreiben !");
                    Console.Write("Fehler Code: ");
                    logger.LogDebug($"{result}");
                    Console.Write("Fehler Text: ");
                    logger.LogDebug(this._client.ErrorText(result));
                    connErrors++;
                    if (connErrors >= maxConnErrors)
                    {
                        return;
                    }
                }

            }
        }
    }

    public interface IPlcConnectionService
    {
        void Connect();
        void PollData();
    }
}


