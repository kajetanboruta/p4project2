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
        public int LevelID_FK { get; set; }
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
        [NotMapped]
        public ICollection<Gladiator> _Gladiators { get; set; }

        public Gladiator()
        {

        }

        public static readonly Random rnd = new Random();

        /// <summary>
        /// returns experience gained if fight won, else null.
        /// </summary>
        /// <param name="_player"></param>
        /// <param name="_enemy"></param>
        public bool FightStatus(Gladiator _player, int _playerHP, Gladiator _enemy, int _enemyHP)
        {
            if (_enemyHP <= 0)
            {
                Context ctx = new Context();
                
                return true;
            }

            return false;
        }

        /// <summary>
        /// Counts gained experience ( sorry for randomness )
        /// </summary>
        /// <param name="player">player gladiator</param>
        /// <param name="enemy">enemy gladiator</param>
        /// <param name="exp">experience gained from battle</param>
        /// <returns></returns>
        public int CountExperienceGained(Gladiator player, Gladiator enemy, int exp)
        {
            Context ctx = new Context();
            player.Experience += exp;

            ctx.Gladiators.Update(player);

            return player.Experience;
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

        /// <summary>
        /// Determine if attack is hit or evaded. Draw random number from 0 to 100.
        /// If weapon accuracy chance is 75% then 0-74 = hit,
        ///                                       75-99 = evaded.
        /// </summary>
        /// <param name="_weapon">Wielded weapon of gladiator</param>
        /// <returns>True = hit, False = evaded</returns>
        public bool DetermineHit(Weapon _weapon)
        {
            var _accuracyCheck = rnd.Next(0, 100);

            if (_weapon.Accuracy < _accuracyCheck)
                return true;
            
            return false;
        }

        public bool DetermineBlock(Gladiator _gladiator)
        {
            return false;
        }

        /// <summary>
        /// Function checks if attack is accurate ( if attacker was able to hit victim ).
        /// If he hit, then victim's hp is changed and returned.
        /// If not then it returns victim's HP without changes.
        /// </summary>
        /// <param name="_attacker">Gladiator who attacks</param>
        /// <param name="_victim">Gladiator who's attacked</param>
        /// <returns>health after changes of victim gladiator</returns>
        public int Attack(Gladiator _attacker, Gladiator _victim)
        {
            if (DetermineHit(_attacker.CurrentWeapon))
            {
                _victim.Health -= _attacker.CurrentWeapon.Damage;
                return _victim.Health;
            }

            return _victim.Health;
        }
    }
}
