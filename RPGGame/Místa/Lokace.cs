using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGGame.Místa
{
    public class Lokace : Místa
    {
        public int ID { get; set; }

        public string Jmeno { get; set; }

        public List<Cesta> Cesty { get;  set; }

    }
}
