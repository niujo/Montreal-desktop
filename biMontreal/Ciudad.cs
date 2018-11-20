using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Ciudad
    {
        public int id_ciudad { get; set; }
        public String nombre { get; set; }
        public int? id_pais { get; set; }
        public Pais pais { get; set; }

        public override string ToString()
        {
            return "id_pais: " + id_pais + " id_ciudad: " + id_ciudad + " nombre ciudad: " + nombre ;
        }

        public List<Object> GetCiudades()
        {
            Ciudad cu = new Ciudad();
            Pais pa = new Pais();
            List<Object> lstCiudades = UTILS.GET("private/ciudad", "ciudad", AuthUser.token, cu.GetType());
            if (lstCiudades==null   ||  lstCiudades.Count == 0)
            {
                return null;
            }
            List<Object> lstPaises = UTILS.GET("private/pais", "pais", AuthUser.token, pa.GetType());
            if (lstPaises==null ||  lstPaises.Count==0)
            {
                return null;
            }
            for(int i = 0; i < lstCiudades.Count; i++)
            {
                for(int j = 0; j < lstPaises.Count; j++)
                {
                    Ciudad c = (Ciudad)lstCiudades[i];
                    Pais p = (Pais)lstPaises[j];
                    if (c.id_pais.Equals(p.id_pais))
                    {
                        c.pais = p;
                        lstCiudades[i] = c;
                        break;
                    }
                }
            }

            return lstCiudades;
        }

    }
}
