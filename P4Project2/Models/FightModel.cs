using P4Project2.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P4Project2.Models
{
    public class FightModel
    {
        public bool Status { get; set; }
        public Gladiator Player { get; set; }
        public Gladiator Enemy { get; set; }

        public Logger Logs = new Logger();

        static readonly Random rnd = new Random();

        /// <summary>
        /// returns experience gained if fight won, else null.
        /// </summary>
        /// <param name="_player"></param>
        /// <param name="_enemy"></param>
        public bool FightStatus(Gladiator _player, int _playerHP, Gladiator _enemy, int _enemyHP)
        {
            if (_enemyHP <= 0)
            {
                //Context ctx = new Context();
                Logs.FightLog.Add($"{_player.Name} has won!");
                return true;
            }

            return false;
        }

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
        public void Attack(Gladiator Player, Gladiator _victim)
        {
            if (DetermineHit(Player.CurrentWeapon))
            {
                if (DetermineBlock(_victim))
                {
                    Logs.FightLog.Add($"{_victim.Name} hit was not determined! ( FALSE )");
                    Attack(_victim, Player);
                    return;
                }
                Logs.FightLog.Add($"{Player.Name} hit was determined! ( TRUE )");
                _victim.Health -= Player.CurrentWeapon.Damage;
                Logs.FightLog.Add($"{_victim.Name}'s health dropped to {_victim.Health}");
                if (FightStatus(Player, Player.Health, Enemy, Enemy.Health)) 
                {
                    MessageBox.Show("Wygrana");
                }
                return;
            }

            Logs.FightLog.Add($"{Player.Name} hit was not determined! ( FALSE )");
        }

        public bool Block(Gladiator _attacker, Gladiator _victim)
        {
            if (DetermineBlock(_victim))
            {
                Logs.FightLog.Add($"{_victim.Name}'s blocked!!!");
                return true;
            }
            Logs.FightLog.Add($"{_victim.Name}'s taken damage!!!");
            return false;
        }
    }
}
