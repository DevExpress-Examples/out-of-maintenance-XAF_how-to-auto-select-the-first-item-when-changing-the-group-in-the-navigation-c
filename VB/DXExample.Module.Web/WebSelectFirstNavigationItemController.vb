Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Web.Templates.ActionContainers

Namespace DXExample.Module.Web
	Public Class WebSelectFirstNavigationItemController
		Inherits SelectFirstNavigationItemControllerBase
		Public Sub New()
		End Sub
		Protected Overrides Function FindNavBarControl() As DevExpress.ExpressApp.Templates.IActionContainer
			If Window.Template IsNot Nothing Then
				For Each actionContainer As IActionContainer In Window.Template.GetContainers()
					If TypeOf actionContainer Is NavigationTabsActionContainer OrElse TypeOf actionContainer Is NavigationBarActionContainer Then
						Return actionContainer
					End If
				Next actionContainer
			End If
			Return Nothing
		End Function
		Protected Overrides Sub SetupNavigationControl(ByVal navigationControl As IActionContainer)
			If TypeOf navigationControl Is NavigationTabsActionContainer Then
				Dim navTabsControl As NavigationTabsActionContainer = CType(navigationControl, NavigationTabsActionContainer)
				AddHandler navTabsControl.ActiveTabChanged, AddressOf navTabsControl_ActiveTabChanged
				navTabsControl.AutoPostBack = True
			ElseIf TypeOf navigationControl Is NavigationBarActionContainer Then
				Dim navBarControl As NavigationBarActionContainer = CType(navigationControl, NavigationBarActionContainer)
				AddHandler navBarControl.ExpandedChanged, AddressOf navBarControl_ExpandedChanged
				navBarControl.AutoPostBack = True
			End If
		End Sub
		Private Sub navTabsControl_ActiveTabChanged(ByVal source As Object, ByVal e As DevExpress.Web.ASPxTabControl.TabControlEventArgs)
			SelectFirstItem(e.Tab.Index)
		End Sub
		Private Sub navBarControl_ExpandedChanged(ByVal source As Object, ByVal e As DevExpress.Web.ASPxNavBar.NavBarGroupEventArgs)
			SelectFirstItem(e.Group.Index)
		End Sub
	End Class
End Namespace
