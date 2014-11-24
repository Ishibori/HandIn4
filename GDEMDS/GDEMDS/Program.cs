using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Timer;

namespace GDEMDS
{
    class Program
    {
        const int LIMIT = 11803;
        
        public static ITickTimer FLTimer { get; set; }
        public static int fileCounter = 1;
        public static JsonDownloader jsonDown = new JsonDownloader();
        public static CurrentModelHandler currentModelHandler = new CurrentModelHandler();
        public static HistoricModelHandler historicModelHandler = new HistoricModelHandler();

        static void Main(string[] args)
        {
            //var DBConfig = new JSONCharacteristics();
            //DBConfig.LoadJSON();

            //FLTimer = new FileLoadTimer(1); // set to 5000;
            //FLTimer.TickEvent += new TickTimer(LoadFiles);
            //FLTimer.StartTimer();
            
            //while (fileCounter <= 11803)
            //{
            //    LoadFiles();
            //    fileCounter++;
            //}


            var list = historicModelHandler.Load(new DateTime(2014, 11, 24, 16, 03, 00), new DateTime(2014, 11, 24, 16, 03, 15));
            foreach (var data in list)
            {
                Console.WriteLine(data);    
            }
            

            Console.ReadKey();
        }

        public static void LoadFiles()
        {
            //fileCounter++;
            if (fileCounter <= 11803)
            {
                Console.WriteLine("Downloaded file: " + fileCounter + ".json\n");
                var JsonString = jsonDown.GetJson("http://userportal.iha.dk/~jrt/i4dab/E14/HandIn4/dataGDL/data/"+fileCounter+".json");
                //Console.WriteLine(JsonString);
                historicModelHandler.Save(JsonString);
                currentModelHandler.Save(JsonString);
            }
            else
            {
                Console.WriteLine("All files have been downloaded");
            }
        }
    }
}
