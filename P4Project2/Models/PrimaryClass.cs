using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Project2.Models
{
    public class PrimaryClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CritChance { get; set; }
        public int BlockChance { get; set; }
        //public ICollection<AscendancyClass> ascendancyClasses { get; set; }

        public PrimaryClass()
        {

        }
    }
}
