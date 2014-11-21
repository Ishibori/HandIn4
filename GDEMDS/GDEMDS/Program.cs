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
        public static ITickTimer FLTimer { get; set; }
        
        static void Main(string[] args)
        {
            FLTimer = new FileLoaderTimer(5000);
            FLTimer.TickEvent += new TickTimer(WriteToScreen);
            FLTimer.StartTimer();
            //var jsonDown = new JsonDownloader();
            //Console.WriteLine(jsonDown.GetJson("http://userportal.iha.dk/~jrt/i4dab/E14/HandIn4/GFKRE0031_sample.txt"));

            //var JSONChar = new JSONCharacteristics();
            //JSONChar.LoadJSON();

            Console.ReadKey();
        }

        public static void WriteToScreen()
        {
            Console.WriteLine("test");
        }
    }
}
