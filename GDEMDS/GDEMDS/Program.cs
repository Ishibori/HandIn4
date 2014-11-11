using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace GDEMDS
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonDown = new JsonDownloader();
            Console.WriteLine(jsonDown.GetJson("http://userportal.iha.dk/~jrt/i4dab/E14/HandIn4/GFKRE0031_sample.txt"));
        }
    }
}
