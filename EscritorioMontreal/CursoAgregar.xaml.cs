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
    /// Lógica de interacción para CursoAgregar.xaml
    /// </summary>
    public partial class CursoAgregar : Window
    {
        public CursoAgregar()
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

        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Anterior_Click(object sender, RoutedEventArgs e)
        {
            VerCursos cursos = new VerCursos();
            cursos.Show();
            this.Close();
        }
    }
}
