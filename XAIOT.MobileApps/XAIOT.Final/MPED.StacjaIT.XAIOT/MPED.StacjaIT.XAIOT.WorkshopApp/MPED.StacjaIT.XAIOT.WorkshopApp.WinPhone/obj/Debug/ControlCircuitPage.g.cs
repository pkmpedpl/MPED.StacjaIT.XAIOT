﻿

#pragma checksum "C:\GitHub\MPED.StacjaIT.XAIOT\XAIOT.MobileApps\XAIOT.Final\MPED.StacjaIT.XAIOT\MPED.StacjaIT.XAIOT.WorkshopApp\MPED.StacjaIT.XAIOT.WorkshopApp.WinPhone\ControlCircuitPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8FF5C5222493704FE324E0FD9D49F0A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MPED.StacjaIT.XAIOT.WorkshopApp.WinPhone
{
    partial class ControlCircuitPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 96 "..\..\ControlCircuitPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.RefreshButton_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 47 "..\..\ControlCircuitPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.TurnOnButton_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 48 "..\..\ControlCircuitPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.TurnOffButton_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 22 "..\..\ControlCircuitPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.BackButton_Tapped;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


