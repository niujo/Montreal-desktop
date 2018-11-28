using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Cursos
    {
        [JsonProperty("ID_CURSO")]
        public int? id_curso { get; set; }

        [JsonProperty("ID_PROGRAMA")]
        public int? id_programa { get; set; }

        [JsonProperty("DESC_CURSO")]
        public String desc_curso { get; set; }

        [JsonProperty("CUPOS")]
        public int? cupos { get; set; }


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
            try
            {
                Cursos crs = new Cursos();
                List<object> lstCursos = UTILS.GET("private/curso", "curso", AuthUser.token, crs.GetType());
                if (lstCursos == null || lstCursos.Count == 0)
                {
                    return null;
                }
                ProgramaEstudio prg = new ProgramaEstudio();
                List<object> lstPrograma = prg.GetProgramasEstudios();
                if (lstPrograma == null)
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
            } catch (Exception)
            {
                return null;
            }
        }
        
        public bool actualizarCurso(Cursos curso)
        {
            try
            {
                string id_curso = curso.id_curso.ToString();
                List<Object> c = UTILS.PUT("private/curso/" + id_curso, "curso", AuthUser.token, curso.GetType(), curso);

                return (c != null && c.Count != 0);
            } catch (Exception)
            {
                return false;
            }
        }
    }
}
