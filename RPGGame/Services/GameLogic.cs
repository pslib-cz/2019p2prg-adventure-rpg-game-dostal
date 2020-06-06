using Microsoft.AspNetCore.Mvc.Rendering;
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
        readonly SessionStorage<Player> _session;

        readonly GameStory _story;

        private int nextLocation;

        public bool StateOfGame { get; set; }

        public int NextLocation { get { return nextLocation; } set { if (nextLocation == default) { nextLocation = 1; } } }

        public GameLogic(SessionStorage<Player> ss, GameStory gs)
        {
            _session = ss;
            _story = gs;
        }

        public void Play(int selectedChoice, int? currentLocationId)
        {

            if (selectedChoice == 7 || selectedChoice == 14 || selectedChoice == 16 || selectedChoice == 29 ||
                selectedChoice == 31 || selectedChoice == 38 || selectedChoice == 39)
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
                    _session.PlayerStats = default;
                    _session.SavePlayerStats(_session.PlayerStats);
                    NextLocation = 20;

                }
                else if (StateOfGame == true && currentLocationId.Value == 19)
                {
                    _session.PlayerStats = default;
                    _session.SavePlayerStats(_session.PlayerStats);
                    NextLocation = 20;

                }
                else if (StateOfGame == false)
                {
                    NextLocation = 0;
                }
            }
            else
            {
                for (int b = 0; b < _story.locations[currentLocationId.Value].Paths.Count; b++)
                {
                    if (selectedChoice == _story.locations[currentLocationId.Value].Paths[b].PathID)
                    {
                        NextLocation = _story.locations[currentLocationId.Value].Paths[b].NextLocationID;
                    }
                }
            }
        }

        public void Fight(int? currentLocation)
        {
            Random randomAttackValue = new Random();
            Player player = _session.PlayerStats;
            Boss npc = _story.locations[currentLocation.Value].Enemy;
            npc.Health *= npc.Toughtness;
            double healthBefore = player.Health;

            do
            {
                double playerAttackValue = player.MeleeFightingSkill * randomAttackValue.Next(1, 5) + player.SpeedOfAttack + player.AttackStrength + player.ForcePotential;
                if (playerAttackValue < npc.Endurance)
                {
                    playerAttackValue = npc.Endurance - playerAttackValue;
                }

                npc.Health -= playerAttackValue;

                if (npc.Health <= 0)
                {
                    StateOfGame = true;
                    player.Health = healthBefore;
                    _session.SavePlayerStats(player);
                    break;
                }

                double npcAttackValue = npc.AttackStrength * randomAttackValue.Next(1, 9) + npc.SpeedOfAttack;

                if (npcAttackValue < player.Endurance)
                {
                    npcAttackValue = player.Endurance - npcAttackValue;
                }

                player.Health -= npcAttackValue;

                _session.SavePlayerStats(player);

                if (player.Health <= 0)
                {
                    StateOfGame = false;
                    player = default;
                    _session.SavePlayerStats(player);
                    break;
                }
            }
            while (true);
        }

        public void IncreaseSkillPoints(int selectedChoice)
        {

            Player player = _session.PlayerStats;
            int levelBefore = player.Level;

            if (selectedChoice == 1 || selectedChoice == 4 || selectedChoice == 6 || selectedChoice == 8 || selectedChoice == 9 || selectedChoice == 11 ||
                selectedChoice == 12 || selectedChoice == 17 || selectedChoice == 18 || selectedChoice == 20 ||
                selectedChoice == 23 || selectedChoice == 34 || selectedChoice == 35)
            {
                player.ForcePotential += 10;
                player.Health += 60;
            }
            else if (selectedChoice == 2 || selectedChoice == 3 || selectedChoice == 5 || selectedChoice == 10 || selectedChoice == 13 || selectedChoice == 15)
            {
                player.SpeedOfAttack += 5;
                player.AttackStrength += 8;
                player.Endurance += 7;
                player.Health += 45;
                player.MeleeFightingSkill += 8;
            }
            else if (selectedChoice == 25 || selectedChoice == 26 || selectedChoice == 27 || selectedChoice == 28 || selectedChoice == 38 || selectedChoice == 39)
            {
                player.SpeedOfAttack += 50;
                player.AttackStrength += 30;
                player.Endurance += 43;
                player.Health += 30;
                player.ForcePotential += 20;
                player.MeleeFightingSkill += 15;
            }
            else
            {
                player.Endurance += 15;
                player.MeleeFightingSkill += 10;
                player.SpeedOfAttack += 12;
                player.AttackStrength += 14;
            }

            player.Level += 1;

            if (levelBefore != player.Level)
            {
                player.Endurance += 5;
                player.AttackStrength += 5;
                player.Health += 25;
            }

            _session.SavePlayerStats(player);
        }

        public Location GetLocation(int? locationID)
        {
            return _story.locations[locationID.Value];
        }

        public List<Path> GetPaths(int? locationID)
        {
            return _story.locations[locationID.Value].Paths;
        }
    }
}
