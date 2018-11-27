using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Mail
    {
        [JsonProperty("TO")]
        public string to { get; set; }
        [JsonProperty("SUBJECT")]
        public string subject { get; set; }
        [JsonProperty("TEXT")]
        public string text { get; set; }

        public void envioCorreo(string id_alumno, string estado, string nomb_programa, DateTime? fech_respuesta)
        {
            try
            {
                if (estado.Equals("A"))
                {
                    estado = "Aprobada";
                } else if (estado.Equals("R"))
                {
                    estado = "Rechazada";
                }

                Alumno al = new Alumno();
                List<Object> alumno = UTILS.GET("private/alumno/" + id_alumno, "alumno", AuthUser.token, al.GetType());
                if (alumno != null && alumno.Count > 0)
                {
                    al = (Alumno)alumno[0];
                    string id_usuario = al.id_usuario.ToString();

                    Persona per = new Persona();
                    List<Object> persona = UTILS.GET("private/persona?id_usuario=" + id_usuario, "persona", AuthUser.token, per.GetType());

                    if (persona != null && persona.Count > 0)
                    {
                        per = (Persona)persona[0];
                        string id_persona = per.id_persona.ToString();

                        Contacto cont = new Contacto();
                        List<Object> contacto = UTILS.GET("private/contacto?id_persona=" + id_persona, "contacto", AuthUser.token, cont.GetType());

                        if (contacto != null && contacto.Count > 0)
                        {
                            cont = (Contacto)contacto[0];
                            Mail email = new Mail();
                            email.to = cont.desc_contacto;
                            email.text = "Estimado Alumno, \n\nHoy " + fech_respuesta.Value.ToShortDateString() + " su postulación al programa \"" + nomb_programa + "\" ha sido " + estado;
                            email.subject = "Respuesta Postulación";

                            UTILS.POST("private/email", "", AuthUser.token, email.GetType(), email);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}
