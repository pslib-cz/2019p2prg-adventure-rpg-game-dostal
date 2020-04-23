using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGGame.Characters
{
    public class Player
    {
        private string[] zakazanaPojmenovani = {"Vader", "Sidious",
            "Maul", "Tyranus", "Luke", "Obiwan", "Anakin", "Yoda"};

        public int Level { get; private set; }

        private string barvaSvetelnehoMece;

        private string jmeno;

        public string BarvaSvetelnehoMece {
            get 
            { 
                return barvaSvetelnehoMece; 
            } 
            private set 
            { barvaSvetelnehoMece = value;
                if(barvaSvetelnehoMece == "red") 
                {
                    barvaSvetelnehoMece = "purple";
                } 
            } 
        }

        public string Jmeno { 
            get 
            { 
                return jmeno;
            } 
            private set 
            { 
                jmeno = value;
                if (zakazanaPojmenovani.Contains(jmeno) == true)
                {
                    jmeno = "Jar Jar Binks";
                }
            } 
        }

        public int PouzivaniSily { get; private set; }

        public int BojSeSvetelnymMecem { get; private set; }

        public int Zivoty { get; private set; }


    }
}
