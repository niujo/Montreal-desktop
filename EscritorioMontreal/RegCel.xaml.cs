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
using biMontreal;

namespace EscritorioMontreal
{
    /// <summary>
    /// Lógica de interacción para RegCel.xaml
    /// </summary>
    public partial class RegCel : Window
    {
        public RegCel()
        {
            InitializeComponent();

            Ciudad p = new Ciudad();
            List<Object> lstCiudad = p.GetCiudades();
            if (lstCiudad == null)
            {
                lstCiudad = new List<Object>();
            }

            cbCiudad.SelectedValuePath = "Key";
            cbCiudad.DisplayMemberPath = "Value";
            foreach (Ciudad pe in lstCiudad)
            {
                cbCiudad.Items.Add(new KeyValuePair<int?, string>(pe.id_ciudad, pe.nombre));
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

            try
            {
                if (txtPsw.Password.Equals(txtRepPsw.Password))
                {
                    /*
                     * declarando
                     */
                    Usuario usuario = new Usuario();
                    CEL cel = new CEL();
                    Direccion dir = new Direccion();
                    Contacto cont = new Contacto();
                    Persona per = new Persona();
                    Rol rol = new Rol();
                    /*
                     * variables bool para  saber si existen en la BD, ya que son unique en la BD
                     */
                    bool usr = usuario.usuarioExists(txtUsuario.Text);
                    bool rut = per.rutExists(txtRut.Text);
                    /*
                     * 
                     */
                    if (!usr && !rut)
                    {
                        List<object> lstRoles = rol.getRoles();
                        if (lstRoles == null)
                        {
                            lstRoles = new List<object>();
                        }
                        for (int i = 0; i < lstRoles.Count; i++)
                        {
                            rol = (Rol)lstRoles[i];
                            if (rol.desc_rol.Equals("CEL"))
                            {
                                break;
                            }
                        }
                        usuario.id_rol = rol.id_rol;
                        usuario.usuario = txtUsuario.Text;
                        usuario.contrasena = txtPsw.Password;

                        usuario = usuario.guardarUsuario(usuario);
                        if (usuario != null)
                        {
                            string id_usuario = usuario.id_usuario.ToString();
                            dir.id_ciudad = (int)cbCiudad.SelectedValue;
                            dir.calle = txtCalle.Text;
                            dir.numeracion = txtNumeracion.Text;
                            dir.departamento = txtDepartamento.Text;
                            dir = dir.guardarDireccion(dir);

                            if (dir != null)
                            {
                                per.id_direccion = dir.id_direccion;
                                per.id_usuario = usuario.id_usuario;
                                per.rut = txtRut.Text;
                                per.nombre = txtNombreAdm.Text;
                                per.app_paterno = txtApePa.Text;
                                per.app_materno = txtApeMa.Text;
                                per.fech_nacimiento = (DateTime)fechNac.SelectedDate;
                                per = per.guardarPersona(per);

                                if (per != null)
                                {
                                    cont.id_persona = per.id_persona;
                                    cont.tipo_contacto = "Correo";
                                    cont.desc_contacto = txtCorreo.Text;

                                    cont = cont.guardarContacto(cont);

                                    if (cont == null)
                                    {
                                        usuario.deleteUsuario(id_usuario);
                                    }
                                    else
                                    {
                                        cel.id_usuario = usuario.id_usuario;
                                        cel.nom_centro = txtNombre.Text;

                                        cel = cel.guardarCEL(cel);

                                        if (cel == null)
                                        {
                                            usuario.deleteUsuario(id_usuario);
                                        }
                                    }



                                }
                                else
                                {
                                    usuario.deleteUsuario(id_usuario);
                                }

                                if (usuario != null && lstRoles.Count > 0)
                                {
                                    RegCel regcel = new RegCel();
                                    regcel.Show();
                                    this.Close();
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                // nada
            }
        }
    }
}
