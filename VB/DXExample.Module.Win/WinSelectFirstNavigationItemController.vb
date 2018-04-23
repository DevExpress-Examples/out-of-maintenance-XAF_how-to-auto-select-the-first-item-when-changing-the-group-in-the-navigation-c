Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Win.Templates.ActionContainers
Imports DevExpress.XtraTreeList
Imports DevExpress.ExpressApp.Actions

Namespace DXExample.Module.Win
	Public Class WinSelectFirstNavigationItemController
		Inherits SelectFirstNavigationItemControllerBase
		Public Sub New()
		End Sub
		Protected Overrides Function FindNavigationActionContainer() As IActionContainer
			For Each actionContainer As IActionContainer In Window.Template.GetContainers()
				Dim result As NavigationActionContainer = TryCast(actionContainer, NavigationActionContainer)
				If result IsNot Nothing Then
					Return result
				End If
			Next actionContainer
			Return Nothing
		End Function
		Protected Overrides Sub SetupNavigationControl(ByVal container As IActionContainer)
			Dim navigationActionContainer As NavigationActionContainer = CType(container, NavigationActionContainer)
			Dim navBar As NavBarNavigationControl = TryCast(navigationActionContainer.NavigationControl, NavBarNavigationControl)
			If navBar IsNot Nothing Then
				AddHandler navBar.ActiveGroupChanged, AddressOf navBar_ActiveGroupChanged
			End If
			Dim treeList As TreeListNavigationControl = TryCast(navigationActionContainer.NavigationControl, TreeListNavigationControl)
			If treeList IsNot Nothing Then
				AddHandler treeList.FocusedNodeChanged, AddressOf treeList_FocusedNodeChanged
			End If
		End Sub
		Private Sub navBar_ActiveGroupChanged(ByVal sender As Object, ByVal e As DevExpress.XtraNavBar.NavBarGroupEventArgs)
			Dim navBar As NavBarNavigationControl = CType(sender, NavBarNavigationControl)
			If navBar.GroupToActionItemWrapperMap.ContainsKey(e.Group) Then
				AutoSelectFirstItemInGroup(navBar.GroupToActionItemWrapperMap(e.Group).ActionItem)
			End If
		End Sub
		Private Sub treeList_FocusedNodeChanged(ByVal sender As Object, ByVal e As FocusedNodeChangedEventArgs)
			If e.Node IsNot Nothing AndAlso e.Node.HasChildren AndAlso navigationAction IsNot Nothing Then
				Dim actionItem As ChoiceActionItem = CType(e.Node.Tag, ChoiceActionItem)
				If navigationAction.Active.ResultValue AndAlso navigationAction.Enabled.ResultValue Then
					AutoSelectFirstItemInGroup(actionItem)
				End If
			End If
		End Sub
	End Class
End Namespace
