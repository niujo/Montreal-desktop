using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Persona
    {
        /*
         id_persona;
    private Integer id_direccion;
    private Integer id_usuario;
    private String rut;
    private String nombre;
    private String app_paterno;
    private String app_materno;
    private Date fech_nacimiento;
    private Direccion direccion;
    private Contacto contacto;
             */
        public int? id_persona { get; set; }
        public int? id_direccion { get; set; }
        public int? id_usuario { get; set; }
        public String rut { get; set; }
        public String nombre { get; set; }
        public String app_paterno { get; set; }
        public String app_materno { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public Direccion direccion { get; set; }
        public Contacto contacto { get; set; }

        public List<Object> GetPersonas()
        {
            Persona u = new Persona();
            List<Object> lstPersona = UTILS.GET("private/persona", "persona", AuthUser.token, u.GetType());
            if (lstPersona == null || lstPersona.Count == 0)
            {
                return null;
            }
            Contacto c = new Contacto();
            List<Object> lstContactos = c.getContactos();
            if (lstContactos == null)
            {
                return null;
            }

            for(int i = 0; i < lstPersona.Count; i++)
            {
                for(int j = 0; j < lstContactos.Count; j++)
                {
                    Contacto con = (Contacto)lstContactos[j];
                    Persona per = (Persona)lstPersona[i];
                    if (per.id_persona.Equals(con.id_persona))
                    {
                        per.contacto = con;
                        lstPersona[i] = per;
                        break;
                    }
                }
            }

            return lstPersona;
        }

    }
}
