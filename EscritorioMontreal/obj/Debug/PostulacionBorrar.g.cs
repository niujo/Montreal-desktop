﻿#pragma checksum "..\..\PostulacionBorrar.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "614DC8E9AF0A2EAEE0A2E293DF3F1276EA3F0194"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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
    /// PostulacionBorrar
    /// </summary>
    public partial class PostulacionBorrar : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\PostulacionBorrar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_salir;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\PostulacionBorrar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_volver;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\PostulacionBorrar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNombre;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\PostulacionBorrar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Borrar;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\PostulacionBorrar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtIDborrar;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\PostulacionBorrar.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Anterior;
        
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
            System.Uri resourceLocater = new System.Uri("/EscritorioMontreal;component/postulacionborrar.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\PostulacionBorrar.xaml"
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
            this.btn_salir = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\PostulacionBorrar.xaml"
            this.btn_salir.Click += new System.Windows.RoutedEventHandler(this.btn_salir_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_volver = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\PostulacionBorrar.xaml"
            this.btn_volver.Click += new System.Windows.RoutedEventHandler(this.btn_volver_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.lblNombre = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.btn_Borrar = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\PostulacionBorrar.xaml"
            this.btn_Borrar.Click += new System.Windows.RoutedEventHandler(this.btn_Borrar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtIDborrar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btn_Anterior = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\PostulacionBorrar.xaml"
            this.btn_Anterior.Click += new System.Windows.RoutedEventHandler(this.btn_Anterior_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

