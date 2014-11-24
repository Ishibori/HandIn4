using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HistoricModel
    {
        [Key]
        public int id { get; set; }
        public DateTime TimeStamp { get; set; }
        public byte[] BinaryData { get; set; }
    }
}
