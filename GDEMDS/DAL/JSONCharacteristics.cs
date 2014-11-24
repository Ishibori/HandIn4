using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
            var db = new EntityContext();
            
            foreach (var characteristic in sensorCharacteristic)
            {
                var tmpSensor = new Sensor();
                tmpSensor.CalibrationCoeff = characteristic.calibrationCoeff;
                tmpSensor.CalibrationDate = characteristic.calibrationDate;
                tmpSensor.CalibrationEquation = characteristic.calibrationEquation;
                tmpSensor.SensorId = characteristic.sensorId;
                db.Sensors.AddOrUpdate(tmpSensor);
                Console.WriteLine("SensorID: " + tmpSensor.SensorId);
            }

            foreach (var characteristic in appartmentCharacteristic)
            {
                var tmpAppartment = new Appartment();
                tmpAppartment.AppartmentId = characteristic.appartmentId;
                tmpAppartment.Number = characteristic.no;
                tmpAppartment.Size = characteristic.size;
                tmpAppartment.Floor = characteristic.floor;
                db.Appartments.AddOrUpdate(tmpAppartment);
                Console.WriteLine("AppartmentID: " + tmpAppartment.AppartmentId);
            }

            db.SaveChanges();
            Console.WriteLine("Configuration saved");
        }
    }
}
