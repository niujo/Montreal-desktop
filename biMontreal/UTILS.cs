using System;
using System.Collections.Generic;
using RestSharp;
using System.Text;
using System.Net;
using SimpleJson;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace biMontreal
{
    public static class UTILS
    {
        private static readonly String url = "http://localhost:3000";
        // private static readonly String url = "http://192.168.43.52:3000/";
        public static bool decodeToken(String token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var tokenS = handler.ReadToken(token) as JwtSecurityToken;
                String t = tokenS.ToString();
                JObject obj = JObject.Parse(t.Split('.')[1]);

                UserDTO u = obj.ToObject<UserDTO>();

                AuthUser.id = u.id;
                AuthUser.rol = u.rol;
                AuthUser.nombre = u.nombre;

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static String Autenticar(Usuario usr)
        {
            var client = new RestClient(url);
            var request = new RestRequest("auth", Method.POST);
            request.RequestFormat = RestSharp.DataFormat.Json;

            request.AddBody(new { USUARIO = usr.usuario, CONTRASENA = usr.contrasena });
            
            // HTTP Headers
            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json; charset=utf-8"; };

            // Se ejecuta el request
            IRestResponse response = client.Execute(request);
            // Se consigue el json del request
            var jsonString = response.Content;

            IList<Direccion> lstDireccion = new List<Direccion>();

            // Se convierte el string json a un objeto json
            JObject content = JObject.Parse(jsonString);

            // Del objeto JSON navegamoso al objeto data y luego al array direccion
            String result = null;
            try
            {
                result = content["data"]["token"].ToString();
            }
            catch (Exception e)
            {
                //
            }

            return result;
        }

        /**
         * Método para realizar peticiones GET de forma dinamica
         * param ruta -> ruta de la api, Ej; "private/direccion"
         * param objeto -> objeto a deserializar, Ej; "direccion"
         * param token -> jwt token de autenticación
         * param objType -> Objeto de tipo Type de la clase a deserealizar, Ej; Direccion dir = new Direccion(); dir.GetType();
         * returns IList<Object> con los datos recuperados. Null en caso de error.
         */
        public static List<Object> GET(String ruta, String objeto, String token, Type objType)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(ruta, Method.GET);

                // HTTP Headers
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                request.AddHeader("Authorization", "Bearer " + token);

                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json; charset=utf-8"; };

                // Se ejecuta el request
                IRestResponse response = client.Execute(request);
                // Se consigue el json del request
                var jsonString = response.Content;

                List<Object> list = new List<Object>();

                // Se convierte el string json a un objeto json
                JObject content = JObject.Parse(jsonString);

                // Del objeto JSON navegamoso al objeto data y luego al array direccion
                IList<JToken> results = content["data"][objeto].ToList();
                Object obj = Activator.CreateInstance(objType);
                // Se crea una lista del objeto
                foreach (JToken result in results)
                {
                    // Se deserializa el objeto, se instancia y se agrega a la lista.
                    obj = result.ToObject(objType);
                    list.Add(obj);
                }

                return list;
            } catch (Exception e)
            {
                return null;
            }
        }
        /*ELiminar*/
        public static List<Object> DELETE(String ruta, String objeto, String token, Type objType)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(ruta, Method.DELETE);

                // HTTP Headers
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                request.AddHeader("Authorization", "Bearer " + token);

                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json; charset=utf-8"; };

                // Se ejecuta el request
                IRestResponse response = client.Execute(request);
                // Se consigue el json del request
                var jsonString = response.Content;

                List<Object> list = new List<Object>();

                // Se convierte el string json a un objeto json
                JObject content = JObject.Parse(jsonString);

                // Del objeto JSON navegamoso al objeto data y luego al array direccion
                JToken results = content["data"][objeto];
                Object obj = Activator.CreateInstance(objType);
                obj = results.ToObject(objType);
                list.Add(obj);

                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /*CREAR*/
        public static List<Object> POST(String ruta, String objeto, String token, Type objType, Object body)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(ruta, Method.POST);
                // HTTP Headers
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                request.AddHeader("Authorization", "Bearer " + token);

                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json; charset=utf-8"; };

                // Body del request
                request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(body), ParameterType.RequestBody);

                // Se ejecuta el request
                IRestResponse response = client.Execute(request);
                // Se consigue el json del request
                var jsonString = response.Content;

                List<Object> list = new List<Object>();

                // Se convierte el string json a un objeto json
                JObject content = JObject.Parse(jsonString);

                // Del objeto JSON navegamoso al objeto data y luego al array direccion
                JToken results = content["data"][objeto];
                Object obj = Activator.CreateInstance(objType);
                obj = results.ToObject(objType);
                list.Add(obj);

                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /*ACTUALIZAR*/
        public static List<Object> PUT(String ruta, String objeto, String token, Type objType, Object body)
        {
            try
            {
                var client = new RestClient(url);
                var request = new RestRequest(ruta, Method.PUT);
                // HTTP Headers
                request.AddHeader("Content-Type", "application/json; charset=utf-8");
                request.AddHeader("Authorization", "Bearer " + token);

                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json; charset=utf-8"; };

                // Body del request
                request.AddParameter("application/json", Newtonsoft.Json.JsonConvert.SerializeObject(body), ParameterType.RequestBody);

                // Se ejecuta el request
                IRestResponse response = client.Execute(request);
                // Se consigue el json del request
                var jsonString = response.Content;

                List<Object> list = new List<Object>();

                // Se convierte el string json a un objeto json
                JObject content = JObject.Parse(jsonString);

                // Del objeto JSON navegamoso al objeto data y luego al array direccion
                JToken results = content["data"][objeto];
                Object obj = Activator.CreateInstance(objType);
                obj = results.ToObject(objType);
                list.Add(obj);

                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        /*  */
    }
}
