using RPGGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace RPGGame.Services
{
    public class GameStory
    {
        public List<Location> locations;

        public GameStory()
        {
            locations = new List<Location>();

            locations.Add(new Location()
            {
                ID = 1,
                NameOfPlace = "Atollon",
                DescriptionOfPlace = "Jsi jedinec citlivý na sílu a máš u sebe vibromeč, nacházíš se na místní přístávací plošině na planětě Atollon, rozhoduješ se, jestli se přídáš k sithům či jediům.",
                Paths = new List<Path>(){
                    new Path() {PathID = 1, DescriptionOfChoice="Odletět na Tython a přidat se k jediům.", NextLocationID = 2},
                    new Path() {PathID = 2, DescriptionOfChoice="Odletět na Korriban a přidat se k sithům.", NextLocationID = 3}
                }
            });

            locations.Add(new Location()
            {
                ID = 2,
                NameOfPlace = "Tython",
                DescriptionOfPlace = "Po přistání na přístávací plošině vyjdeš z transportu," +
                " vzápětí ti zavolá přes comlink neznámý mistr jedi a zadá ti úkol najít pradávnou Forge pro sestavení světelného meče a dokončení zkoušek.",
                Paths = new List<Path>(){
                    new Path() {PathID = 3, DescriptionOfChoice="Vydat se do chrámu Jediů na této planetě pro nalezení vodítek.", NextLocationID = 4},
                    new Path() {PathID = 4, DescriptionOfChoice="Vydat se do místních hor najít pradávnou jeskyni pro nalezení vodítek", NextLocationID = 5}
                }
            });

            locations.Add(new Location()
            {
                ID = 3,
                NameOfPlace = "Korriban",
                DescriptionOfPlace = "Po přistání ve vzdálenosti 2 km od místní akademie ti zavolá přes comlink sithský instruktor, zadá ti úkol zjistit si kodex sithů pro posunutí ve zkouškách.",
                Paths = new List<Path>(){
                    new Path() {PathID = 5, DescriptionOfChoice="Vydat se na výslech vězně do mučírny v místní akademii.", NextLocationID = 6},
                    new Path() {PathID = 6, DescriptionOfChoice="Vydat se hrobky neznámého sithského lorda pro vědění.", NextLocationID = 7}
                }
            });

            locations.Add(new Location()
            {
                ID = 4,
                NameOfPlace = "Komnata mistra Jedi Kao Bora",
                Enemy = new Boss()
                {
                    Name = "Rytíř jedi Kao Bora",
                    Health = 40,
                    Endurance = 6,
                    AttackStrength = 4,
                    SpeedOfAttack = 1.5,
                    Toughtness = 2
                },
                DescriptionOfPlace = "Dorazil si do chrámu, kde se setkáš s mistrem Jedi, ten ti řekne, že buďto s ním budeš bojovat, anebo se vydáš do prastaré jeskyně.",
                Paths = new List<Path>(){
                    new Path() {PathID = 7, DescriptionOfChoice = "Začít souboj."},
                    new Path() {PathID = 8, DescriptionOfChoice="Vydat se do prastaré jeskyně.", NextLocationID = 5}
                }
            });

            locations.Add(new Location()
            {
                ID = 5,
                NameOfPlace = "Pradávná jeskyně v horách",
                DescriptionOfPlace = "Dorazil si do jeskyně, zde najdeš u svatyně pergamen, na kterém stojí: 'Chceš-li lokaci Forge najít, říct ty kodex Jediů musíš.'",
                Paths = new List<Path>() {
                    new Path() { PathID = 9, DescriptionOfChoice = "Nejsou žádné emoce, je jen mír. Není žádná nevědomost, je jen poznání." +
                    " Není žádná vášeň, je jen klid. Není žádný chaos, je jen harmonie. Není žádná smrt, je jen síla.", NextLocationID = 11},
                    new Path() { PathID = 10, DescriptionOfChoice = "Není trpělivost, je pouze boj. Není slitování, je pouze smrt.", NextLocationID = 8 }
                    }
                });

            locations.Add(new Location()
            {
                ID = 6,
                NameOfPlace = "Mučírna v akademii",
                DescriptionOfPlace = "Po příchodu do mučírny nalézáš v cele vězně, který zná vodítko k zjištění určitých informací o kodexu, rozhoduješ se, jak přistoupíš k výslechu.",
                Paths = new List<Path>(){
                    new Path() {PathID = 11, DescriptionOfChoice = "Použít blesky síly pro účel agresivního vyjednávání, ale nezabití.", NextLocationID = 10  },
                    new Path() {PathID = 12, DescriptionOfChoice="Použít agresivní čtení myšlenek tohoto vězně pomocí síly.", NextLocationID = 10 },
                    new Path() {PathID = 13, DescriptionOfChoice="Svým vibromečem pomalu zařezávat do jeho kůže.", NextLocationID =  10}
                }
            });

            locations.Add(new Location()
            {
                ID = 7,
                NameOfPlace = "Hrobka neznámého lorda ze Sith",
                Enemy = new Boss()
                {
                    Name = "Terentatek",
                    Health = 70,
                    Endurance = 8,
                    AttackStrength = 6,
                    SpeedOfAttack = 0.5,
                    Toughtness = 1
                },
                DescriptionOfPlace = "Dorazil jsi do této hrobky, zahlédneš uprostřed sithský holokron a velkou bestii Terentatek, která se na tebe žene, co uděláš.",
                Paths = new List<Path>(){
                    new Path() {PathID = 14, DescriptionOfChoice = "Začít souboj"},
                    new Path() {PathID = 15, DescriptionOfChoice="Vydat se do mučírny na akademii", NextLocationID = 6}
                }
            });

            locations.Add(new Location()
            {
                ID = 8,
                NameOfPlace = "Tábor vůdce Flesh raiderů",
                Enemy = new Boss()
                {
                    Name = "Náčelník Flesh raiderů",
                    Health = 50,
                    Endurance = 3,
                    AttackStrength = 2,
                    SpeedOfAttack = 6,
                    Toughtness = 2
                },
                DescriptionOfPlace = "Dorazil si do tábora vůdce, rozhodni se co uděláš.",
                Paths = new List<Path>(){
                    new Path() {PathID = 16, DescriptionOfChoice = "Začít souboj"},
                    new Path() {PathID = 17, DescriptionOfChoice="Přesunout se do archivů v chrámu.", NextLocationID = 9}
                }
            });

            locations.Add(new Location()
            {
                ID = 9,
                NameOfPlace = "Archivy v chrámu Jediů",
                DescriptionOfPlace = "Dorazil si do archivů v chrámu, našel si vodítko v záznamech ve formě hádanky a ta zní: 'Je tam, kde spočívá velkolepost jediů'",
                Paths = new List<Path>(){
                    new Path() {PathID = 18, DescriptionOfChoice = "Vstup do Forge je u hory s vodopádem a spící banthou.", NextLocationID = 11},
                    new Path() {PathID = 19, DescriptionOfChoice="Vstup do Forge je u propasti, ze které srší temnota.", NextLocationID = gameover }
                }
            });

            locations.Add(new Location()
            {
                ID = 10,
                NameOfPlace = "Opuštěná svatyně určená pro rituály",
                DescriptionOfPlace = "Dorazil si do svatyně, jejíž lokaci jsi získal, před sebou vidíš pradávný superpočítač, chce po tobě, abys mu řekl kodex sithů",
                Paths = new List<Path>(){
                    new Path() {PathID = 20, DescriptionOfChoice = "Klid je jen klam, je pouze vášeň. Díky vášni získám sílu. Prostřednictvím síly získám moc. Díky moci dosáhnu vítězství." +
                    " Vítězstvím jsou má pouta zlomena. Síla mě osvobodí.", NextLocationID = 12}, 
                    new Path() {PathID = 21, DescriptionOfChoice="Když nebudu mocný, získám vítězství v mém neúspěchu a osvobodím se.", NextLocationID = fight},
                    new Path() {PathID = 22, DescriptionOfChoice="Když nebudu mít vášeň, ostatní budou žít a síla mě osvobodí.", NextLocationID = fight}

                }
            });

            locations.Add(new Location()
            {
                ID = 11,
                NameOfPlace = "Vstup před Forge",
                DescriptionOfPlace = "Dorazil před obrovskou zapečetěnou bránu, která vede do Forge, před tebou se zjeví hologram neznámého jedie." +
                " Pro vstup chce, abys mu řekl, co je vlastně pravá úloha jediů",
                Paths = new List<Path>(){
                    new Path() {PathID = 23, DescriptionOfChoice="Úlohou je být ochráncem míru a zachovat rovnováhu.", NextLocationID = 13},
                    new Path() {PathID = 24, DescriptionOfChoice="Úlohou je být válečníkem a zasahovat do záležitostí republiky", NextLocationID = gameover}

                }
            });

            locations.Add(new Location()
            {
                ID = 12,
                NameOfPlace = "Hrobka Marka Ragnose",
                DescriptionOfPlace = "Ihned po splnění zkoušky ve svatyni jsi byl teleportován do neznámé hrobky neznámo kde," +
                " pokračuješ víc hlouběji a zahlédneš oltář, na kterém je kyber krystal a součástky na sestrojení světelného meče, nedaleko se nachází místo na sestrojení světelného meče, jaký si vyrobíš?",
                Paths = new List<Path>(){
                    new Path() {PathID = 25, DescriptionOfChoice = "dvojitý červený světelný meč", NextLocationID = 14},
                    new Path() {PathID = 26, DescriptionOfChoice="klasický červený světelný meč", NextLocationID = 14}
                }
            });

            locations.Add(new Location()
            {
                ID = 13,
                NameOfPlace = "Forge",
                DescriptionOfPlace = "Po průchodu bránou jsi se dostal po chvíli ke schodům, které vedou na vyvýšené místo, kde se nachází pradávný přístroj, na kterém se dají sestrojit světelné meče." +
                " Po vystoupání nahoru vidíš na stolku součástky a kyber krystal pro sestrojení světelného meče, jaký si vyrobíš",
                Paths = new List<Path>(){
                    new Path() {PathID = 27, DescriptionOfChoice="dvojitý modrý světelný meč", NextLocationID = 15},
                    new Path() {PathID = 28, DescriptionOfChoice="dvojitý zelený světelný meč", NextLocationID = 15},
                     new Path() {PathID = 29, DescriptionOfChoice="klasický modrý světelný meč", NextLocationID = 15},
                      new Path() {PathID = 30, DescriptionOfChoice="klasický zelený světelný meč", NextLocationID = 15}
                }
            });


            locations.Add(new Location()
            {
                ID = 14,
                NameOfPlace = "Komnaty sithského instruktora na akademii",
                Enemy = new Boss()
                {
                    Name = "Sithský instruktor Tremel",
                    Health = 100,
                    Endurance = 3,
                    AttackStrength = 2,
                    SpeedOfAttack = 6,
                    Toughtness = 3
                },
                DescriptionOfPlace = "Po návratu s novým světelným mečem za sithským instruktorem ti řekne, že finální test je, abys ho porazil nebo zemřel, co uděláš?",
                Paths = new List<Path>(){
                    new Path() {PathID = 31, DescriptionOfChoice = "Začít souboj"},
                    new Path() {PathID = 32, DescriptionOfChoice="Vzdát se", NextLocationID = gameover}
                }
            });

            locations.Add(new Location()
            {
                ID = 15,
                NameOfPlace = "Napadený chrám jediů",
                Enemy = new Boss()
                {
                    Name = "Padlý jedi Bengel Morr",
                    Health = 100,
                    Endurance = 3,
                    AttackStrength = 2,
                    SpeedOfAttack = 6,
                    Toughtness = 3
                },
                DescriptionOfPlace = "Po návratu z Forge do chrámu vidíš chrám v obležení Flesh raiderů s padlým jediem, co uděláš?",
                Paths = new List<Path>(){
                    new Path() {PathID = 33, DescriptionOfChoice = "Začít souboj"},
                    new Path() {PathID = 34, DescriptionOfChoice="Vzdát se", NextLocationID = gameover}
                }
            });

            locations.Add(new Location()
            {
                ID = 16,
                NameOfPlace = "Republiková flotila",
                DescriptionOfPlace = "Po úspěšné obraně chrámu si byl transportován na flotilu, jako odvetu plánuje republika útok na hlavní planetu sithského impéria, Dromund Kass," +
                " jenže po chvilce se spustí alarm, že imperiální špión vyřadil kyslíkový systém, co uděláš?",
                Paths = new List<Path>(){
                    new Path() {PathID = 35, DescriptionOfChoice="Všechny kabely prostě ledabyle spojíš dohromady", NextLocationID = gameover},
                    new Path() {PathID = 36, DescriptionOfChoice="Pomocí síly přepojíš kabely systému kyslíku", NextLocationID = 18}
                }
            });

            locations.Add(new Location()
            {
                ID = 17,
                NameOfPlace = "Sithská flotila",
                DescriptionOfPlace = "Po úspěšném zabití sithského instruktora si byl transportován na flotilu, plánuje se útok na planetu řádu Jedi, Tython," +
               " jenže po chvilce se spustí alarm, že republikový špión poškodil motory flotily, co uděláš?",
                Paths = new List<Path>(){
                    new Path() {PathID = 37, DescriptionOfChoice="Použiješ tlakové ventily pro dolet na Tython", NextLocationID = 19},
                    new Path() {PathID = 38, DescriptionOfChoice="Použiješ sílu k jednorázovému skoku do hyperprostoru s poškozenými motory", NextLocationID = gameover}
                }
            });

            locations.Add(new Location()
            {
                ID = 18,
                NameOfPlace = "Dromund Kass",
                DescriptionOfPlace = "Po úspěšné záchraně flotily jste se vylodili na planetě Dromund Kass, na celé planetě probíhají boje a všude létají střely z blasterů," +
                " ty se vydáváš do sithského chrámu, kde nacházíš imperátora, Dartha Malguse, co uděláš?",
                Paths = new List<Path>(){
                    new Path() {PathID = 39, DescriptionOfChoice="Vzdát se.", NextLocationID = gameover},
                    new Path() {PathID = 40, DescriptionOfChoice="Zahájit souboj."}
                }
            });

            locations.Add(new Location()
            {
                ID = 19,
                NameOfPlace = "Výsadek na Tython",
                DescriptionOfPlace = "Po úspěšné záchraně flotily jste se vylodili na planetě Tython, na celé planetě probíhají boje a všude létají střely z blasterů," +
               " ty se vydáváš do jediského chrámu, kde nacházíš velmistra řádu, Satele Shan, co uděláš?",
                Paths = new List<Path>(){
                    new Path() {PathID = 41, DescriptionOfChoice="Zahájit souboj."},
                    new Path() {PathID = 42, DescriptionOfChoice="Vzdát se.", NextLocationID = gameover}
                }
            });
        }
    }
}
