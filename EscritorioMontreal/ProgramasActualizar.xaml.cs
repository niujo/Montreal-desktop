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
        private ProgramaEstudio prog = null;
        public ProgramasActualizar(ProgramaEstudio programa)
        {
            InitializeComponent();
            lblNombre.Content = AuthUser.nombre;
            if (programa != null)
            {
                txtNombre.Text = programa.nomb_programa;
                txtDesc.Text = programa.desc_programa;
                txtMaxA.Text = programa.cant_max_alumnos.ToString();
                txtMinA.Text = programa.cant_min_alumnos.ToString();
                txtCEL.Text = programa.cel.nom_centro;
                dpFechInicio.SelectedDate = programa.fech_inicio;
                dpFechTermino.SelectedDate = programa.fech_termino;

                prog = programa;
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
            try
            {
                if (prog != null)
                {
                    prog.nomb_programa = txtNombre.Text;
                    prog.desc_programa = txtDesc.Text;
                    prog.cant_max_alumnos = int.Parse(txtMaxA.Text);
                    prog.cant_min_alumnos = int.Parse(txtMinA.Text);
                    prog.fech_inicio = (DateTime)dpFechInicio.SelectedDate;
                    prog.fech_termino = (DateTime)dpFechTermino.SelectedDate;

                    bool valid = prog.actualizarPrograma(prog);

                    if (valid)
                    {
                        Programas_estudio prog = new Programas_estudio();
                        prog.Show();
                        this.Close();
                    }
                    else
                    {
                        lblError.Content = "Ha ocurrido un error";
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
