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

        private Usuario usuario = null;

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

        
        private void brn_borrar_Click(object sender, RoutedEventArgs e)
        {
            if (usuario != null)
            {
                string id = usuario.id_usuario.ToString();
                UTILS.DELETE("private/usuario/" + id, "usuario", AuthUser.token, usuario.GetType());
                lstUsuario.Items.Remove(usuario);
                lstUsuario.Items.Refresh();
            }
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

        private void lstUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                usuario = (Usuario)lstUsuario.SelectedItem;

            }
            catch (Exception)
            {

                usuario = null;
            }
        }
    }
}
