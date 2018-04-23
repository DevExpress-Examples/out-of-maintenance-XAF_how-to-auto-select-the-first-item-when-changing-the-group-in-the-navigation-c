Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic

Imports DevExpress.ExpressApp
Imports System.Reflection
Imports DevExpress.ExpressApp.SystemModule
Imports DevExpress.ExpressApp.Model


Namespace DXExample.Module
	Public NotInheritable Partial Class DXExampleModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Overrides Sub ExtendModelInterfaces(ByVal extenders As ModelInterfaceExtenders)
			MyBase.ExtendModelInterfaces(extenders)
			extenders.Add(Of IModelRootNavigationItems, IModelRootNavigationItemsEx)()
		End Sub
	End Class
	Public Interface IModelRootNavigationItemsEx
		Property AllowSelectFirstItem() As Boolean
	End Interface
End Namespace
