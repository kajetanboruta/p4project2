using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        [ForeignKey("PrimaryClassID_FK")]
        public PrimaryClass PrimaryClass { get; set; }
        public int? PrimaryClassID_FK { get; set; }
        public ICollection<Gladiator> Gladiators { get; set; }

        public Weapon()
        {

        }
    }
}