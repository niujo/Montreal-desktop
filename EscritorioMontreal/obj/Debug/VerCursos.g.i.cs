﻿#pragma checksum "..\..\VerCursos.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4B3B773BDEA1E2AD890AD6A60E903A2F4D23095E"
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
    /// VerCursos
    /// </summary>
    public partial class VerCursos : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\VerCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listCursos;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\VerCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Agregar;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\VerCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_borrar;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\VerCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_actualizar;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\VerCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_salir;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\VerCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_volver;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\VerCursos.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNombre;
        
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
            System.Uri resourceLocater = new System.Uri("/EscritorioMontreal;component/vercursos.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\VerCursos.xaml"
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
            this.listCursos = ((System.Windows.Controls.ListBox)(target));
            
            #line 10 "..\..\VerCursos.xaml"
            this.listCursos.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listCursos_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_Agregar = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\VerCursos.xaml"
            this.btn_Agregar.Click += new System.Windows.RoutedEventHandler(this.btn_Agregar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_borrar = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\VerCursos.xaml"
            this.btn_borrar.Click += new System.Windows.RoutedEventHandler(this.btn_borrar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_actualizar = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\VerCursos.xaml"
            this.btn_actualizar.Click += new System.Windows.RoutedEventHandler(this.btn_actualizar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_salir = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\VerCursos.xaml"
            this.btn_salir.Click += new System.Windows.RoutedEventHandler(this.btn_salir_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btn_volver = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\VerCursos.xaml"
            this.btn_volver.Click += new System.Windows.RoutedEventHandler(this.btn_volver_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.lblNombre = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

