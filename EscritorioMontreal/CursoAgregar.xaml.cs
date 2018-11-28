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

            ProgramaEstudio p = new ProgramaEstudio();
            List<Object> lstProgramas = p.GetProgramasEstudiosCEL();
            if (lstProgramas == null)
            {
                lstProgramas = new List<Object>();
                lstProgramas.Add(new List<Object>());
                lstProgramas.Add(new List<Object>());
            }
            List<Object> vigentes = (List<Object>)lstProgramas[0];

            cbPrograma.SelectedValuePath = "Key";
            cbPrograma.DisplayMemberPath = "Value";
            foreach (ProgramaEstudio pe in vigentes)
            {
                cbPrograma.Items.Add(new KeyValuePair<int?, string>(pe.id_programa, pe.nomb_programa));
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
            Cursos curso = new Cursos();
            try
            {
                curso.id_programa = (int)cbPrograma.SelectedValue;
                curso.desc_curso = txtDesc.Text;
                curso.cupos = int.Parse(txtCupos.Text);

                List<Object> c = UTILS.POST("private/curso", "curso", AuthUser.token, curso.GetType(),curso);
                if (c != null && c.Count > 0)
                {
                    VerCursos cursos = new VerCursos();
                    cursos.Show();
                    this.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
            

           

        }

        private void btn_Anterior_Click(object sender, RoutedEventArgs e)
        {
            VerCursos cursos = new VerCursos();
            cursos.Show();
            this.Close();
        }

        
    }
}
