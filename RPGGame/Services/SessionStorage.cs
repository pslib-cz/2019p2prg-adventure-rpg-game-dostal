using Microsoft.AspNetCore.Http;
using RPGGame.Helpers;
using RPGGame.Model;

namespace RPGGame.Services
{
    public class SessionStorage<T>
    {
        readonly ISession _session;
        const string PLAYERSTATS = "P.STATS";
        const string LOCATION = "LOCATIONID";

        public Player PlayerStats { get; set; }
        
        public SessionStorage(IHttpContextAccessor hca)
        {
            _session = hca.HttpContext.Session;
            PlayerStats = _session.Get<Player>(PLAYERSTATS);
        }

        public int? GetRoomId ()
        {
            return _session.GetInt32(LOCATION);
        }

        public void SetRoomID (int currentLocation)
        {
            _session.SetInt32(LOCATION, currentLocation);
        }

        public void SavePlayerStats (Player stats)
        {
            _session.Set(PLAYERSTATS, stats);
        }
       
    }
}
