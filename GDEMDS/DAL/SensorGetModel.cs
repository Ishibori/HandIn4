using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SensorGetModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string ExternalRef { get; set; }
        public string CalibrationEquation { get; set; }
        public string CalibrationCoeff { get; set; }
        public DateTime CalibrationDate { get; set; }
    }
}
