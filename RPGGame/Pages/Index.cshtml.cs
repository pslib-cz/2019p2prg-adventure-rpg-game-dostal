using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly SessionStorage _session;

        private readonly GameLogic _logic;
        public string CharacterName { get; set; }

        public Location CurrentLocation { get; set; }

        public List<Path> CurrentPaths { get; set; }

        public bool IsNextLocation { get; set; }

        [BindProperty]
        public int CurrentChoice {get; set;}

        public int SelectedLocation { get; set; }

        public IndexModel(SessionStorage session, GameLogic logic)
        {
            _session = session;
            _logic = logic;
        }

        public void OnPost()
        {
            _session.PlayerStats.Name = CharacterName;
            _session.SavePlayerStats(_session.PlayerStats);
            _logic.NextLocation = 0;

            do
            {
                _logic.NextLocation++;
                _session.SetRoomID(_logic.NextLocation);
                int? id = _session.GetRoomId();
                CurrentLocation = _logic.GetLocation(id);
                CurrentPaths = _logic.GetPaths(id);
                IsNextLocation = true;
                _logic.Play(SelectedLocation,id);   
                _logic.IncreaseSkillPoints(id);
            }
            while (_logic.NextLocation == 0 || _logic.NextLocation == 20);
            
        }

        public void OnGet ()
        {
            SelectedLocation = CurrentChoice;
        }
    }
}
