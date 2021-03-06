﻿using System;
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
            try
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

                cbCiudad.SelectedIndex = 0;
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

        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {
            bool validar = validaciones();

            try
            {
                if (validar && txtPsw.Password.Equals(txtRepPsw.Password))
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
                                        } else
                                        {
                                            RegCel regcel = new RegCel();
                                            regcel.Show();
                                            this.Close();
                                        }
                                    }
                                }
                                else
                                {
                                    usuario.deleteUsuario(id_usuario);
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

        private bool validaciones()
        {
            try
            {
                Persona per = new Persona();
                //int value;
                bool usuario = !(txtUsuario.Text == null || txtUsuario.Text.Equals(String.Empty));
                bool Pass = !(txtPsw.Password == null || txtPsw.Password.Equals(String.Empty));
                bool rePass = !(txtRepPsw.Password == null || txtRepPsw.Password.Equals(String.Empty) ||!txtPsw.Password.Equals(txtRepPsw));
                bool nomAD = !(txtNombreAdm.Text == null || txtNombreAdm.Text.Equals(String.Empty));
                bool apeP = !(txtApePa.Text == null || txtApePa.Text.Equals(String.Empty));
                bool apeM = !(txtApeMa.Text == null || txtApeMa.Text.Equals(String.Empty));
                bool rut = !(txtRut.Text == null || txtRut.Text.Equals(String.Empty));
                bool f_nac = (fechNac.SelectedDate != null && per.validaMayorEdad((DateTime)fechNac.SelectedDate));
                bool correo = !(txtCorreo.Text == null || txtCorreo.Text.Equals(String.Empty));
                bool nombre = !(txtNombre.Text == null || txtNombre.Text.Equals(String.Empty));
                bool calle = !(txtCalle.Text == null || txtCalle.Text.Equals(String.Empty));
                bool numeracion = !(txtNumeracion.Text == null || txtNumeracion.Text.Equals(String.Empty));

                lblUsuario.Content = usuario ? "" : "*";
                lblPASS.Content = Pass ? "" : "*";
                lblRePAS.Content = rePass ? "" : "*";
                lblNom.Content = nomAD ? "" : "*";
                lblApP.Content = apeP ? "" : "*";
                lblApM.Content = apeM ? "" : "*";
                lblRut.Content = rut ? "" : "*";
                lblCorreo.Content = correo ? "" : "*";
                lblNombCen.Content = nombre ? "" : "*";
                lblCalle.Content = calle ? "" : "*";
                lblNumeracion.Content = numeracion ? "" : "*";
                lblFecNac.Content = f_nac ? "" : "*";

                
                bool valido = true && usuario && Pass && rePass && nomAD && apeP && apeM && rut && correo && nombre && calle && numeracion && f_nac;
                return valido;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
