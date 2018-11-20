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
        public Ciudad ciudad { get; set; }

        public override string ToString()
        {
            return "id_direccion: " + id_direccion + " id_ciudad: " + id_ciudad + " departamento: " + departamento + " numeracion: " + numeracion + " calle: " + calle;
        }

        public List<Object> GetDireccion()
        {

            Direccion d = new Direccion();
            Ciudad ci = new Ciudad();
            List<Object> lstDireccion = UTILS.GET("private/direccion", "direccion", AuthUser.token, d.GetType());
            if (lstDireccion == null || lstDireccion.Count == 0)
            {
                return null;
            }
            List<Object> lstCiudades = ci.GetCiudades();
            if (lstCiudades == null)
            {
                return null;
            }

            for(int i = 0; i < lstDireccion.Count; i++)
            {
                for(int j = 0; j < lstCiudades.Count; j++)
                {
                    Direccion dir = (Direccion)lstDireccion[i];
                    Ciudad ciu = (Ciudad)lstCiudades[j];
                    if (dir.id_ciudad.Equals(ciu.id_ciudad))
                    {
                        dir.ciudad = ciu;
                        lstDireccion[i] = dir;
                        break;
                    }
                }
            }

            return lstDireccion;
        }
    }
}

