using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DAL
{
    public class JSONCharacteristics
    {
        public DateTime timestamp { get; set; }
        public List<sensorCharacteristic> sensorCharacteristic { get; set; }
        public List<appartmentCharacteristic> appartmentCharacteristic { get; set; }
        public int version { get; set; }

        public void LoadJSON()
        {
            JsonSerializer serializer = new JsonSerializer();
            JsonDownloader jd = new JsonDownloader();

            var tmpJSON = serializer.Deserialize<JSONCharacteristics>(new JsonTextReader(new StringReader(jd.GetJson("http://userportal.iha.dk/~jrt/i4dab/E14/HandIn4/GFKSC0021_sample.txt"))));
            
            timestamp = tmpJSON.timestamp;
            sensorCharacteristic = tmpJSON.sensorCharacteristic; 
            appartmentCharacteristic = tmpJSON.appartmentCharacteristic;
            version = tmpJSON.version;
        }
    }
}
