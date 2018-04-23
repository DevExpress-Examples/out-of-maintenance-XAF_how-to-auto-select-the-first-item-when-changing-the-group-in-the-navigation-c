Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Win.Templates.ActionContainers

Namespace DXExample.Module.Win
	Public Class WinSelectFirstNavigationItemController
		Inherits SelectFirstNavigationItemControllerBase
		Public Sub New()
		End Sub
		Protected Overrides Function FindNavBarControl() As DevExpress.ExpressApp.Templates.IActionContainer
			For Each actionContainer As IActionContainer In Window.Template.GetContainers()
				If TypeOf actionContainer Is NavBarActionContainer Then
					Return actionContainer
				End If
			Next actionContainer
			Return Nothing
		End Function
		Protected Overrides Sub SetupNavigationControl(ByVal navigationControl As IActionContainer)
			Dim navBaeControl As NavBarActionContainer = CType(navigationControl, NavBarActionContainer)
			AddHandler navBaeControl.ActiveGroupChanged, AddressOf navBaeControl_ActiveGroupChanged
		End Sub
		Private Sub navBaeControl_ActiveGroupChanged(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarGroupEventArgs)
			SelectFirstItem((CType(e.Group, NavBarActionGroup)).Item)
		End Sub
	End Class
End Namespace
