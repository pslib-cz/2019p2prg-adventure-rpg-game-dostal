using RPGGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace RPGGame.Services
{
    public class GameLogic
    {
        readonly SessionStorage _session;

        readonly GameStory _story;

        public bool StateOfGame { get; set; }

        public int NextLocation { get; set; }

        public GameLogic(SessionStorage ss, GameStory gs)
        {
            _session = ss;
            _story = gs;
        }

        public void Play(int userChoice ,int? currentLocationId)
        {

            if (_story.locations[currentLocationId.Value - 1].Enemy != null)
            {
                Fight(currentLocationId.Value);

                if (StateOfGame == true && currentLocationId.Value == 4)
                {
                    NextLocation = 8;
                }
                else if (StateOfGame == true && currentLocationId.Value == 7)
                {
                    NextLocation = 10;

                }
                else if (StateOfGame == true && currentLocationId.Value == 8)
                {
                    NextLocation = 11;

                }
                else if (StateOfGame == true && currentLocationId.Value == 14)
                {
                    NextLocation = 17;

                }
                else if (StateOfGame == true && currentLocationId.Value == 15)
                {
                    NextLocation = 16;

                }
                else if (StateOfGame == true && currentLocationId.Value == 18)
                {
                    NextLocation = 20;

                }
                else if (StateOfGame == true && currentLocationId.Value == 19)
                {
                    NextLocation = 20;

                }
                else if (StateOfGame == false)
                {
                    NextLocation = 0;
                }
            }
            else
            {
                for (int b = 0; b < _story.locations[currentLocationId.Value - 1].Paths.Count; b++)
                {
                    if (userChoice == _story.locations[currentLocationId.Value - 1].Paths[b].NextLocationID)
                    {
                        NextLocation = _story.locations[currentLocationId.Value - 1].Paths[b].NextLocationID;
                    }
                }
            }
        }

        public void Fight(int? currentLocation)
        {
            Random randomAttackValue = new Random();
            Player player = _session.PlayerStats;
            Boss npc = _story.locations[currentLocation.Value - 1].Enemy;
            npc.Health *= npc.Toughtness;

            do
            {
                double playerAttackValue = player.MeleeFightingSkill * randomAttackValue.Next(1, 5) + player.SpeedOfAttack + player.AttackStrength + player.ForcePotential;
                if (playerAttackValue <= npc.Endurance)
                {
                    playerAttackValue = npc.Endurance - playerAttackValue;
                }

                npc.Health -= playerAttackValue;

                if (npc.Health <= 0)
                {
                    StateOfGame = true;
                    break;
                }

                double npcAttackValue = npc.AttackStrength * randomAttackValue.Next(1, 9) + npc.SpeedOfAttack;

                if (npcAttackValue <= player.Endurance)
                {
                    npcAttackValue = player.Endurance - npcAttackValue;
                }

                player.Health -= npcAttackValue;

                if (player.Health <= 0)
                {
                    StateOfGame = false;
                    break;
                }
            }
            while (true);
        }

        public void IncreaseSkillPoints(int? currentLocationId)
        {

            Player player = _session.PlayerStats;

            for (int c = 0; c < _story.locations[currentLocationId.Value - 1].Paths.Count; c++)
            {
                if (_story.locations[currentLocationId.Value - 1].Paths[c].PathID == 2 || _story.locations[currentLocationId.Value - 1].Paths[c].PathID == 4 ||
                    _story.locations[currentLocationId.Value - 1].Paths[c].PathID == 6 || _story.locations[currentLocationId.Value - 1].Paths[c].PathID == 12 ||
                    _story.locations[currentLocationId.Value - 1].Paths[c].PathID == 18 || _story.locations[currentLocationId.Value - 1].Paths[c].PathID == 8 ||
                    _story.locations[currentLocationId.Value - 1].Paths[c].PathID == 17 || _story.locations[currentLocationId.Value - 1].Paths[c].PathID == 23 ||
                    _story.locations[currentLocationId.Value - 1].Paths[c].PathID == 37 || _story.locations[currentLocationId.Value - 1].Paths[c].PathID == 9 ||
                    _story.locations[currentLocationId.Value - 1].Paths[c].PathID == 20 || _story.locations[currentLocationId.Value - 1].Paths[c].PathID == 15 ||
                    _story.locations[currentLocationId.Value - 1].Paths[c].PathID == 36)
                {
                    int levelBefore = player.Level;
                    player.ForcePotential += 10;
                    player.Health += 40;
                    player.Level += 1;
                    if (levelBefore != player.Level)
                    {
                        player.Endurance += 4;
                        player.AttackStrength += 5;
                    }

                    _session.SavePlayerStats(player);
                }

            }
        }

        public Location GetLocation (int? locationID)
        {
            return _story.locations[locationID.Value - 1];
        }

        public List<Path> GetPaths (int? locationID)
        {
            return _story.locations[locationID.Value - 1].Paths;
        }
    }
}
