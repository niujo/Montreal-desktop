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
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();

            lblNombre.Content = AuthUser.nombre;
        }

        private void btn_usuarios_Click(object sender, RoutedEventArgs e)
        {
            VerUsuarios veru = new VerUsuarios();
            veru.Show();
            this.Close();
        }

        private void btn_cursos_Click(object sender, RoutedEventArgs e)
        {
            VerCursos veru = new VerCursos();
            veru.Show();
            this.Close();
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_postulaciones_Click(object sender, RoutedEventArgs e)
        {
            VerPostulaciones verp = new VerPostulaciones();
            verp.Show();
            this.Close();

        }

        private void btn_reg_cel_Click(object sender, RoutedEventArgs e)
        {
            RegCel verCel = new RegCel();
            verCel.Show();
            this.Close();
        }

        private void btn_reg_cem_Click(object sender, RoutedEventArgs e)
        {
            RegCem verCem = new RegCem();
            verCem.Show();
            this.Close();
        }

        private void btn_antecedentes_Click(object sender, RoutedEventArgs e)
        {
            Antecedentes verAnt = new Antecedentes();
            verAnt.Show();
            this.Close();
        }

        private void btn_certificados_Click(object sender, RoutedEventArgs e)
        {
            Certificados verCer = new Certificados();
            verCer.Show();
            this.Close();
        }
    }
}
