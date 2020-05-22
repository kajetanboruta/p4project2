using P4Project2.DBContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P4Project2.Models
{
    public class Gladiator
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [DefaultValue(null)]
        public ICollection<Skill> Skills { get; set; }
        [Required]
        public PrimaryClass PrimaryClass { get; set; }
        [DefaultValue(null)]
        public AscendancyClass Ascendancy { get; set; }
        [DefaultValue(null)]
        public Weapon CurrentWeapon { get; set; }
        [DefaultValue(0)]
        public int Experience { get; set; }
        [DefaultValue("Prisoner")]
        public string Title { get; set; }
        [DefaultValue(50)]
        public int Purse { get; set; }
        [DefaultValue(0)]
        public int Wins { get; set; }
        [DefaultValue(0)]
        public int Losses { get; set; }
        [DefaultValue(100)]
        public int Health { get; set; }
        [DefaultValue(50)]
        public int Mana { get; set; }

        public Gladiator()
        {

        }

        public int ExperienceGained(Gladiator player, Gladiator enemy, int exp)
        {
            Context ctx = new Context();
            player.Experience += exp;

            ctx.Gladiators.Update(player);

            return player.Experience;
        }

        public bool CanAscend(Gladiator player)
        {
            if (player.Ascendancy == null && player.Experience >= 2500)
                return true;

            return false;
        }

        public void PickingAscension(Gladiator player)
        {
            if (CanAscend(player))
                MessageBox.Show($"W trakcie realizacji");
            else
            {
                if (player.Experience < 2500)
                    MessageBox.Show($"Missing experience: {player.Experience - 2500}");
                if (player.Ascendancy != null)
                    MessageBox.Show($"Ascendancy already picked!!! ({player.Ascendancy.AscendancyName})");

                return;
            }
        }
    }
}
