﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace biMontreal
{
    public class Direccion
    {
        [JsonProperty("DEPARTAMENTO")]
        public String departamento { get; set; }

        [JsonProperty("NUMERACION")]
        public String numeracion { get; set; }

        [JsonProperty("CALLE")]
        public String calle { get; set; }

        [JsonProperty("ID_DIRECCION")]
        public int? id_direccion { get; set; }

        [JsonProperty("ID_CIUDAD")]
        public int? id_ciudad { get; set; }
        public Ciudad ciudad { get; set; }

        public override string ToString()
        {
            return "id_direccion: " + id_direccion + " id_ciudad: " + id_ciudad + " departamento: " + departamento + " numeracion: " + numeracion + " calle: " + calle;
        }

        public List<Object> GetDireccion()
        {
            try
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

                for (int i = 0; i < lstDireccion.Count; i++)
                {
                    for (int j = 0; j < lstCiudades.Count; j++)
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
            } catch (Exception)
            {
                return null;
            }
        }

        public Direccion guardarDireccion(Direccion direccion)
        {
            try
            {
                List<Object> dir = UTILS.POST("private/direccion", "direccion", AuthUser.token, direccion.GetType(), direccion);

                if (dir == null || dir.Count == 0)
                {
                    return null;
                }

                return (Direccion)dir[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool actualizarDireccion(Direccion direccion)
        {
            try
            {
                string id = direccion.id_direccion.ToString();

                List<Object> dir = UTILS.PUT("private/direccion/" + id, "direccion", AuthUser.token, direccion.GetType(), direccion);

                return (dir != null && dir.Count != 0);
            } catch (Exception)
            {
                return false;
            }
        }
    }
}

