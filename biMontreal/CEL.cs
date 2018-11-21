using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class CEL
    {
        /*
         private Integer id_cel;
    private Integer id_usuario;
    private String nom_centro;
    private Usuario usuario;
         */
         public int? id_cel { get; set; }
        public int? id_usurio { get; set; }
        public string nom_centro { get; set; }
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

        public List<object> getCELS()
        {
            CEL cel = new CEL();
            List<object> lstCEL = UTILS.GET("private/cel", "cel",AuthUser.token, cel.GetType());
            if (lstCEL==null|| lstCEL.Count==0)
            {
                return null;
            }
            return lstCEL;
        }


    }
}
