using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RPGGame.Services;

namespace RPGGame.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SessionStorage _session;
        public string CharacterName { get; set; }

        public IndexModel(SessionStorage session)
        {
            _session = session;
        }

        public void OnGet()
        {
            CharacterName = _session.GetCharacterName();
        }
    }
}
