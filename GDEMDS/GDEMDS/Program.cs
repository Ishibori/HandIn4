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
        public static int fileCounter = 0;
        public static JsonDownloader jsonDown = new JsonDownloader();

        static void Main(string[] args)
        {
            FLTimer = new FileLoadTimer(5000);
            FLTimer.TickEvent += new TickTimer(LoadFiles);
            FLTimer.StartTimer();
            //var jsonDown = new JsonDownloader();
            //Console.WriteLine(jsonDown.GetJson("http://userportal.iha.dk/~jrt/i4dab/E14/HandIn4/GFKRE0031_sample.txt"));

            //var JSONChar = new JSONCharacteristics();
            //JSONChar.LoadJSON();



            Console.ReadKey();
        }

        public static void LoadFiles()
        {
            fileCounter++;
            if (fileCounter <= 11803)
            {
                Console.WriteLine("Downloaded file: " + fileCounter + ".json\n");
                Console.WriteLine(jsonDown.GetJson("http://userportal.iha.dk/~jrt/i4dab/E14/HandIn4/dataGDL/data/"+fileCounter+".json"));

            }
            else
            {
                Console.WriteLine("All files have been downloaded");
            }
        }
    }
}
