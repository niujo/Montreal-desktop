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
    /// Lógica de interacción para UsuariosActualizar.xaml
    /// </summary>
    public partial class UsuariosActualizar : Window
    {
        public UsuariosActualizar()
        {
            InitializeComponent();
            lblNombre.Content = AuthUser.nombre;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_Anterior_Click(object sender, RoutedEventArgs e)
        {
            VerUsuarios menu = new VerUsuarios();
            menu.Show();
            this.Close();
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool validaciones()
        {
            try
            {
                //int value;
                bool nombre = !(txtNombre.Text == null || txtNombre.Text.Equals(String.Empty));
                bool apeP = !(txtApp.Text == null || txtApp.Text.Equals(String.Empty));
                bool apeM = !(txtApm.Text == null || txtApm.Text.Equals(String.Empty));
                bool rut = !(txtRut.Text == null || txtRut.Text.Equals(String.Empty));
                //fecha
                /*
                 if (fecha. datetime. now < datetime.now)
                 */
                bool correo = !(txtCorreo.Text == null || txtCorreo.Text.Equals(String.Empty));
                bool calle = !(txtCalle.Text == null || txtCalle.Text.Equals(String.Empty));
                bool numeracion = !(txtNum.Text == null || txtNum.Text.Equals(String.Empty));
                bool dpto = !(txtDpto.Text == null || txtDpto.Text.Equals(String.Empty));

                lblNomb.Content = nombre ? "" : "*";
                lblApP.Content = apeP ? "" : "*";
                lblApM.Content = apeM ? "" : "*";
                lblRut.Content = rut ? "" : "*";
                lblCorreo.Content = correo ? "" : "*";
                lblCalle.Content = calle ? "" : "*";
                lblNumeracion.Content = numeracion ? "" : "*";
                lblDpto.Content = dpto ? "" : "*";



                bool valido = true && nombre && apeP && apeM && rut && correo && calle && numeracion && dpto;
                return valido;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
