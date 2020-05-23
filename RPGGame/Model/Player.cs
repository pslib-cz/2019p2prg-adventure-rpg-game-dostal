using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGGame.Model
{
    public class Player : CommonStats
    {
        public int Level { get; private set; }

        public int ForcePotential { get; private set; }

        public int MeleeFightingSkill { get; private set; }

    }
}
