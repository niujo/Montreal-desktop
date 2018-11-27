using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using biMontreal;
using System.Net;
using SimpleJson;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;

namespace ConsoleApp1
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Program pg = new Program();
            
            String url = "http://192.168.85.131:3000";
            

            // Autenticar y recibir token de autenticacion
            Usuario u = new Usuario();
            u.usuario = "admin";
            u.contrasena = "admin";
           // UTILS ut = new UTILS();
            String token = pg.Autenticar(url, u);

            // Obtener direcciones
            Usuario usr = new Usuario();
            List<Usuario> lstDireccion = pg.GET(url, "private/usuario", "usuario", token, usr.GetType()).Cast<Usuario>().ToList();
            foreach (Usuario d in lstDireccion)
            {
                Console.WriteLine(d.ToString());
            }


            Console.ReadKey();
        }

        public bool decodeToken(String token)
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
            catch (Exception)
            {
                return false;
            }
        }

        public String Autenticar(String url, Usuario usr)
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
            } catch(Exception)
            {
                
            }
            
            return result;
        }

        public List<Object> GET(String url, String req, String objeto, String token, Type objType) 
        {
            var client = new RestClient(url);
            var request = new RestRequest(req, Method.GET);
            
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
        }
    }
}