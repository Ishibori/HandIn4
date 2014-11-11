using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class sensorCharacteristic
    {
        public int Id { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public string externalRef { get; set; }
        public string calibrationEquation { get; set; }
        public string calibrationCoeff { get; set; }
        public DateTime calibrationDate { get; set; }
    }
}
