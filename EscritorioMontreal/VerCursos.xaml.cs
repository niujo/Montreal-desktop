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
    /// Lógica de interacción para VerCursos.xaml
    /// </summary>
    public partial class VerCursos : Window
    {
        private Cursos curso= null;
        
        public VerCursos()
        {
            InitializeComponent();
            lblNombre.Content = AuthUser.nombre;

            Cursos c = new Cursos();
            List<Object> lstCursoss = c.getCursos();
            // aca se  recibe
            if (lstCursoss == null)
            {
                lstCursoss = new List<Object>();
            }

            foreach (Cursos pe in lstCursoss)
            {
                listCursos.Items.Add(pe);
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
            CursoAgregar cur = new CursoAgregar();
            cur.Show();
            this.Close();
        }

        private void btn_borrar_Click(object sender, RoutedEventArgs e)
        {
            if (curso!=null)
            {
                string id = curso.id_curso.ToString();
                UTILS.DELETE("private/curso/" + id, "curso", AuthUser.token, curso.GetType());
                listCursos.Items.Remove(curso);
                listCursos.Items.Refresh();
            }
        }

        private void btn_actualizar_Click(object sender, RoutedEventArgs e)
        {
            CursoActualizar act = new CursoActualizar();
            act.Show();
            this.Close();
        }

        private void listCursos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                curso = (Cursos)listCursos.SelectedItem;
                
            }
            catch (Exception)
            {

                curso = null;
            }

            
        }
    }
}
