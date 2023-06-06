using HRL.Database;

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
                    using (var connection = new HRLContext())
                    {
                        //read Data

                        //Save Data
                    }
                }
                catch (Exception)
                {
                    sleepTime += 1000;
                    throw;
                }


            }
        }
    }
}
