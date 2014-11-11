using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class readingCharacteristic
    {
        public int id { get; set; }
        public int sensorId { get; set; }
        public int apartmentId { get; set; }
        public double value { get; set; }
        public DateTime timestamp { get; set; }
    }
}
