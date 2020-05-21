using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGGame.Model
{
    public class Location
    {
        public int ID { get; set; }

        public string NameOfPlace { get; set; }

        public string DescriptionOfPlace { get; set; }

        public List<Path> Paths { get; set; }

        public Boss Enemy { get; set; }
    }
}
