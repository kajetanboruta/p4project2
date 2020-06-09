using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Project2.Models
{
    public class Level
    {
        [Key]
        public int LevelNo { get; set; }
        public int Health{ get; set; }
        public int Mana { get; set; }
        public int ExperienceReq { get; set; }
        public ICollection<Gladiator> Gladiators { get; set; }
    }
}
