using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Cursos
    {

        public int id_Curso { get; set; }
        public String id_programa { get; set; }
        public String desc_curso { get; set; }
    
        public String cupos { get; set; }

        public override string ToString()
        {
            return "id Curso: " + id_Curso + " id_ciudad: " + id_programa +"Desc_curso"+ desc_curso +"Cupos"+cupos;
        }   
    }
}
