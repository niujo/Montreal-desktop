using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Persona
    {
        [JsonProperty("ID_PERSONA")]
        public int? id_persona { get; set; }

        [JsonProperty("ID_DIRECCION")]
        public int? id_direccion { get; set; }

        [JsonProperty("ID_USUARIO")]
        public int? id_usuario { get; set; }

        [JsonProperty("RUT")]
        public String rut { get; set; }

        [JsonProperty("NOMBRE")]
        public String nombre { get; set; }

        [JsonProperty("APP_PATERNO")]
        public String app_paterno { get; set; }

        [JsonProperty("APP_MATERNO")]
        public String app_materno { get; set; }

        [JsonProperty("FECH_NACIMIENTO")]
        public DateTime fech_nacimiento { get; set; }
        
        public Direccion direccion { get; set; }
        public Contacto contacto { get; set; }

        public List<Object> GetPersonas()
        {
            try
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
                Direccion dir = new Direccion();
                List<Object> direcciones = dir.GetDireccion();

                Persona per;
                Contacto con;
                for (int i = 0; i < lstPersona.Count; i++)
                {
                    for (int j = 0; j < lstContactos.Count; j++)
                    {
                        con = (Contacto)lstContactos[j];
                        per = (Persona)lstPersona[i];
                        if (per.id_persona.Equals(con.id_persona))
                        {
                            per.contacto = con;
                            lstPersona[i] = per;
                            break;
                        }
                    }

                    for (int j = 0; j < direcciones.Count; j++)
                    {
                        dir = (Direccion)direcciones[j];
                        per = (Persona)lstPersona[i];
                        if (per.id_direccion.Equals(dir.id_direccion))
                        {
                            per.direccion = dir;
                            lstPersona[i] = per;
                            break;
                        }
                    }
                }

                return lstPersona;
            } catch (Exception)
            {
                return null;
            }
        }

        public Boolean rutExists(string rut)
        {
            try
            {
                Persona per = new Persona();
                List<Object> persona = UTILS.GET("private/persona?rut=" + rut, "persona", AuthUser.token, per.GetType());

                return persona != null && persona.Count > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Persona guardarPersona(Persona persona)
        {
            try
            {
                List<Object> per = UTILS.POST("private/persona", "persona", AuthUser.token, persona.GetType(), persona);

                if (per == null || per.Count == 0)
                {
                    return null;
                }

                return (Persona)per[0];
            } catch (Exception)
            {
                return null;
            }
        }

        public bool actualizarPersona(Persona persona)
        {
            try
            {
                string id = persona.id_persona.ToString();

                List<Object> per = UTILS.PUT("private/persona/" + id, "persona", AuthUser.token, persona.GetType(), persona);

                return (per != null && per.Count != 0);
            } catch (Exception)
            {
                return false;
            }
        }

    }
}
