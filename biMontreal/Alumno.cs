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
    }
}
