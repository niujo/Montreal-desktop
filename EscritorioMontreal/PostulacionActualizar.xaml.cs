﻿using biMontreal;
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
    /// Lógica de interacción para PostulacionActualizar.xaml
    /// </summary>
    public partial class PostulacionActualizar : Window
    {
        public PostulacionActualizar()
        {
            InitializeComponent();
            lblNombre.Content = AuthUser.nombre;
        }

        private void btn_volver_Click(object sender, RoutedEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Close();
        }

        private void btn_Anterior_Click(object sender, RoutedEventArgs e)
        {
            VerPostulaciones verP = new VerPostulaciones();
            verP.Show();
            this.Close();
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}