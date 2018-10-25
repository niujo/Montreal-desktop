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

        public override string ToString()
        {
            return "id_pais: " + id_pais + " id_ciudad: " + id_ciudad + " nombre ciudad: " + nombre ;
        }

    }
}
