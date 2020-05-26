using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Project2.Models
{
    public class Weapon
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Experience_Required { get; set; }
        public int Damage { get; set; }
        public int Accuracy { get; set; }
        public PrimaryClass PrimaryClass_Required { get; set; }

        public Weapon()
        {

        }
    }
}