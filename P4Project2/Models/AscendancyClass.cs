using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Project2.Models
{
    public class AscendancyClass
    {
        public int ID { get; set; }
        public string AscendancyName { get; set; }
        public PrimaryClass RequiredPrimaryClass { get; set; }
        
        public AscendancyClass()
        {

        }
    }
}