using Microsoft.EntityFrameworkCore;
using P4Project2.DBContext;
using P4Project2.Views;
using P4Project2.Views.Fight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        /// <param name="_attacker"></param>
        /// <param name="_victim"></param>
        public bool FightStatus(Gladiator _attacker, Gladiator _victim)
        {
            if (_victim.Health <= 0)
            {
                //Context ctx = new Context();
                FightSummary(_attacker,_victim);
                Logs.FightLog.Add($"{_attacker.Name} has won!");
                if (_attacker.Name == Player.Name)
                {
                    var window = (ClientView)Application.Current.MainWindow;
                    window.MainFrame.Navigate(new WinView());
                }
                else
                {
                    var window = (ClientView)Application.Current.MainWindow;
                    window.MainFrame.Navigate(new LoseView());
                }
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
        public bool DetermineHit(Gladiator _attacker)
        {
            var _accuracyCheck = rnd.Next(0, 100);
            Logs.FightLog.Add($"{_attacker.Name} has thrown {_accuracyCheck} to attack!");
            if (_attacker.CurrentWeapon.Accuracy >= _accuracyCheck)
                return true;

            return false;
        }

        public bool DetermineBlock(Gladiator _gladiator)
        {
            var _blockCheck = rnd.Next(0, 10);
            Logs.FightLog.Add($"{_gladiator.Name} has thrown {_blockCheck} to block!");
            if (1 >= _blockCheck)
                return true;

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
        public void Attack(Gladiator _attacker, Gladiator _victim)
        {
            if (DetermineHit(_attacker))
            {
                if (DetermineBlock(_victim))
                {
                    Logs.FightLog.Add($"{_victim.Name} has blocked!");
                    Attack(_victim, _attacker);
                    return;
                }
                Logs.FightLog.Add($"{_attacker.Name} hit was determined!");
                _victim.Health -= _attacker.CurrentWeapon.Damage;
                Logs.FightLog.Add($"{_victim.Name}'s health dropped to {_victim.Health}");
                if (FightStatus(_attacker, _victim))
                {
                    Logs.FightLog.Add($"{_attacker} won!!!");
                }
                return;
            }
            Logs.FightLog.Add($"{_attacker.Name} hit was not determined!");
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

        public int CountValuesGained(Gladiator winner, Gladiator looser)
        {
            var lvlDifference = winner.LevelID_FK - looser.LevelID_FK;

            if (lvlDifference == 0)
                return 100;
            else if (lvlDifference > 0 && lvlDifference != 1)
                return 150;
            else if (lvlDifference > 0)
                return 100 * lvlDifference;
            else
                return 50;
        }

        public async void CheckLevelUp(Gladiator winner)
        {
            Context ctx = new Context();
            
            var nextLevel = ctx.Levels.Where(x => x.LevelNo > winner.LevelID_FK).FirstOrDefault();
            if (winner.Experience >= nextLevel.ExperienceReq)
            {
                winner.Health = nextLevel.Health;
                winner.Mana = nextLevel.Mana;
                winner.LevelID_FK = nextLevel.LevelNo;
                winner.CurrentLevel = await ctx.Levels.Where(x => x.LevelNo == winner.LevelID_FK).FirstOrDefaultAsync();
                MessageBox.Show($"{winner.Name} just leveled up!");
            }
        }

        public void FightSummary(Gladiator winner, Gladiator looser)
        {
            Context ctx = new Context();
            var value = CountValuesGained(winner, looser);
            winner.Experience += value;
            winner.Purse += value / 2;
            winner.Wins += 1;
            CheckLevelUp(winner);
            looser.Losses += 1;
            looser.Purse -= value / 2;
            ctx.Gladiators.UpdateRange(winner, looser);
            ctx.SaveChanges();

        }
    }
}
