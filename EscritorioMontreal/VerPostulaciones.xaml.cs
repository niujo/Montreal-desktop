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
        public VerPostulaciones()
        {
            InitializeComponent();
            lblNombre.Content = AuthUser.nombre;

            Postulaciones p = new Postulaciones();
            List<Object> lstPostulaciones = p.GetPostulaciones();
            // aca se  recibe
            if (lstPostulaciones == null)
            {
                lstPostulaciones = new List<Object>();
            }

            foreach (Postulaciones po in lstPostulaciones)
            {
                postulacionesPendientes.Items.Add(po);
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

        
        

       
    }
}
