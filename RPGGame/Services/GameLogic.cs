using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGGame.Services
{
    public class GameLogic
    {
        readonly SessionStorage _session;

        readonly GameStory _story;

        public GameLogic (SessionStorage ss, GameStory gs) 
        {
            _session = ss;
            _story = gs;
        }
    }
}
