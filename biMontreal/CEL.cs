using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class CEL
    {
        [JsonProperty("ID_CEL")]
        public int? id_cel { get; set; }

        [JsonProperty("ID_USUARIO")]
        public int? id_usuario { get; set; }

        [JsonProperty("NOM_CENTRO")]
        public string nom_centro { get; set; }
        private Usuario _usuario;

        public Usuario usuario
        {
            get {
                if (_usuario==null)
                {
                    _usuario = new Usuario();
                }

                return _usuario; }
            set { _usuario = value; }
        }

        public List<object> getCELS()
        {
            try
            {
                CEL cel = new CEL();
                List<object> lstCEL = UTILS.GET("private/cel", "cel", AuthUser.token, cel.GetType());
                if (lstCEL == null || lstCEL.Count == 0)
                {
                    return null;
                }
                return lstCEL;
            } catch (Exception)
            {
                return null;
            }
        }

        public CEL guardarCEL(CEL cel)
        {
            try
            {
                List<Object> c = UTILS.POST("private/cel", "cel", AuthUser.token, cel.GetType(), cel);

                if (c == null || c.Count == 0)
                {
                    return null;
                }

                return (CEL)c[0];
            } catch (Exception)
            {
                return null;
            }
        }

    }
}
