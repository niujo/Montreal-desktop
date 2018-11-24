using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
   public class CEM
    {

        public int? id_cem { get; set; }
        public int? id_usurio { get; set; }
        public string nom_centro { get; set; }
        private Usuario _usuario;

        public Usuario usuario
        {
            get
            {
                if (_usuario == null)
                {
                    _usuario = new Usuario();
                }

                return _usuario;
            }
            set { _usuario = value; }
        }

        public List<object> getCELS()
        {
            CEL cem = new CEL();
            List<object> lstCEL = UTILS.GET("private/cem", "cem", AuthUser.token, cem.GetType());
            if (lstCEL == null || lstCEL.Count == 0)
            {
                return null;
            }
            return lstCEL;
        }

    }
}
