using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Postulaciones
    {
        /*         
         */

        public int? id_postulacion { get; set; }
        public int? id_alumno { get; set; }
        public int? id_familia { get; set; }
        public int? id_seguro { get; set; }
        public int? id_programa { get; set; }
        public DateTime feh_postulacion { get; set; }
        public DateTime fech_respuesta { get; set; }
        public string estado { get; set; }
        public int? reserva_dinero_pasajes { get; set; }
        private ProgramaEstudio _programaEstudio;

        public ProgramaEstudio programaEstudio
        {
            get
            {
                if (_programaEstudio == null)
                {
                    _programaEstudio = new ProgramaEstudio();
                }
                return _programaEstudio;
            }
            set { _programaEstudio = value; }
        }
        private Alumno _alumno;

        public Alumno alumno
        {
            get
            {
                if (_alumno == null)
                {
                    _alumno = new Alumno();
                }

                return _alumno;
            }
            set { _alumno = value; }
        }

        private Seguro _seguro;

        public Seguro seguro
        {
            get
            {
                if (_seguro == null)
                {
                    _seguro = new Seguro();
                }

                return _seguro;
            }
            set { _seguro = value; }
        }

        private Familia _familia;

        public Familia familia
        {
            get
            {
                if (_familia == null)
                {
                    _familia = new Familia();
                }
                return _familia;
            }
            set { _familia = value; }
        }

        public List<Object> GetPostulaciones()
        {
            Postulaciones post = new Postulaciones();

            List<object> lstPostulaciones = UTILS.GET("private/postulacion", "postulacion", AuthUser.token, post.GetType());
            if (lstPostulaciones == null || lstPostulaciones.Count == 0)
            {
                return null;
            }
            /**/
            ProgramaEstudio proest = new ProgramaEstudio();
            List<object> lstproest = proest.GetProgramasEstudios();
            if (proest == null)
            {
                lstproest = new List<object>();
            }
            /**/
            Alumno al = new Alumno();
            List<object> lstAlu = al.GetAlumnos();
            if (lstAlu == null)
            {
                return null;
            }


            /*
             */
            return null;
        }
    }
}
