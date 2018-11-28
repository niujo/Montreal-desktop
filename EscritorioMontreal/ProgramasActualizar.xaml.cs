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
    /// Lógica de interacción para ProgramasActualizar.xaml
    /// </summary>
    public partial class ProgramasActualizar : Window
    {
        public ProgramasActualizar()
        {
            InitializeComponent();
            lblNombre.Content = AuthUser.nombre;
            cbCentro.SelectedIndex = 0;
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
            Programas_estudio prog = new Programas_estudio();
            prog.Show();
            this.Close();
        }

        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {

        }

        private bool validaciones()
        {
            try
            {
                int value;
                bool nombre = !(txtNombre.Text == null || txtNombre.Text.Equals(String.Empty));
                bool descripcion = !(txtDesc.Text == null || txtDesc.Text.Equals(String.Empty));
                bool numMin = !(txtMinA.Text == null || txtMinA.Text.Equals(String.Empty) || !int.TryParse(txtMinA.Text, out value));
                bool numMax = !(txtMaxA.Text == null || txtMaxA.Text.Equals(String.Empty) || !int.TryParse(txtMaxA.Text, out value));

                lblNombrePost.Content = nombre ? "" : "*";
                lblDescripcion.Content = descripcion ? "" : "*";
                lblMinNum.Content = numMin ? "" : "*";
                lblMaxNum.Content = numMax ? "" : "*";

                bool valido = true && nombre && descripcion && numMin && numMax ;
                return valido;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
