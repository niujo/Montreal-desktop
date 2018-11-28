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
        private ProgramaEstudio programa = null;
        public Programas_estudio()
        {
            try
            {
                InitializeComponent();
                lblNombre.Content = AuthUser.nombre;

                ProgramaEstudio p = new ProgramaEstudio();
                List<Object> lstProgramas = p.GetProgramasEstudiosCEL();
                // aca se  recibe
                if (lstProgramas == null)
                {
                    lstProgramas = new List<Object>();
                    lstProgramas.Add(new List<Object>());
                    lstProgramas.Add(new List<Object>());
                }
                List<Object> vigentes = (List<Object>)lstProgramas[0];
                List<Object> finalizados = (List<Object>)lstProgramas[1];

                foreach (ProgramaEstudio v in vigentes)
                {
                    lstVigentes.Items.Add(v);
                }

                foreach (ProgramaEstudio f in finalizados)
                {
                    lstFinalizados.Items.Add(f);
                }
            }
            catch (Exception)
            {
                Menu menu = new Menu();
                menu.Show();
                this.Close();
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

       

        private void btn_borrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (programa != null)
                {
                    string id = programa.id_programa.ToString();
                    UTILS.DELETE("private/programa/" + id, "programa", AuthUser.token, programa.GetType());
                    lstVigentes.Items.Remove(programa);
                    lstVigentes.Items.Refresh();
                }
            } catch (Exception)
            {
                // do nothing
            }
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            if (programa != null)
            {
                ProgramasActualizar proAc = new ProgramasActualizar(programa);
                proAc.Show();
                this.Close();
            }
        }

        private void lstPendientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lstVigentes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                programa = (ProgramaEstudio)lstVigentes.SelectedItem;

            }
            catch (Exception)
            {

                programa = null;
            }
        }
    }
}
