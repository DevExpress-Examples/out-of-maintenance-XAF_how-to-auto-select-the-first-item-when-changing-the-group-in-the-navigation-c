Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.SystemModule

Namespace DXExample.Module
	Public MustInherit Class SelectFirstNavigationItemControllerBase
		Inherits WindowController
		Private showNavigationItemController As ShowNavigationItemController
		Protected navigationAction As SingleChoiceAction
		Public Sub New()
			TargetWindowType = WindowType.Main
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			showNavigationItemController= Frame.GetController(Of ShowNavigationItemController)()
			navigationAction = showNavigationItemController.ShowNavigationItemAction
			AddHandler Frame.TemplateChanged, AddressOf Frame_TemplateChanged
		End Sub
		Protected Overrides Sub OnDeactivated()
			MyBase.OnDeactivated()
			RemoveHandler Frame.TemplateChanged, AddressOf Frame_TemplateChanged
		End Sub
		Private Sub Frame_TemplateChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim navigationControl As IActionContainer = FindNavigationActionContainer()
			If navigationControl IsNot Nothing Then
				SetupNavigationControl(navigationControl)
			End If
		End Sub
		Protected MustOverride Function FindNavigationActionContainer() As IActionContainer
		Protected MustOverride Sub SetupNavigationControl(ByVal container As IActionContainer)
		'protected void SelectFirstItem(int navGroupIndex) {
		'    AutoSelectFirstItemInGroup(navigationAction.Items[navGroupIndex]);
		'}
		Protected Sub AutoSelectFirstItemInGroup(ByVal navGroupItem As ChoiceActionItem)
			If (Not CanAutoSelectFirstItemInGroup()) Then
				Return
			End If
			For Each item As ChoiceActionItem In navGroupItem.Items
				If item.Enabled.ResultValue AndAlso item.Active.ResultValue Then
					navigationAction.DoExecute(item)
					Return
				End If
			Next item
		End Sub
		Protected Function CanAutoSelectFirstItemInGroup() As Boolean
			Return (CType((CType(Application.Model, IModelApplicationNavigationItems)).NavigationItems, IModelRootNavigationItemsEx)).AllowSelectFirstItem
		End Function
	End Class
End Namespace
