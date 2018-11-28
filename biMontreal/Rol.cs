using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Rol
    {
        [JsonProperty("ID_ROL")]
        public int? id_rol { get; set; }

        [JsonProperty("DESC_ROL")]
        public String desc_rol { get; set; }

        public List<Object> getRoles()
        {
            try
            {
                Rol r = new Rol();
                List<Object> lstRol = UTILS.GET("private/rol", "rol", AuthUser.token, r.GetType());
                if (lstRol == null || lstRol.Count == 0)
                {
                    return null;
                }

                return lstRol;
            } catch (Exception)
            {
                return null;
            }
        }
    }
}
