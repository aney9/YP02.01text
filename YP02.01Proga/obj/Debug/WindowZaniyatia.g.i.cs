﻿#pragma checksum "..\..\WindowZaniyatia.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "25E1CFECA141732D039C081A139301BEBAB634F8572312D5921B6C9D74D1C017"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using YP02._01Proga;


namespace YP02._01Proga {
    
    
    /// <summary>
    /// WindowZaniyatia
    /// </summary>
    public partial class WindowZaniyatia : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 68 "..\..\WindowZaniyatia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\WindowZaniyatia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\WindowZaniyatia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker data;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\WindowZaniyatia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox chas;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\WindowZaniyatia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox uchast;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\WindowZaniyatia.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox vybor;
        
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
            System.Uri resourceLocater = new System.Uri("/YP02.01Proga;component/windowzaniyatia.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowZaniyatia.xaml"
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
            
            #line 61 "..\..\WindowZaniyatia.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.exit_click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.dg = ((System.Windows.Controls.DataGrid)(target));
            
            #line 69 "..\..\WindowZaniyatia.xaml"
            this.dg.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dg_select);
            
            #line default
            #line hidden
            return;
            case 3:
            this.name = ((System.Windows.Controls.TextBox)(target));
            
            #line 100 "..\..\WindowZaniyatia.xaml"
            this.name.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Proverka);
            
            #line default
            #line hidden
            return;
            case 4:
            this.data = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.chas = ((System.Windows.Controls.TextBox)(target));
            
            #line 112 "..\..\WindowZaniyatia.xaml"
            this.chas.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.proverkaa_input);
            
            #line default
            #line hidden
            
            #line 112 "..\..\WindowZaniyatia.xaml"
            this.chas.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.proverkaaa_text);
            
            #line default
            #line hidden
            return;
            case 6:
            this.uchast = ((System.Windows.Controls.TextBox)(target));
            
            #line 118 "..\..\WindowZaniyatia.xaml"
            this.uchast.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.proverkaa_input);
            
            #line default
            #line hidden
            
            #line 118 "..\..\WindowZaniyatia.xaml"
            this.uchast.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.proverka1_text);
            
            #line default
            #line hidden
            return;
            case 7:
            this.vybor = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            
            #line 132 "..\..\WindowZaniyatia.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.add_click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 136 "..\..\WindowZaniyatia.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.edit_click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 140 "..\..\WindowZaniyatia.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.delete_click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 144 "..\..\WindowZaniyatia.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.remove_click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

