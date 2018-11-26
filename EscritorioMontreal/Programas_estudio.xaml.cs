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
    /// Lógica de interacción para Programas_estudio.xaml
    /// </summary>
    public partial class Programas_estudio : Window
    {
        public Programas_estudio()
        {
            InitializeComponent();
            lblNombre.Content = AuthUser.nombre;

            ProgramaEstudio p = new ProgramaEstudio();
            List<Object> lstProgramas = p.GetProgramasEstudiosCEL();
            // aca se  recibe
            if (lstProgramas == null)
            {
                lstProgramas = new List<Object>();
            }

            foreach (ProgramaEstudio pe in lstProgramas)
            {
                lstPendientes.Items.Add(pe);
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

        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {
            ProgramasAgregar proAgr = new ProgramasAgregar();
            proAgr.Show();
            this.Close();
        }

        private void btn_borrar_Click(object sender, RoutedEventArgs e)
        {
                    }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            ProgramasActualizar proAc = new ProgramasActualizar();
            proAc.Show();
            this.Close();
        }
    }
}
