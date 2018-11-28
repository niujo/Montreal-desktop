using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Postulaciones
    {
        [JsonProperty("ID_POSTULACION")]
        public int? id_postulacion { get; set; }

        [JsonProperty("ID_ALUMNO")]
        public int? id_alumno { get; set; }

        [JsonProperty("ID_FAMILIA")]
        public int? id_familia { get; set; }

        [JsonProperty("ID_SEGURO")]
        public int? id_seguro { get; set; }

        [JsonProperty("ID_PROGRAMA")]
        public int? id_programa { get; set; }

        [JsonProperty("FECH_POSTULACION")]
        public DateTime? fech_postulacion { get; set; }

        [JsonProperty("FECH_RESPUESTA")]
        public DateTime? fech_respuesta { get; set; }

        [JsonProperty("ESTADO")]
        public string estado { get; set; }

        [JsonProperty("RESERVA_DINERO_PASAJES")]
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

        public override string ToString()
        {
            return "Alumno: " + alumno.persona.nombre + " " + alumno.persona.app_paterno + " " + alumno.persona.app_materno
                + " Representante Familia: " + familia.persona.nombre + " " + familia.persona.app_paterno + " " + familia.persona.app_materno
                + " Seguro: " + seguro.desc_seguro
                + " Programa de Estudio: " + programaEstudio.nomb_programa
                + " Fecha de Postulacion:" + fech_postulacion.Value.ToShortDateString()
                + " Reserva de Dinero: " + reserva_dinero_pasajes;
        }

        public List<Object> GetPostulaciones()
        {
            try
            {
                Postulaciones post = new Postulaciones();

                List<object> lstPostulaciones = UTILS.GET("private/postulacion", "postulacion", AuthUser.token, post.GetType());
                if (lstPostulaciones == null || lstPostulaciones.Count == 0)
                {
                    return null;
                }
                /**/
                Familia fam = new Familia();
                List<object> lstFamilias = fam.GetFamilias();
                if (fam == null)
                {
                    lstFamilias = new List<object>();
                }
                /**/
                Alumno al = new Alumno();
                List<object> lstAlu = al.GetAlumnos();
                if (lstAlu == null)
                {
                    return null;
                }

                /* uniendo familia y  alumno con postulacion*/
                for (int i = 0; i < lstPostulaciones.Count; i++)
                {
                    for (int j = 0; j < lstAlu.Count; j++)
                    {
                        Alumno a = (Alumno)lstAlu[j];
                        Postulaciones po = (Postulaciones)lstPostulaciones[i];
                        if (po.id_alumno.Equals(a.id_alumno))
                        {
                            po.alumno = a;
                            lstPostulaciones[i] = po;
                            break;
                        }
                    }

                    for (int k = 0; k < lstFamilias.Count; i++)
                    {
                        Familia fa = (Familia)lstFamilias[k];
                        Postulaciones po = (Postulaciones)lstPostulaciones[i];
                        if (po.id_familia.Equals(fa.id_familia))
                        {
                            po.familia = fa;
                            lstPostulaciones[i] = po;
                            break;
                        }
                    }

                }
                /* llamando a seguro y asegurar que no sea nul o 0*/
                Seguro se = new Seguro();
                List<Object> lstSeguros = UTILS.GET("private/seguro", "seguro", AuthUser.token, se.GetType());
                if (lstSeguros != null & lstSeguros.Count > 0)
                {
                    se = (Seguro)lstSeguros[0];
                }

                ProgramaEstudio prog = new ProgramaEstudio();
                List<Object> lstProgramas = prog.GetProgramasEstudios();
                if (lstProgramas == null || lstProgramas.Count == 0)
                {
                    return null;
                }
                List<Object> arr = prog.filtrarProgramas(lstProgramas);
                List<Object> vigentes = (List<Object>)arr[0];
                List<Object> finalizados = (List<Object>)arr[1];

                bool vigente;
                Postulaciones p;
                ProgramaEstudio pe;
                for (int i = 0; i < lstPostulaciones.Count; i++)
                {
                    vigente = false;
                    p = (Postulaciones)lstPostulaciones[i];
                    p.seguro = se;
                    for (int j = 0; j < vigentes.Count; j++)
                    {
                        pe = (ProgramaEstudio)vigentes[j];
                        if (p.id_programa.Equals(pe.id_programa))
                        {
                            p.programaEstudio = pe;
                            lstPostulaciones[i] = p;
                            vigente = true;
                            break;
                        }
                    }

                    if (!vigente)
                    {
                        for (int j = 0; j < finalizados.Count; j++)
                        {
                            pe = (ProgramaEstudio)finalizados[j];
                            if (p.id_programa.Equals(pe.id_programa))
                            {
                                p.programaEstudio = pe;
                                lstPostulaciones[i] = p;
                                break;
                            }
                        }
                    }
                }

                List<Object> filtradas = filtrarPostulaciones(lstPostulaciones, arr);

                return filtradas;
            } catch (Exception)
            {
                return null;
            }
        }

        public List<Object> filtrarPostulaciones(List<Object> postulaciones, List<Object> programas)
        {
            List<Object> arr = new List<Object>();
            try
            {
                List<Object> vigentes = (List<Object>)programas[0];
                List<Object> finalizados = (List<Object>)programas[1];

                List<Object> post_vigentes = new List<Object>();
                List<Object> post_finalizadas = new List<Object>();

                if (postulaciones != null && postulaciones.Count > 0)
                {
                    bool vigente;
                    Postulaciones p;
                    ProgramaEstudio pe;
                    for (int i = 0; i < postulaciones.Count; i++)
                    {
                        vigente = false;
                        p = (Postulaciones)postulaciones[i];
                        for(int j = 0; j < vigentes.Count; j++)
                        {
                            pe = (ProgramaEstudio)vigentes[j];
                            if(p.estado.Equals("P") && p.id_programa.Equals(pe.id_programa))
                            {
                                post_vigentes.Add(p);
                                vigente = true;
                                break;
                            }
                        }

                        if (!vigente)
                        {
                            for(int j = 0; j < finalizados.Count; j++)
                            {
                                if (p.estado.Equals("R") || p.estado.Equals("A"))
                                {
                                    post_finalizadas.Add(p);
                                    break;
                                }
                                pe = (ProgramaEstudio)finalizados[j];
                                if (p.id_programa.Equals(pe.id_programa))
                                {
                                    if (p.estado.Equals("P"))
                                    {
                                        p.estado = "R";
                                        if (p.fech_respuesta == null)
                                        {
                                            p.fech_respuesta = DateTime.UtcNow.Date;
                                        }
                                        string id = p.id_postulacion.ToString();
                                        UTILS.PUT("private/postulacion/" + id, "postulacion", AuthUser.token, p.GetType(), p);
                                    }
                                    post_finalizadas.Add(p);
                                    break;
                                }
                            }
                        }
                    }
                }

                arr.Add(post_vigentes);
                arr.Add(post_finalizadas);

                return arr;
            }
            catch (Exception)
            {
                arr.Clear();
                arr.Add(new List<Object>());
                arr.Add(new List<Object>());
                return arr;
            }
        }
    }
}

