using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Alumno
    {
        public int id_Alumno { get; set; }
        public String id_usuario { get; set; }

        public override string ToString()
        {
            return "id Alumno: " + id_Alumno + " id_ciudad: " + id_usuario;
        }


        public List<Object> GetAlumnos()
        {
            Alumno alu = new Alumno();

            List<Object> lstAlumnos = UTILS.GET("private/alumno", "alumno", AuthUser.token, alu.GetType());
            if (lstAlumnos == null || lstAlumnos.Count == 0)
            {
                return null;
            }
            return lstAlumnos;
        }
    }
}
