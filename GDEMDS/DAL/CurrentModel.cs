using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Appartment
    {
        public int AppartmentId { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public double Size { get; set; }
        public List<Sensor> Sensors { get; set; } 
    }
    
    public class Sensor
    {
        public int SensorId { get; set; }
        public DateTime CalibrationDate { get; set; }
        public string CalibrationEquation { get; set; }
        public string CalibrationCoeff { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
    }

    public class Measurement
    {
        [Key]
        public int MeasurementId { get; set; }
        public DateTime TimeStamp { get; set; }
        public Sensor Sensor { get; set; }
        public double Value { get; set; } 
    }
}
