using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4Project2.Models
{
    class AIBehavior
    {
        public enum _Style
        {
            Defensive,
            Aggresive,
            Random
        }
        _Style Style { get; set; }
        public bool RoundPrediction { get; set; }
        public int Action { get; set; }

        public _Style StyleChanger(Gladiator _player,Gladiator _ai)
        {
            double _playerPwr = _player.PowerCalculation();
            double _aiPwr = _ai.PowerCalculation();

            if (_playerPwr > _aiPwr)
                return _Style.Defensive;
            else
                return _Style.Aggresive;
        }

        public void ActionFunc()
        {
            if (Style == _Style.Aggresive)
            {

            }
        }
    }
}
