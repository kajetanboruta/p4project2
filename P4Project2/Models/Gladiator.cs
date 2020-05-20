using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Project2.Models
{
    public class Gladiator
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public PrimaryClass PrimaryClass { get; set; }
        public AscendancyClass Ascendancy { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public int Experience { get; set; }
        public string Title { get; set; }
        public int Purse { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }

        public Gladiator()
        {

        }

        public int ExperienceGained(Gladiator player, int exp)
        {
            player.Experience += exp;
            return player.Experience;
        }

        public bool CanAscend(Gladiator player)
        {
            if (player.Ascendancy == null)
                return true;

            return false;
        }
    }
}
