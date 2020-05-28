using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGGame.Model
{
    public class Player : CommonStats
    {
        public int Level { get { return Level; } set { if (Level == default) { Level = 1; } } }

        public int ForcePotential { get; set; }

        public int MeleeFightingSkill { get; private set; }

    }
}
