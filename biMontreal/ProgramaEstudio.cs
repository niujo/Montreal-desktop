﻿using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class ProgramaEstudio
    {
        

        public int? id_programa { get; set; }
        public int? id_cem { get; set; }
        public int? id_cel { get; set; }
        public String nomb_programa { get; set; }
        public String desc_programa { get; set; }
        public DateTime fech_inicio { get; set; }
        public DateTime fech_termino { get; set; }
        public int? cant_min_alumnos { get; set; }
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

            return lstProgramas;
        }

        public List<object> GetProgramasEstudios()
        {

            ProgramaEstudio progEst = new ProgramaEstudio();
            List<object> lstProgramas = UTILS.GET("private/programa", "programa", AuthUser.token, progEst.GetType());
            if (lstProgramas == null || lstProgramas.Count == 0)
            {
                return null;
            }
            return lstProgramas;
        }
    }
}