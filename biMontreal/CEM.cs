using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
   public class CEM
    {
        [JsonProperty("ID_CEM")]
        public int? id_cem { get; set; }

        [JsonProperty("ID_USUARIO")]
        public int? id_usuario { get; set; }

        [JsonProperty("NOM_CENTRO")]
        public string nom_centro { get; set; }
        private Usuario _usuario;

        public Usuario usuario
        {
            get
            {
                if (_usuario == null)
                {
                    _usuario = new Usuario();
                }

                return _usuario;
            }
            set { _usuario = value; }
        }

        public List<object> getCEM()
        {
            CEM cem = new CEM();
            List<object> lstCEM = UTILS.GET("private/cem", "cem", AuthUser.token, cem.GetType());
            if (lstCEM == null || lstCEM.Count == 0)
            {
                return null;
            }
            return lstCEM;
        }

    }
}
