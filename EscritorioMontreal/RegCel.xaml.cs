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
using biMontreal;

namespace EscritorioMontreal
{
    /// <summary>
    /// Lógica de interacción para RegCel.xaml
    /// </summary>
    public partial class RegCel : Window
    {
        public RegCel()
        {
            InitializeComponent();

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
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtPsw.Text.Equals(txtRepPsw.Text))
            {
                Usuario usuario = new Usuario();
                CEL cel = new CEL();
                Direccion dir = new Direccion();
                Contacto cont = new Contacto();
                Persona per = new Persona();
                Rol rol = new Rol();

                usuario.usuario = txtUsuario.Text;
                usuario.contrasena = txtPsw.Text;
            }
            

        }
    }
}
