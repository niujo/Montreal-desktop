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
using System.Windows.Navigation;
using System.Windows.Shapes;
using biMontreal;


namespace EscritorioMontreal
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario.usuario = txtUser.Text;
            usuario.contrasena = txtPASS.Password;

            UTILS uti = new UTILS();
            string token = uti.Autenticar(usuario);
            Console.WriteLine(token);
            if (token == null)
            {
                lblError.Content = " Usuario y/o contraseña incorrecta";
            }
            else
            {
                bool success = uti.decodeToken(token);

                if (success)
                {
                    Menu menu = new Menu();
                    menu.Show();
                    this.Close();
                }
            }
        }
    }
}
