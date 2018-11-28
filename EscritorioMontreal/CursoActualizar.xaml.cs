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
    /// Lógica de interacción para CursoActualizar.xaml
    /// </summary>
    public partial class CursoActualizar : Window
    {
        private Cursos cur = null;
        public CursoActualizar(Cursos curso)
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
            foreach(ProgramaEstudio pe in vigentes)
            {
                cbPrograma.Items.Add(new KeyValuePair<int?, string>(pe.id_programa, pe.nomb_programa));
            }

            if (curso != null)
            {
                txtCupo.Text = curso.cupos.ToString();
                txtDesc.Text = curso.desc_curso;
                cbPrograma.SelectedValue = curso.id_programa;
                cur = curso;
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
            VerCursos cursos = new VerCursos();
            cursos.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool valido = validaciones();
                if (cur != null && valido)
                {
                    cur.desc_curso = txtDesc.Text;
                    cur.cupos = int.Parse(txtCupo.Text);
                    cur.id_programa = (int)cbPrograma.SelectedValue;
                    bool valid = cur.actualizarCurso(cur);

                    if (valid)
                    {
                        VerCursos cursos = new VerCursos();
                        cursos.Show();
                        this.Close();
                    }
                    else
                    {
                        lblValid.Content = "Ha ocurrido un error";
                    }
                }
            } catch (Exception)
            {
                // nada
            }
        }

        private bool validaciones()
        {
            try
            {
                int value;
                bool desc = !(txtDesc.Text == null || txtDesc.Text.Equals(String.Empty));
                bool cupos = !(txtCupo.Text == null || txtCupo.Text.Equals(String.Empty) || !int.TryParse(txtCupo.Text, out value));

                lblDesc.Content = desc ? "" : "Este campo es obligatorio";
                lblCupos.Content = cupos ? "" : "Este campo debe ser numerico";

                bool valido = true && desc && cupos;
                return valido;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
