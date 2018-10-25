using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Direccion
    {
        /*
         * Los atributos de las clases deben estar escritos igual que aquí (mismo formato public atributo nombre { get; set; })
         * y deben llamarse exactamente igual que como estan en el json que devuelve la API
         */
        public String departamento { get; set; }
        public String numeracion { get; set; }
        public String calle { get; set; }
        public int? id_direccion { get; set; }
        public int? id_ciudad { get; set; }

        public override string ToString()
        {
            return "id_direccion: " + id_direccion + " id_ciudad: " + id_ciudad + " departamento: " + departamento + " numeracion: " + numeracion + " calle: " + calle;
        }
    }
}

