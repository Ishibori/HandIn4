using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class reading
    {
        public int readingId { get; set; }
        public int sensorId { get; set; }
        public int appartmentId { get; set; }
        public double value { get; set; }
        public DateTime timestamp { get; set; }
    }
}
