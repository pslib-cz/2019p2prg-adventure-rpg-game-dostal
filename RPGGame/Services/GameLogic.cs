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

        public int CurrentLocationId { get; set; } = 1;

        public int CurrentSelectedChoice { get; set; }

        public Player Player { get; set; }

        public Location Location { get; set; }

        public List<Path> Paths { get; set; }

        public GameLogic(SessionStorage<Player> ss, GameStory gs)
        {
            _session = ss;
            _story = gs;
            Player = _session.PlayerStats;
            if (Player == default) { Player = new Player(); }
        }

        public void Play()
        {
            if (CurrentLocationId == 1 && CurrentSelectedChoice == default)
            {
                IncreaseSkillPoints();
                SetLocation();
            }
            else
            {
                if (CurrentLocationId == 1 && CurrentSelectedChoice != default)
                {
                    int? ID = _session.GetRoomId();
                    for (int b = 0; b < _story.locations[ID.Value].Paths.Count; b++)
                    {
                        if (_story.locations[ID.Value].Paths[b].PathID == CurrentSelectedChoice)
                        {
                            CurrentLocationId = _story.locations[ID.Value].Paths[b].NextLocationID;
                        }
                    }
                }
                else
                {
                    _session.SetRoomID(CurrentLocationId);
                    int? id = _session.GetRoomId();

                    for (int b = 0; b < _story.locations[id.Value].Paths.Count; b++)
                    {
                        if (_story.locations[id.Value].Paths[b].PathID == CurrentSelectedChoice)
                        {
                            CurrentLocationId = _story.locations[id.Value].Paths[b].NextLocationID;
                        }
                    }
                }

                IncreaseSkillPoints();
                SetLocation();
            }
        }

        public void IncreaseSkillPoints()
        {

            Player player = Player;
            int levelBefore = player.Level;

            if (CurrentSelectedChoice == 1 || CurrentSelectedChoice == 4 || CurrentSelectedChoice == 6 || CurrentSelectedChoice == 9 || CurrentSelectedChoice == 11 ||
                CurrentSelectedChoice == 12 || CurrentSelectedChoice == 17 || CurrentSelectedChoice == 18 || CurrentSelectedChoice == 20 ||
                CurrentSelectedChoice == 23 || CurrentSelectedChoice == 34 || CurrentLocationId == 41)
            {
                player.ForcePotential += 10;
                player.Health += 60;
            }
            else if (CurrentSelectedChoice == 2 || CurrentSelectedChoice == 3 || CurrentSelectedChoice == 5 || CurrentSelectedChoice == 10 || CurrentSelectedChoice == 13 || CurrentSelectedChoice == 15)
            {
                player.SpeedOfAttack += 5;
                player.AttackStrength += 8;
                player.Endurance += 7;
                player.Health += 45;
                player.MeleeFightingSkill += 8;
            }
            else if ( CurrentSelectedChoice == 26 ||  CurrentSelectedChoice == 28 || CurrentSelectedChoice == 38)
            {
                player.SpeedOfAttack += 50;
                player.AttackStrength += 30;
                player.Endurance += 43;
                player.Health += 30;
                player.ForcePotential += 20;
                player.MeleeFightingSkill += 15;
            }
            else if (CurrentSelectedChoice == 7 || CurrentSelectedChoice == 14 || CurrentSelectedChoice == 15 || CurrentSelectedChoice == 29 || CurrentSelectedChoice == 31 || CurrentSelectedChoice == 38)
            {
                player.Endurance += 15;
                player.MeleeFightingSkill += 10;
                player.SpeedOfAttack += 12;
                player.AttackStrength += 14;
            }


            if (CurrentLocationId != 20 || CurrentLocationId != 0)
            {
                player.Level += 1;
            }

            if (levelBefore != player.Level)
            {
                player.Endurance += 5;
                player.AttackStrength += 5;
                player.Health += 25;
            }

            _session.SavePlayerStats(player);
        }

        public void SetLocation()
        {
            _session.SetRoomID(CurrentLocationId);
            int? id = _session.GetRoomId();
            Location = _story.locations[id.Value];
            Paths = _story.locations[id.Value].Paths;
        }
    }
}
