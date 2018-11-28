using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Pais
    {
        [JsonProperty("ID_PAIS")]
        public int? id_pais { get; set; }

        [JsonProperty("NOMBRE")]
        public String nombre { get; set; }

        public List<object> getPais()
        {
            try
            {
                Pais pais = new Pais();
                List<object> lstPais = UTILS.GET("private/pais", "pais", AuthUser.token, pais.GetType());
                if (lstPais == null || lstPais.Count == 0)
                {
                    return null;
                }
                return lstPais;
            } catch (Exception)
            {
                return null;
            }
        }
    }
}
