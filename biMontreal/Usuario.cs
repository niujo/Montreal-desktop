using System;

namespace biMontreal
{
    public class Usuario
    {
        public int? id_usuario { get; set; }
        public int? id_rol { get; set; }
        public String usuario { get; set; }
        public String contrasena { get; set; }

        public override string ToString()
        {
            return "id_usuario: " + id_usuario + " id_rol: " + id_rol + " usuario: " + usuario + " contrasena: " + contrasena;
        }
    }
}
