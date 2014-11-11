using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MeasurementCharacteristics
    {
        public int Id { get; set; }
        public int SensorId { get; set; }
        public int ApartmentId { get; set; }
        public double Value { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
