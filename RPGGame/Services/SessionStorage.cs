using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGGame.Services
{
    public class SessionStorage<T>
    {
        readonly ISession _session;
        const string CHARACTERNAME = "JmenoPostavy";

        private string _characterName;

        public bool IsSetName { get; }

        public SessionStorage(IHttpContextAccessor hca)
        {
            _session = hca.HttpContext.Session;

            string jmeno = _session.GetString(CHARACTERNAME);
            if (jmeno != default)
            {
                _characterName = jmeno;
                IsSetName = true;
            }
            else
            {
                IsSetName = false;
            }
        }

      
        private void SetNameOfCharacter (string data)
        {
            _session.SetString(CHARACTERNAME, data);
            _characterName = data;
        }

        private void ClearNameOfCharacter ()
        {
            _session.SetString(CHARACTERNAME, null);
        }

        public string GetCharacterName ()
        {
            return _characterName;
        }
    }
}
