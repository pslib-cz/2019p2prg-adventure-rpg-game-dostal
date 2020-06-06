using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPGGame.Model;
using RPGGame.Services;

namespace RPGGame.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SessionStorage<Player> _session;

        private readonly GameLogic _logic;

        [BindProperty]
        public string CharacterName { get; set; }

        [BindProperty]
        public Player PlayerStats { get; set; }

        public Location CurrentLocation { get; set; }

        public List<Path> CurrentPaths { get; set; }

        public int? CurrentLocationID { get; set; }

        public IndexModel(SessionStorage<Player> session, GameLogic logic)
        {
            _session = session;
            _logic = logic;
        }

        public void OnGetNameCharacter()
        {
            PlayerStats.Name = CharacterName;
            _session.SavePlayerStats(PlayerStats);

            _session.SetRoomID(_logic.NextLocation);
            int? id = _session.GetRoomId();
            CurrentLocation = _logic.GetLocation(id);
            CurrentPaths = _logic.GetPaths(id);
            CurrentLocationID = id;
        }

        public void OnGet(int userChoice)
        {
            _logic.Play(userChoice, CurrentLocationID);
            _logic.IncreaseSkillPoints(userChoice);

            _session.SetRoomID(_logic.NextLocation);
            int? id = _session.GetRoomId();
            CurrentLocation = _logic.GetLocation(id);
            CurrentPaths = _logic.GetPaths(id);
            CurrentLocationID = id;
        }
    }
}
