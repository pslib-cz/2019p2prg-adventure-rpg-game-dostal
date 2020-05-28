using Microsoft.AspNetCore.Http;
using RPGGame.Helpers;
using RPGGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGGame.Services
{
    public class SessionStorage
    {
        readonly ISession _session;
        const string BOSSSTATS = "N.STATS";
        const string PLAYERSTATS = "P.STATS";
        const string LOCATION = "LOCATIONID";

        public Player PlayerStats { get; set; }
        public Boss BossStats { get; set; }

        public int? LocationID { get; set; }
        
        public SessionStorage(IHttpContextAccessor hca)
        {
            _session = hca.HttpContext.Session;
            PlayerStats = _session.Get<Player>(PLAYERSTATS);
            BossStats = _session.Get<Boss>(BOSSSTATS);
        }

        public int? GetRoomId ()
        {
            return _session.GetInt32(LOCATION);
        }

        public void SetRoomID (int numberOfLocation)
        {
            _session.SetInt32(LOCATION, numberOfLocation);
        }

        public void SavePlayerStats (Player stats)
        {
            _session.Set(PLAYERSTATS, stats);
        }
       
    }
}
