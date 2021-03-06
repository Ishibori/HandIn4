﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DAL
{
    public class CurrentModelHandler
    {
        public Sensor LoadSensorInformation(int sensorId)
        {
            var DataContext = new EntityContext();
            return DataContext.Sensors.Find(sensorId);
        }

        public List<Measurement> LoadSensorMeasurements(int sensorId)
        {
            List<Measurement> resultList;
            var DataContext = new EntityContext();
            resultList = (DataContext.Measurements.Where(m => m.Sensor.SensorId == sensorId).Include(s => s.Sensor)).ToList();
            return resultList;
        }

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
