// Updated by XamlIntelliSenseFileGenerator 12/7/2024 11:31:55 PM
#pragma checksum "..\..\..\NotesPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DBB8849D87863D77E811F9632687851945CDFAE4"
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


namespace TaskPal
{


    /// <summary>
    /// TasksWindow
    /// </summary>
    public partial class NotesWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TaskPal;V1.0.0.0;component/notespage.xaml", System.UriKind.Relative);

#line 1 "..\..\..\NotesPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:

#line 59 "..\..\..\NotesPage.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddGroup_Click);

#line default
#line hidden
                    return;
                case 2:

#line 60 "..\..\..\NotesPage.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditGroup_Click);

#line default
#line hidden
                    return;
                case 3:

#line 61 "..\..\..\NotesPage.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddTask_Click);

#line default
#line hidden
                    return;
                case 4:

#line 62 "..\..\..\NotesPage.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteGroup_Click);

#line default
#line hidden
                    return;
                case 5:

#line 63 "..\..\..\NotesPage.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteTask_Click);

#line default
#line hidden
                    return;
                case 6:

#line 64 "..\..\..\NotesPage.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackToMain_Cli);

#line default
#line hidden
                    return;
                case 7:
                    this.GroupListBox = ((System.Windows.Controls.ListBox)(target));

#line 70 "..\..\..\NotesPage.xaml"
                    this.GroupListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.GroupListBox_SelectionChanged);

#line default
#line hidden
                    return;
                case 8:
                    this.TaskListBox = ((System.Windows.Controls.ListBox)(target));
                    return;
                case 9:
                    this.TaskNameTextBox = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 10:
                    this.TaskPriorityComboBox = ((System.Windows.Controls.ComboBox)(target));
                    return;
                case 11:

#line 122 "..\..\..\NotesPage.xaml"
                    ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SaveTask_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }

        internal System.Windows.Controls.TextBox SearchBox;
        internal System.Windows.Controls.WrapPanel NotesPanel;
    }
}
