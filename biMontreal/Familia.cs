using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Familia
    {
        [JsonProperty("ID_FAMILIA")]
        public int? id_familia { get; set; }

        [JsonProperty("ID_USUARIO")]
        public int? id_usuario { get; set; }

        [JsonProperty("NUM_INTEGRANTES")]
        public int? num_integrantes { get; set; }

        [JsonProperty("ESTADO")]
        public string estado { get; set; }
        private Persona _persona;

        public Persona persona
        {
            get {
                if (_persona==null)
                {
                    _persona = new Persona();
                }
                return _persona; }
            set { _persona = value; }
        }

        private Usuario _usuario;

        public Usuario usuario
        {
            get {
                if (_usuario==null)
                {
                    _usuario = new Usuario();
                }
                return _usuario; }
            set { _usuario = value; }
        }

        public List<Object> GetFamilias()
        {
            Familia f = new Familia();
            Persona p = new Persona();
            List<Object> lstFamilias = UTILS.GET("private/familia", "familia", AuthUser.token, f.GetType());
            if (lstFamilias == null || lstFamilias.Count == 0)
            {
                return null;
            }
            List<Object> lstPersonas = p.GetPersonas();
            if (lstPersonas == null)
            {
                return null;
            }

            for (int i = 0; i < lstFamilias.Count; i++)
            {
                for (int j = 0; j < lstPersonas.Count; j++)
                {
                    Familia fa = (Familia)lstFamilias[i];
                    Persona per = (Persona)lstPersonas[j];
                    if (fa.id_usuario.Equals(per.id_usuario))
                    {
                        fa.persona = per;
                        lstFamilias[i] = fa;
                        break;
                    }
                }
            }
            return lstFamilias;
        }

    }
}
