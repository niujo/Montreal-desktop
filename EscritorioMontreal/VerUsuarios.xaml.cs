using biMontreal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EscritorioMontreal
{
    /// <summary>
    /// Lógica de interacción para VerUsuarios.xaml
    /// </summary>
    public partial class VerUsuarios : Window
    {
        public VerUsuarios()
        {
            InitializeComponent();

            lblNombre.Content = AuthUser.nombre;

            Usuario u = new Usuario();
            List<Object> lstUsuarios = u.getUsuarios();
            // aca se  recibe
            if (lstUsuarios == null)
            {
                lstUsuarios = new List<Object>();
            }

            foreach(Usuario us in lstUsuarios) {
                lstUsuario.Items.Add(us);
            }
        }

        

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            UsuariosAgregar Agr = new UsuariosAgregar();
            Agr.Show();
            this.Close();
        }

        private void brn_borrar_Click(object sender, RoutedEventArgs e)
        {
            UsuariosBorrar brr = new UsuariosBorrar();
            brr.Show();
            this.Close();
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            UsuariosActualizar uaC = new UsuariosActualizar();
            uaC.Show();
            this.Close();
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        
    }
}
