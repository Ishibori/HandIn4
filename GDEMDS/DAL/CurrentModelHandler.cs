using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DAL
{
    public class CurrentModelHandler
    {
        public void Save(string JsonToSave)
        {
            var DataContext = new EntityContext();
            JsonSerializer serializer = new JsonSerializer();
            JsonDownloader jd = new JsonDownloader();

            var tmpJSON = serializer.Deserialize<readingCharacteristic>(new JsonTextReader(new StringReader(JsonToSave)));

            foreach (var reading in tmpJSON.reading)
            {
                var measurement = new Measurement();
                measurement.TimeStamp = reading.timestamp;
                measurement.Value = reading.value;
                measurement.Sensor = DataContext.Sensors.Find(reading.sensorId);

                var tmpAppartment = DataContext.Appartments.Find(reading.appartmentId);
                if (tmpAppartment != null && DataContext.Sensors.Find(reading.sensorId)!=null)
                {
                    if (tmpAppartment.Sensors == null)
                        tmpAppartment.Sensors = new List<Sensor>();
                    if (!tmpAppartment.Sensors.Exists(i => i.SensorId == reading.sensorId))
                    {
                        tmpAppartment.Sensors.Add(DataContext.Sensors.Find(reading.sensorId));
                    }
                }
                DataContext.Measurements.Add(measurement);    
            }
            
            DataContext.SaveChanges();
        }
    }
}
