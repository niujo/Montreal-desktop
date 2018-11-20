using System;
using System.Collections.Generic;

namespace biMontreal
{
    public class Usuario
    {
        public int? id_usuario { get; set; }
        public int? id_rol { get; set; }
        public String usuario { get; set; }
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
            for(int i = 0; i < lstUsuarios.Count; i++)
            {
                for(int j = 0; j < lstPersonas.Count; j++)
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

            for(int i = 0; i < lstUsuarios.Count; i++)
            {
                for(int j = 0; j < lstRol.Count; j++)
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
    }
}
