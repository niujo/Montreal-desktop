using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Alumno
    {
        [JsonProperty("ID_ALUMNO")]
        public int id_alumno { get; set; }

        [JsonProperty("ID_USUARIO")]
        public int? id_usuario { get; set; }

        private Persona _persona;

        public Persona persona
        {
            get {
                if (_persona == null)
                {
                    _persona = new Persona();
                }
                return _persona;
            }
            set { _persona = value; }
        }

        public override string ToString()
        {
            return "id Alumno: " + id_alumno + " id_ciudad: " + id_usuario;
        }


        public List<Object> GetAlumnos()
        {
            Alumno alu = new Alumno();

            List<Object> lstAlumnos = UTILS.GET("private/alumno", "alumno", AuthUser.token, alu.GetType());
            if (lstAlumnos == null || lstAlumnos.Count == 0)
            {
                return null;
            }
            Persona per = new Persona();
            List<Object> lstPersonas = per.GetPersonas();
            if (lstPersonas == null || lstPersonas.Count == 0)
            {
                return null;
            }

            for(int i = 0; i < lstAlumnos.Count; i++)
            {
                for(int j = 0; j < lstPersonas.Count; j++)
                {
                    Persona p = (Persona)lstPersonas[j];
                    Alumno a = (Alumno)lstAlumnos[i];
                    if (p.id_usuario.Equals(a.id_usuario))
                    {
                        a.persona = p;
                        lstAlumnos[i] = a;
                        break;
                    }
                }
            }

            return lstAlumnos;
        }
    }
}
