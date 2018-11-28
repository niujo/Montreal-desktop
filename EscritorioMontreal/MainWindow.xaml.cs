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
            var brush = new SolidColorBrush(Color.FromRgb(92, 184, 92));
            btnIngresar.Background = brush;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario();
                usuario.usuario = txtUser.Text;
                usuario.contrasena = txtPASS.Password;

                //UTILS uti = new UTILS();
                string token = UTILS.Autenticar(usuario);
                if (token == null)
                {
                    lblError.Content = " Usuario y/o contraseña incorrecta";
                }
                else
                {
                    bool success = UTILS.decodeToken(token);

                    if (success && AuthUser.rol.Equals("Administrador"))
                    {
                        AuthUser.token = token;
                        Menu menu = new Menu();
                        menu.Show();
                        this.Close();
                    }
                    else
                    {
                        lblError.Content = "Acceso denegado.";
                        AuthUser.id = null;
                        AuthUser.nombre = null;
                        AuthUser.rol = null;
                        AuthUser.token = null;
                    }
                }
            } catch (Exception)
            {
                // do nothing
            }
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
