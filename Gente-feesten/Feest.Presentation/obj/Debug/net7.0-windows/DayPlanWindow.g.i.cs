﻿#pragma checksum "..\..\..\DayplanWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "66D7B5985CF3B90862DFE8C638604BDA442B1380"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Feest.Presentation;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace Feest.Presentation {
    
    
    /// <summary>
    /// DayplanWindow
    /// </summary>
    public partial class DayplanWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\DayplanWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label UserDetails;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\DayplanWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView Eventslist;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\DayplanWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchEventTextBox;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\DayplanWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView SearchEventList;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\DayplanWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EventInfoTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Feest.Presentation;V1.0.0.0;component/dayplanwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DayplanWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UserDetails = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.Eventslist = ((System.Windows.Controls.ListView)(target));
            
            #line 26 "..\..\..\DayplanWindow.xaml"
            this.Eventslist.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Eventslist_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SearchEventTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\..\DayplanWindow.xaml"
            this.SearchEventTextBox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchEventTextBox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SearchEventList = ((System.Windows.Controls.ListView)(target));
            
            #line 38 "..\..\..\DayplanWindow.xaml"
            this.SearchEventList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.SearchEventLis_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EventInfoTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

