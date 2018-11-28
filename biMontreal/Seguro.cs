using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Seguro
    {
        [JsonProperty("ID_SEGURO")]
        public int? id_seguro { get; set; }

        [JsonProperty("DESC_SEGURO")]
        public string desc_seguro { get; set; }

        [JsonProperty("VIGENTE")]
        public bool vigente { get; set; }


        public List<Object> getSeguros()
        {
            try
            {
                Seguro se = new Seguro();
                List<Object> lstSeguros = UTILS.GET("private/seguro", "seguro", AuthUser.token, se.GetType());
                if (lstSeguros == null || lstSeguros.Count == 0)
                {
                    return null;
                }

                return lstSeguros;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
