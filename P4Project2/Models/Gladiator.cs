using Microsoft.EntityFrameworkCore;
using P4Project2.DBContext;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey("PrimaryClassID_FK")]
        public virtual PrimaryClass PrimaryClass { get; set; }
        public int PrimaryClassID_FK { get; set; }
        [ForeignKey("WeaponID")]
        public Weapon CurrentWeapon { get; set; }
        public int? WeaponID { get; set; }
        [ForeignKey("LevelID_FK")]
        public Level CurrentLevel { get; set; }
        public int? SkillID { get; set; }
        public Skill CurrentSkill { get; set; }
        public int LevelID_FK { get; set; }
        public int Experience { get; set; }
        public string Title { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Purse { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        [NotMapped]
        public ICollection<Gladiator> _Gladiators { get; set; }

        public Gladiator()
        {

        }

        public Gladiator Player;
        public Gladiator Enemy;
        public List<string> _logger = new List<string>();

        /// <summary>
        /// Counts gained experience ( sorry for randomness )
        /// </summary>
        /// <param name="player">player gladiator</param>
        /// <param name="enemy">enemy gladiator</param>
        /// <param name="exp">experience gained from battle</param>
        /// <returns></returns>

        public double PowerCalculation()
        {
            double overalPwr = 0.0;

            double hpPwr = Health / 10.0;
            double weaponPwr = (CurrentWeapon.Accuracy + 0.0) / (CurrentWeapon.Damage + 0.0);
            double lvlPwr = LevelID_FK;
            overalPwr = hpPwr + weaponPwr + lvlPwr;

            return overalPwr;
        }

        /// <summary>
        /// Check if user can ascend ( pick second class / subclass ).
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        //public bool CanAscend(Gladiator player)
        //{
        //    if (player.Ascendancy == null && player.Experience >= 2500)
        //        return true;

        //    return false;
        //}

        /// <summary>
        /// let user pick ascension ( subClass )
        /// </summary>
        /// <param name="player"></param>
        //public void PickingAscension(Gladiator player)
        //{
        //    if (CanAscend(player))
        //        MessageBox.Show($"W trakcie realizacji");
        //    else
        //    {
        //        if (player.Experience < 2500)
        //            MessageBox.Show($"Missing experience: { 2500 - player.Experience }");

        //        if (player.Ascendancy != null)
        //            MessageBox.Show($"Ascendancy already picked!!! ({ player.Ascendancy.AscendancyName })");

        //        return;
        //    }
        //}



        
    }
}
