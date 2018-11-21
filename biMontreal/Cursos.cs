using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Cursos
    {

        public int? id_Curso { get; set; }
        public int? id_programa { get; set; }
        public String desc_curso { get; set; }
    
        public String cupos { get; set; }


        private ProgramaEstudio _programaEstudio;

        public ProgramaEstudio programaEstudio
        {
            get {
                if (_programaEstudio==null)
                {
                    _programaEstudio = new ProgramaEstudio();
                }
                return _programaEstudio; }
            set { _programaEstudio = value; }
        }


        public override string ToString()
        {
            string programa = programaEstudio.nomb_programa == String.Empty ? "Aún no se asigna un programa" : programaEstudio.nomb_programa;
            return "Programa asociado: " + programaEstudio.nomb_programa + " Descripción: " + desc_curso +" Cupos: "+ cupos ;
        }

        public List<object> getCursos() {
            Cursos crs = new Cursos();
            List<object> lstCursos = UTILS.GET("private/curso","curso",AuthUser.token,crs.GetType());
            if (lstCursos==null||lstCursos.Count==0)
            {
                return null;
            }
            ProgramaEstudio prg = new ProgramaEstudio();
            List<object> lstPrograma = prg.GetProgramasEstudios();
            if (lstPrograma==null)
            {
                lstPrograma = new List<object>();
            }

            for (int i = 0; i < lstCursos.Count; i++)
            {
                for (int j = 0; j < lstPrograma.Count; j++)
                {
                    Cursos c = (Cursos)lstCursos[i];
                    ProgramaEstudio p = (ProgramaEstudio)lstPrograma[j];
                    if (c.id_programa.Equals(p.id_programa))
                    {
                        c.programaEstudio = p;
                        lstCursos[i] = c;
                        break;
                    }
                }
            }
            return lstCursos;
        }
        
    }
}
