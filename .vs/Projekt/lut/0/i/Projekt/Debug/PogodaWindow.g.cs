﻿#pragma checksum "PogodaWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EDA2B0911E2742A5FFEE96BABA88DDEFF8D79DED"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Projekt;
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


namespace Projekt {
    
    
    /// <summary>
    /// PogodaWindow
    /// </summary>
    public partial class PogodaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "PogodaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GridDetalePogody;
        
        #line default
        #line hidden
        
        
        #line 25 "PogodaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ZapiszButton;
        
        #line default
        #line hidden
        
        
        #line 26 "PogodaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DodajButton;
        
        #line default
        #line hidden
        
        
        #line 27 "PogodaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ModyfikujButton;
        
        #line default
        #line hidden
        
        
        #line 28 "PogodaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UsunButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Projekt;component/pogodawindow.xaml", System.UriKind.Relative);
            
            #line 1 "PogodaWindow.xaml"
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
            this.GridDetalePogody = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.ZapiszButton = ((System.Windows.Controls.Button)(target));
            
            #line 25 "PogodaWindow.xaml"
            this.ZapiszButton.Click += new System.Windows.RoutedEventHandler(this.ZapiszButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.DodajButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "PogodaWindow.xaml"
            this.DodajButton.Click += new System.Windows.RoutedEventHandler(this.DodajButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ModyfikujButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "PogodaWindow.xaml"
            this.ModyfikujButton.Click += new System.Windows.RoutedEventHandler(this.ModyfikujButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.UsunButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "PogodaWindow.xaml"
            this.UsunButton.Click += new System.Windows.RoutedEventHandler(this.UsunButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

