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
    public class IndexModel : PageModel
    {

        private readonly GameLogic _logic;


        public IndexModel(GameLogic logic)
        {
            _logic = logic;
        }

        public void OnPost()
        {
           
        }
    }
}
