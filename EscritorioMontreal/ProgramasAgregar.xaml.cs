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
    /// Lógica de interacción para ProgramasAgregar.xaml
    /// </summary>
    public partial class ProgramasAgregar : Window
    {
        public ProgramasAgregar()
        {
            InitializeComponent();
            lblNombre.Content = AuthUser.nombre;


            CEM p = new CEM();
            List<Object> lstCentro = p.getCEM();
            if (lstCentro == null)
            {
                lstCentro = new List<Object>();
            }

            cbCentro.SelectedValuePath = "Key";
            cbCentro.DisplayMemberPath = "Value";
            foreach (CEM pe in lstCentro)
            {
                cbCentro.Items.Add(new KeyValuePair<int?, string>(pe.id_cem, pe.nom_centro));
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
            Programas_estudio prog = new Programas_estudio();
            prog.Show();
            this.Close();
        }

        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
