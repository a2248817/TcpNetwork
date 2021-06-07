﻿#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D85F1D8E081DC1170BFD700A5AC207C1E3FACF7CC5807D05EA90CCBA68ECAEC2"
//------------------------------------------------------------------------------
// <auto-generated>
//     這段程式碼是由工具產生的。
//     執行階段版本:4.0.30319.42000
//
//     對這個檔案所做的變更可能會造成錯誤的行為，而且如果重新產生程式碼，
//     變更將會遺失。
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
using UI;
using UI.Properties;


namespace UI {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ServerStart;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ServerStop;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RemoteAddress;
        
        #line default
        #line hidden
        
        
        #line 121 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RemotePort;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoteStart;
        
        #line default
        #line hidden
        
        
        #line 147 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RemoteStop;
        
        #line default
        #line hidden
        
        
        #line 166 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView MSG;
        
        #line default
        #line hidden
        
        
        #line 221 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView RemoteConnections;
        
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
            System.Uri resourceLocater = new System.Uri("/UI;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            
            #line 14 "..\..\MainWindow.xaml"
            ((UI.MainWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ServerStart = ((System.Windows.Controls.Button)(target));
            
            #line 67 "..\..\MainWindow.xaml"
            this.ServerStart.Click += new System.Windows.RoutedEventHandler(this.ServerStart_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ServerStop = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\MainWindow.xaml"
            this.ServerStop.Click += new System.Windows.RoutedEventHandler(this.ServerStop_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.RemoteAddress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.RemotePort = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.RemoteStart = ((System.Windows.Controls.Button)(target));
            
            #line 138 "..\..\MainWindow.xaml"
            this.RemoteStart.Click += new System.Windows.RoutedEventHandler(this.RemoteStart_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.RemoteStop = ((System.Windows.Controls.Button)(target));
            
            #line 150 "..\..\MainWindow.xaml"
            this.RemoteStop.Click += new System.Windows.RoutedEventHandler(this.RemoteStop_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MSG = ((System.Windows.Controls.ListView)(target));
            return;
            case 9:
            
            #line 174 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.GridViewColumnHeader_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 181 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.GridViewColumnHeader_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 188 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.GridViewColumnHeader)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.GridViewColumnHeader_SizeChanged);
            
            #line default
            #line hidden
            return;
            case 12:
            this.RemoteConnections = ((System.Windows.Controls.ListView)(target));
            
            #line 223 "..\..\MainWindow.xaml"
            this.RemoteConnections.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RemoteConnections_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 243 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

