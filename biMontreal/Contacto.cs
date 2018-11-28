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
            try
            {
                Contacto c = new Contacto();
                List<Object> lstContactos = UTILS.GET("private/contacto", "contacto", AuthUser.token, c.GetType());
                if (lstContactos == null || lstContactos.Count == 0)
                {
                    return null;
                }

                return lstContactos;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Contacto guardarContacto(Contacto contacto)
        {
            try
            {
                List<Object> cont = UTILS.POST("private/contacto", "contacto", AuthUser.token, contacto.GetType(), contacto);

                if (cont == null || cont.Count == 0)
                {
                    return null;
                }
                return (Contacto)cont[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool actualizarContacto(Contacto contacto)
        {
            try
            {
                string id = contacto.id_contacto.ToString();

                List<Object> cont = UTILS.PUT("private/contacto/" + id, "contacto", AuthUser.token, contacto.GetType(), contacto);

                return (cont != null && cont.Count != 0);
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
