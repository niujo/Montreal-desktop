using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Contacto
    {
        /*Integer id_contacto;
    private Integer id_persona;
    private String desc_contacto;
    private String tipo_contacto;*/

        public int? id_contacto { get; set; }
        public int? id_persona { get; set; }
        public String desc_contacto { get; set; }
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
