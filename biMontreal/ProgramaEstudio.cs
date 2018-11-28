using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class ProgramaEstudio
    {

        [JsonProperty("ID_PROGRAMA")]
        public int? id_programa { get; set; }

        [JsonProperty("ID_CEM")]
        public int? id_cem { get; set; }

        [JsonProperty("ID_CEL")]
        public int? id_cel { get; set; }

        [JsonProperty("NOMB_PROGRAMA")]
        public String nomb_programa { get; set; }

        [JsonProperty("DESC_PROGRAMA")]
        public String desc_programa { get; set; }

        [JsonProperty("FECH_INICIO")]
        public DateTime fech_inicio { get; set; }

        [JsonProperty("FECH_TERMINO")]
        public DateTime fech_termino { get; set; }

        [JsonProperty("CANT_MIN_ALUMNOS")]
        public int? cant_min_alumnos { get; set; }

        [JsonProperty("CANT_MAX_ALUMNOS")]
        public int? cant_max_alumnos { get; set; }
        private CEL _cel;

        public CEL cel
        {
            get
            {
                if (_cel == null)
                {
                    _cel = new CEL();
                }

                return _cel; }
            set { _cel = value; }
        }

        public override string ToString()
        {
            string nom_centro = cel.nom_centro == String.Empty ? "Aún no se asigna ningún centro" : cel.nom_centro;
            return "Nombre: " +nomb_programa + " Descripción: " +desc_programa+" Centro Asignado: "+ nom_centro + " Fecha de inicio: "+fech_inicio.ToShortDateString()+" Fecha de termino: "+fech_termino.ToShortDateString();
        }

        public List<object> GetProgramasEstudiosCEL(){

            ProgramaEstudio progEst =new  ProgramaEstudio();
            List<object> lstProgramas = UTILS.GET("private/programa", "programa", AuthUser.token, progEst.GetType());
            if (lstProgramas==null|| lstProgramas.Count==0)
            {
                return null;
            }
            CEL cl = new CEL();
            List<object> lstCel = cl.getCELS();
            if (lstCel == null)
            {
                lstCel = new List<object>();
            }
            
            for(int i = 0; i < lstProgramas.Count; i++)
            {
                for(int j = 0; j < lstCel.Count; j++)
                {
                    CEL c = (CEL)lstCel[j];
                    ProgramaEstudio pg = (ProgramaEstudio)lstProgramas[i];
                    if (pg.id_cel.Equals(c.id_cel))
                    {
                        pg.cel = c;
                        lstProgramas[i] = pg;
                        break;
                    }
                }
            }

            List<Object> arr = filtrarProgramas(lstProgramas);

            return arr;
        }

        public List<object> GetProgramasEstudios()
        {
            try
            {
                ProgramaEstudio progEst = new ProgramaEstudio();
                List<object> lstProgramas = UTILS.GET("private/programa", "programa", AuthUser.token, progEst.GetType());
                if (lstProgramas == null || lstProgramas.Count == 0)
                {
                    return null;
                }
                return lstProgramas;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Object> filtrarProgramas(List<Object> programas)
        {
            try
            {
                DateTime fecha = DateTime.UtcNow.Date;
                List<Object> vigentes = new List<Object>();
                List<Object> finalizados = new List<Object>();

                if (programas != null && programas.Count > 0)
                {
                    ProgramaEstudio pg;
                    for (int i = 0; i < programas.Count; i++)
                    {
                        pg = (ProgramaEstudio)programas[i];
                        DateTime fechaTermino = pg.fech_termino;
                        if (fechaTermino.Date < fecha)
                        {
                            finalizados.Add(pg);
                        }
                        else
                        {
                            vigentes.Add(pg);
                        }
                    }
                }

                List<Object> arr = new List<Object>();
                arr.Add(vigentes);
                arr.Add(finalizados);

                return arr;
            } catch(Exception)
            {
                return null;
            }
        }

        public bool actualizarPrograma(ProgramaEstudio programa)
        {
            try
            {
                string id = programa.id_programa.ToString();
                List<Object> prog = UTILS.PUT("private/programa/" + id, "programa", AuthUser.token, programa.GetType(), programa);

                return (prog != null && prog.Count != 0);
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
