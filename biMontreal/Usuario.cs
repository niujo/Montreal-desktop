using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace biMontreal
{
    public class Usuario
    {
        [JsonProperty("ID_USUARIO")]
        public int? id_usuario { get; set; }

        [JsonProperty("ID_ROL")]
        public int? id_rol { get; set; }

        [JsonProperty("USUARIO")]
        public String usuario { get; set; }

        [JsonProperty("CONTRASENA")]
        public String contrasena { get; set; }

        private Persona _persona;
        public Persona persona
        {
            get
            {
                if (_persona == null)
                {
                    _persona = new Persona();
                }
                return _persona;
            }

            set
            {
                _persona = value;
            }
        }
        private Rol _rol;
        public Rol rol
        {
            get
            {
                if (_rol == null)
                {
                    _rol = new Rol();
                }
                return _rol;
            }
            
            set
            {
                _rol = value;
            }
        }
        
        public override string ToString()
        {
            return "Nombre: " + persona.nombre + " " + persona.app_paterno + " " + persona.app_materno + " RUT: " + persona.rut + " ROL: " + rol.desc_rol;
        }
        
        public List<Object> getUsuarios()
        {
            try
            {
                Usuario u = new Usuario();
                List<Object> lstUsuarios = UTILS.GET("private/usuario", "usuario", AuthUser.token, u.GetType());
                if (lstUsuarios == null || lstUsuarios.Count == 0)
                {
                    return null;
                }
                Persona p = new Persona();
                List<Object> lstPersonas = p.GetPersonas();
                if (lstPersonas == null)
                {
                    return null;
                }
                for (int i = 0; i < lstUsuarios.Count; i++)
                {
                    for (int j = 0; j < lstPersonas.Count; j++)
                    {
                        Usuario usr = (Usuario)lstUsuarios[i];
                        Persona per = (Persona)lstPersonas[j];
                        if (usr.id_usuario.Equals(per.id_usuario))
                        {
                            usr.persona = per;
                            lstUsuarios[i] = usr;
                            break;
                        }
                    }
                }


                Rol r = new Rol();
                List<Object> lstRol = r.getRoles();
                if (lstRol == null)
                {
                    return null;
                }

                for (int i = 0; i < lstUsuarios.Count; i++)
                {
                    for (int j = 0; j < lstRol.Count; j++)
                    {
                        Usuario usr = (Usuario)lstUsuarios[i];
                        Rol rl = (Rol)lstRol[j];
                        if (usr.id_rol.Equals(rl.id_rol))
                        {
                            usr.rol = rl;
                            lstUsuarios[i] = usr;
                            break;
                        }
                    }
                }

                return lstUsuarios;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Boolean usuarioExists(string usuario)
        {
            try
            {
                Usuario u = new Usuario();
                List<Object> usuarios = UTILS.GET("private/usuario?usuario=" + usuario, "usuario", AuthUser.token, u.GetType());

                return usuarios != null && usuarios.Count > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Usuario guardarUsuario(Usuario usuario)
        {
            try
            {
                List<Object> usr = UTILS.POST("private/usuario", "usuario", AuthUser.token, usuario.GetType(), usuario);
                if (usr == null || usr.Count == 0)
                {
                    return null;
                }

                return (Usuario)usr[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void deleteUsuario(string id_usuario)
        {
            try
            {
                Usuario usr = new Usuario();
                UTILS.DELETE("private/usuario/" + id_usuario, "usuario", AuthUser.token, usr.GetType());

            } catch (Exception)
            {
                // do nothing
            }
        }
    }
}
