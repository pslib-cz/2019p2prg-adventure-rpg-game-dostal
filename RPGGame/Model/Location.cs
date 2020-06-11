using System.Collections.Generic;

namespace RPGGame.Model
{
    public class Location
    {
        public int ID { get; set; }

        public string NameOfPlace { get; set; }

        public string DescriptionOfPlace { get; set; }

        public List<Path> Paths { get; set; }
    }
}
