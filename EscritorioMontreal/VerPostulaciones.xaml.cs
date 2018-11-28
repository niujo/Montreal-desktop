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
    /// Lógica de interacción para VerPostulaciones.xaml
    /// </summary>
    public partial class VerPostulaciones : Window
    {
        Postulaciones postulacion = null;

        public VerPostulaciones()
        {
            try
            {
                InitializeComponent();
                lblNombre.Content = AuthUser.nombre;

                Postulaciones p = new Postulaciones();
                List<Object> lstPostulaciones = p.GetPostulaciones();
                // aca se  recibe
                if (lstPostulaciones == null)
                {
                    lstPostulaciones = new List<Object>();
                    lstPostulaciones.Add(new List<Object>());
                    lstPostulaciones.Add(new List<Object>());
                }
                List<Object> vigentes = (List<Object>)lstPostulaciones[0];
                List<Object> finalizados = (List<Object>)lstPostulaciones[1];

                foreach (Postulaciones v in vigentes)
                {
                    postulacionesPendientes.Items.Add(v);
                }

                foreach (Postulaciones f in finalizados)
                {
                    postulacionesRespondidas.Items.Add(f);
                }
            }
            catch (Exception)
            {
                Menu menu = new Menu();
                menu.Show();
                this.Close();
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

        private void PostulacionesPendientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                postulacion = (Postulaciones)postulacionesPendientes.SelectedItem;
            }
            catch (Exception)
            {
                postulacion = null;
            }
        }

        private void Btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (postulacion != null)
                {
                    postulacion.estado = "A";
                    postulacion.fech_respuesta = DateTime.UtcNow.Date;
                    string id_postulacion = postulacion.id_postulacion.ToString();
                    Postulaciones post_aux = postulacion;
                    List<Object> post = UTILS.PUT("private/postulacion/" + id_postulacion, "postulacion", AuthUser.token, postulacion.GetType(), postulacion);
                    if (post != null && post.Count > 0)
                    {
                        Postulaciones p = (Postulaciones)post[0];

                        postulacionesPendientes.Items.Remove(postulacion);
                        postulacionesPendientes.Items.Refresh();
                        postulacionesRespondidas.Items.Add(post_aux);
                        postulacionesRespondidas.Items.Refresh();

                        Inscripcion ins = new Inscripcion();
                        ins.id_alumno = p.id_alumno;
                        ins.id_programa = p.id_programa;
                        UTILS.POST("private/inscripcion", "inscripcion", AuthUser.token, ins.GetType(), ins);
                        Mail correo = new Mail();

                        correo.envioCorreo(p.id_alumno.ToString(), p.estado, post_aux.programaEstudio.nomb_programa, p.fech_respuesta);
                    }
                }
            }
            catch (Exception)
            {
                // do nothing
            }
        }

        private void Btn_rechazar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (postulacion != null)
                {
                    postulacion.estado = "R";
                    postulacion.fech_respuesta = DateTime.UtcNow.Date;
                    string id_postulacion = postulacion.id_postulacion.ToString();
                    Postulaciones post_aux = postulacion;
                    List<Object> post = UTILS.PUT("private/postulacion/" + id_postulacion, "postulacion", AuthUser.token, postulacion.GetType(), postulacion);
                    if (post != null && post.Count > 0)
                    {
                        Postulaciones p = (Postulaciones)post[0];

                        postulacionesPendientes.Items.Remove(postulacion);
                        postulacionesPendientes.Items.Refresh();
                        postulacionesRespondidas.Items.Add(post_aux);
                        postulacionesRespondidas.Items.Refresh();
                        Mail correo = new Mail();

                        correo.envioCorreo(p.id_alumno.ToString(), p.estado, post_aux.programaEstudio.nomb_programa, p.fech_respuesta);
                    }
                }
            }
            catch (Exception)
            {
                // do nothing
            }
        }
    }
}
