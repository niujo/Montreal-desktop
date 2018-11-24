using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Seguro
    {
        /*
         *  private Integer id_seguro;
    private String desc_seguro;
    private boolean vigente;
         */
         public int? id_seguro { get; set; }
        public string desc_seguro { get; set; }
        public bool vigente { get; set; }


        public List<Object> getSeguros()
        {
            Seguro se = new Seguro();
            List<Object> lstSeguros = UTILS.GET("private/seguro", "seguro", AuthUser.token, se.GetType());
            if (lstSeguros == null || lstSeguros.Count == 0)
            {
                return null;
            }

            return lstSeguros;
        }

    }
}
