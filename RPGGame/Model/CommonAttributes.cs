using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGGame.Model
{
    public abstract class CommonStats
    {
        public string Name { get; set; }

        public double Endurance { get; set; }

        public double Health { get; set; }

        public double AttackStrength { get;  set; }

        public double SpeedOfAttack { get; set; }

    }
}
