using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGGame.Characters
{
    public class Hrac : Stats
    {
        public int Level { get; private set; }

        public string Jmeno { get; private set; }

        public int PouzivaniSily { get;  private set; }

        public int BojSeSvetelnymMecem { get;  private set; }

        public int Rychlost { get; private set; }

    }
}
