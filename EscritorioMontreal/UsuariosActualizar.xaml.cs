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
        private Usuario usr = null;
        public UsuariosActualizar(Usuario usuario)
        {
            InitializeComponent();
            lblNombre.Content = AuthUser.nombre;

            Ciudad p = new Ciudad();
            List<Object> lstCiudad = p.GetCiudades();
            if (lstCiudad == null)
            {
                lstCiudad = new List<Object>();
            }

            cbCiudad.SelectedValuePath = "Key";
            cbCiudad.DisplayMemberPath = "Value";
            foreach (Ciudad pe in lstCiudad)
            {
                cbCiudad.Items.Add(new KeyValuePair<int?, string>(pe.id_ciudad, pe.nombre));
            }

            if (usuario != null)
            {
                usr = usuario;
                txtNombre.Text = usuario.persona.nombre;
                txtApp.Text = usuario.persona.app_paterno;
                txtApm.Text = usuario.persona.app_materno;
                txtRut.Text = usuario.persona.rut;
                fchNac.SelectedDate = usuario.persona.fech_nacimiento;
                txtCorreo.Text = usuario.persona.contacto.desc_contacto;

                cbCiudad.SelectedValue = usuario.persona.direccion.id_ciudad;
                txtCalle.Text = usuario.persona.direccion.calle;
                txtNum.Text = usuario.persona.direccion.numeracion;
                txtDpto.Text = usuario.persona.direccion.departamento;
            }
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
            try
            {

            } catch (Exception)
            {
                // nada
            }
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
