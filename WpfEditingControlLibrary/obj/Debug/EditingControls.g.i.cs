﻿#pragma checksum "..\..\EditingControls.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DD35E977AD42D3F387C0E112AF479945ED7E8B19"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WpfEditingControlLibrary;


namespace WpfEditingControlLibrary {
    
    
    /// <summary>
    /// EditingControls
    /// </summary>
    public partial class EditingControls : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 67 "..\..\EditingControls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid SelectcontrolsGrid;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\EditingControls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSelect;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\EditingControls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Clear;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\EditingControls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnStrokeDel;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\EditingControls.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonEraser;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfEditingControlLibrary;component/editingcontrols.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EditingControls.xaml"
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
            this.SelectcontrolsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.ButtonSelect = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\EditingControls.xaml"
            this.ButtonSelect.Click += new System.Windows.RoutedEventHandler(this.ButtonSelect_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Clear = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.BtnStrokeDel = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\EditingControls.xaml"
            this.BtnStrokeDel.Click += new System.Windows.RoutedEventHandler(this.ButtonSelect_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ButtonEraser = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\EditingControls.xaml"
            this.ButtonEraser.Click += new System.Windows.RoutedEventHandler(this.ButtonEraser_Click_1);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
