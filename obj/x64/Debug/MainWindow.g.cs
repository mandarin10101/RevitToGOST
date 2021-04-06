﻿#pragma checksum "..\..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "58E29264B6C21CA89B09026427A9AAC19805ECF6C791AAB02C32FB8646A464EB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Autodesk.Revit.DB;
using GongSolutions.Wpf.DragDrop;
using GongSolutions.Wpf.DragDrop.Utilities;
using RevitToGOST;
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


namespace RevitToGOST {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Export;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TitleComboBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox TableComboBox;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StampComboBox;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox DopComboBox;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox EnumerateColumnsCheckBox;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView AvailableCategories;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView PickedCategories;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView AvailableElements;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView PickedElements;
        
        #line default
        #line hidden
        
        
        #line 217 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox GroupElemsCheckBox;
        
        #line default
        #line hidden
        
        
        #line 226 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ProgressBar ExportProgressBar;
        
        #line default
        #line hidden
        
        
        #line 237 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button huy;
        
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
            System.Uri resourceLocater = new System.Uri("/RevitToGOST;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
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
            this.Export = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\MainWindow.xaml"
            this.Export.Click += new System.Windows.RoutedEventHandler(this.Export_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TitleComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 49 "..\..\..\MainWindow.xaml"
            this.TitleComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TitleComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TableComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 61 "..\..\..\MainWindow.xaml"
            this.TableComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.TableComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.StampComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 73 "..\..\..\MainWindow.xaml"
            this.StampComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.StampComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DopComboBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 85 "..\..\..\MainWindow.xaml"
            this.DopComboBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DopComboBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EnumerateColumnsCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 94 "..\..\..\MainWindow.xaml"
            this.EnumerateColumnsCheckBox.Checked += new System.Windows.RoutedEventHandler(this.EnumerateColumnsCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 95 "..\..\..\MainWindow.xaml"
            this.EnumerateColumnsCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.EnumerateColumnsCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AvailableCategories = ((System.Windows.Controls.ListView)(target));
            return;
            case 8:
            this.PickedCategories = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            this.AvailableElements = ((System.Windows.Controls.ListView)(target));
            return;
            case 10:
            this.PickedElements = ((System.Windows.Controls.ListView)(target));
            return;
            case 11:
            this.GroupElemsCheckBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 221 "..\..\..\MainWindow.xaml"
            this.GroupElemsCheckBox.Checked += new System.Windows.RoutedEventHandler(this.GroupElemsCheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 222 "..\..\..\MainWindow.xaml"
            this.GroupElemsCheckBox.Unchecked += new System.Windows.RoutedEventHandler(this.GroupElemsCheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ExportProgressBar = ((System.Windows.Controls.ProgressBar)(target));
            return;
            case 13:
            this.huy = ((System.Windows.Controls.Button)(target));
            
            #line 237 "..\..\..\MainWindow.xaml"
            this.huy.Click += new System.Windows.RoutedEventHandler(this.huy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

