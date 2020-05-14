using RPGGame.Místa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace RPGGame.Story
{
    public class PribehHry
    {
        readonly List<Lokace> lokace;

        public PribehHry()
        {
            lokace = new List<Lokace>();
            lokace.Add(new Lokace()
            {
                ID = 1,
                Jmeno = "Atollon",
                Popis = "Jsi jedinec citlivý na sílu, nacházíš se na místní přístávací plošině na planětě Atollon, rozhoduješ se, jestli se přídáš k sithům či jediům.",
                Cesty = new List<Cesta>(){
                    new Cesta() {CestaID = 1, Popis="Odletět na Tython a přidat se k jediům.", IDDalsiLokace = 2},
                    new Cesta() {CestaID = 2, Popis="Odletět na Korriban a přidat se k sithům.", IDDalsiLokace = 3},
                }
            });
            lokace.Add(new Lokace()
            {
                ID = 2,
                Jmeno = "Tython",
                Popis = "Po přistání jsi se setkal s jediským mistrem, ten ti v rámci tvých zkoušek na padawana nabídne, " +
                "buďto se vydat do chrámu jediů a utkat se s rytířem jedi a ukázat své dovednosti v boji, nebo se vydat do pradávné jeskyně v místních horách, kde musíš najít předmět k odemčení tajupné Forge",
                Cesty = new List<Cesta>(){
                    new Cesta() {CestaID = 3, Popis="Vydat se do chrámu.", IDDalsiLokace = 4},
                    new Cesta() {CestaID = 4, Popis="Vydat se na hledání jeskyně.", IDDalsiLokace = 5},
                }
            });
            lokace.Add(new Lokace()
            {
                ID = 3,
                Jmeno = "Korriban",
                Popis = "Po přistání tě přivítá sithský instruktor, ten ti řekne, že pokud selžeš tak bez milosti zemřeš, přežijí jen ti nejsilnější," +
                " buďto v rámci zkoušek ukážeš své donucovací dovednosti uvnitř mučírny v akademii, nebo se vydáš do hrobky sithshé lorda pro vědění.",
                Cesty = new List<Cesta>(){
                    new Cesta() {CestaID = 5, Popis="Vydat se do údolí, do hrobky.", IDDalsiLokace = 6},
                    new Cesta() {CestaID = 6, Popis="Vydat se do akademie, do mučírny.", IDDalsiLokace = 7},
                }
            });
            lokace.Add(new Lokace()
            {
                ID = 7,
                Jmeno = "Mučírna v akademii",
                Popis = "Vidíš před sebou v cele vězně, má velmi zjizvený obličej, od personálu, se dozvíš, že dělal politické sabotáže a jeho úkolem bylo zabíjet politky od neznámého zdroje.",
                Cesty = new List<Cesta>(){
                    new Cesta() {CestaID = 1, Popis="Nemilostně ho usmažíš blesky.", IDDalsiLokace = 8},
                    new Cesta() {CestaID = 2, Popis="Dovolíš mu smrt čestným bojem s tebou.", IDDalsiLokace = 9},
                     new Cesta() {CestaID = 1, Popis="Necháš ho žít pro využití v impérium", IDDalsiLokace = 10},
                }
            });
            lokace.Add(new Lokace()
            {
                ID = 6,
                Jmeno = "Hroba lorda ze sith",
                Popis = "Hluboko v hrobce nalézáš sithský holokron, přemýšlíš, co uděláš dál",
                Cesty = new List<Cesta>(){
                    new Cesta() {CestaID = 1, Popis="Začneš pomocí temné strany meditovat před holokronem.", IDDalsiLokace = 11},
                    new Cesta() {CestaID = 2, Popis="Začneš pomocí blesků se pokoušet násilím otevřít holokron.", IDDalsiLokace = 12},
                }
            });

        }
    }
}
