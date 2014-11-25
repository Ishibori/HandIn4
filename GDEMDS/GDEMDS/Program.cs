using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        public static int timesToRun = 0;
        public static JsonDownloader jsonDown = new JsonDownloader();
        public static CurrentModelHandler currentModelHandler = new CurrentModelHandler();
        public static HistoricModelHandler historicModelHandler = new HistoricModelHandler();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("---------- MAIN MENU ----------");
                Console.WriteLine("(1) Load system characteristics");
                Console.WriteLine("(2) Fetch five JSON files (one file / 5 seconds)");
                Console.WriteLine("(3) Display sensor information");
                Console.WriteLine("(4) Get Measurements from sensor");
                Console.WriteLine("(5) Load and display historic data (raw json)");
                Console.WriteLine("(6) Quit Program");

                var result = Console.ReadLine();

                switch (result)
                {
                    case "1":
                    {
                        var DBConfig = new JSONCharacteristics();
                        DBConfig.LoadJSON();
                        break;
                    }
                    case "2":
                    {
                        timesToRun = 5;
                        fileCounter = 800; // 1-700 already loaded into database
                        FLTimer = new FileLoadTimer(5000); // set to 5000;
                        FLTimer.TickEvent += new TickTimer(LoadFiles);
                        FLTimer.StartTimer();
                        while (timesToRun > 0)
                        {
                            
                        }
                        break;
                    }
                    case "3":
                    {
                        bool validNum = false;
                        int readresultcasethree = 0;
                        while (!validNum)
                        {
                            Console.Write("Enter sensor id to display: ");
                            validNum = int.TryParse(Console.ReadLine(),out readresultcasethree);
                        }
                        // Retrieving Sensor information
                        Sensor testSensor = currentModelHandler.LoadSensorInformation(readresultcasethree);
                        Console.WriteLine(string.Format("SensorID: {0}\n Description: {1}\n Unit: {2}\n", testSensor.SensorId, testSensor.Description, testSensor.Unit));
                        
                        break;
                    }
                    case "4":
                    {
                        bool validNum = false;
                        int readresultcasefour = 0;
                        while (!validNum)
                        {
                            Console.Write("Enter sensor id to display measurements for: ");
                            validNum = int.TryParse(Console.ReadLine(), out readresultcasefour);
                        }
                        // Retrieving Sensor Measurements
                        var measurementList = currentModelHandler.LoadSensorMeasurements(readresultcasefour);
                        Console.WriteLine("SensorID: " + measurementList[0].Sensor.SensorId);
                        if (measurementList.Count > 0){
                            
                            foreach (var measurement in measurementList)
                            {
                                Console.WriteLine("Timestamp: {0} Reading: {1} {2}", measurement.TimeStamp, measurement.Value, measurement.Sensor.Unit);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No measurements found!"); 
                        }
                        break;
                    }
                    case "5":
                    {
                        // Get historic data
                        DateTime t1 = new DateTime(2014, 11, 24, 16, 03, 00);
                        DateTime t2 = new DateTime(2014, 11, 24, 16, 03, 15);
                        Console.WriteLine("Historic data between: {0} AND {1}", t1, t2);
                        var list = historicModelHandler.Load(t1, t2);
                        foreach (var data in list)
                        {
                            Console.WriteLine(data);
                        }
                        break;
                    }
                    case "6":
                    {
                        Environment.Exit(0);
                        break;
                    }
                    default: {Console.WriteLine("Invalid choice!");
                        break;
                    }
                        
                }
            }

            Console.ReadKey();
        }

        public static void LoadFiles()
        {
            if (timesToRun > 0)
            {
                fileCounter++;
                if (fileCounter <= 11803)
                {
                    var JsonString =
                        jsonDown.GetJson("http://userportal.iha.dk/~jrt/i4dab/E14/HandIn4/dataGDL/data/" + fileCounter +
                                         ".json");
                    Console.WriteLine("Downloaded file: " + fileCounter + ".json\n");
                    historicModelHandler.Save(JsonString);
                    currentModelHandler.Save(JsonString);
                }
                else
                {
                    Console.WriteLine("All files have been downloaded");
                }
                timesToRun--;
            }
        }
    }
}
