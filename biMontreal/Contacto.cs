using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Contacto
    {
        [JsonProperty("ID_CONTACTO")]
        public int? id_contacto { get; set; }

        [JsonProperty("ID_PERSONA")]
        public int? id_persona { get; set; }

        [JsonProperty("DESC_CONTACTO")]
        public String desc_contacto { get; set; }

        [JsonProperty("TIPO_CONTACTO")]
        public String tipo_contacto { get; set; }

        public List<Object> getContactos()
        {
            Contacto c = new Contacto();
            List<Object> lstContactos = UTILS.GET("private/contacto", "contacto", AuthUser.token, c.GetType());
            if (lstContactos == null || lstContactos.Count == 0)
            {
                return null;
            }

            return lstContactos;
        }
    }
}
