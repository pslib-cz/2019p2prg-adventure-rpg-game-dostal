using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPGGame.Model;
using RPGGame.Services;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.JSInterop;

namespace RPGGame.Pages
{
    public class RoomModel : PageModel
    {
        private readonly GameLogic _logic;

        public Location CurrentLocation { get; set; }

        public List<Path> CurrentPaths { get; set; }

        public Player Stats { get; set; }

        public RoomModel (GameLogic logic)
        {
            _logic = logic;
        }

        public void OnGetStart() {

            _logic.CurrentSelectedChoice = default;
            _logic.Play();
            CurrentLocation = _logic.Location;
            CurrentPaths = _logic.Paths;
            Stats = new Player();
            _logic.CurrentLocationId = default;
        }
        
        public void OnGet(int userChoice)
        {
            _logic.CurrentSelectedChoice = userChoice;
            _logic.Play();
            CurrentLocation = _logic.Location;
            CurrentPaths = _logic.Paths;
            Stats = _logic.Player;
        }
    }
}