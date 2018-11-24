using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Rol
    {
        /*
         
        */

        public int? id_rol { get; set; }
        public String desc_rol { get; set; }

        public List<Object> getRoles()
        {
            Rol r = new Rol();
            List<Object> lstRol = UTILS.GET("private/rol", "rol", AuthUser.token, r.GetType());
            if (lstRol == null || lstRol.Count == 0)
            {
                return null;
            }

            return lstRol;
        }
    }
}
