﻿#pragma checksum "..\..\Menu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "228FA13F172290C3DDD9DB183F4653F1C25F50CE"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using EscritorioMontreal;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace EscritorioMontreal {
    
    
    /// <summary>
    /// Menu
    /// </summary>
    public partial class Menu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_usuarios;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cursos;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_postulaciones;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_reg_cel;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_reg_cem;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNombre;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_salir;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Programas;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EscritorioMontreal;component/menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Menu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btn_usuarios = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\Menu.xaml"
            this.btn_usuarios.Click += new System.Windows.RoutedEventHandler(this.btn_usuarios_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_cursos = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\Menu.xaml"
            this.btn_cursos.Click += new System.Windows.RoutedEventHandler(this.btn_cursos_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_postulaciones = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Menu.xaml"
            this.btn_postulaciones.Click += new System.Windows.RoutedEventHandler(this.btn_postulaciones_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_reg_cel = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Menu.xaml"
            this.btn_reg_cel.Click += new System.Windows.RoutedEventHandler(this.btn_reg_cel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_reg_cem = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\Menu.xaml"
            this.btn_reg_cem.Click += new System.Windows.RoutedEventHandler(this.btn_reg_cem_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblNombre = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btn_salir = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\Menu.xaml"
            this.btn_salir.Click += new System.Windows.RoutedEventHandler(this.btn_salir_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btn_Programas = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\Menu.xaml"
            this.btn_Programas.Click += new System.Windows.RoutedEventHandler(this.btn_Programas_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

