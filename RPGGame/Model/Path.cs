using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGGame.Model
{
    public class Path
    {
        public int PathID { get; set; }

        public string DescriptionOfChoice { get; set; }

        public int NextLocationID { get; set; }
    }
}
