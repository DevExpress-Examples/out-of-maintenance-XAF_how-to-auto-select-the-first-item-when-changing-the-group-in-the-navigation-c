Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Actions
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.SystemModule

Namespace DXExample.Module
	Public MustInherit Class SelectFirstNavigationItemControllerBase
		Inherits WindowController
		Public Const AllowSelectFirstItemAttributeName As String = "AllowSelectFirstItem"
		Private navigationAction As SingleChoiceAction
		Public Sub New()
			TargetWindowType = WindowType.Main
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			navigationAction = Frame.GetController(Of ShowNavigationItemController)().ShowNavigationItemAction
			AddHandler Frame.TemplateChanged, AddressOf Frame_TemplateChanged
		End Sub
		Protected Overrides Sub OnDeactivating()
			MyBase.OnDeactivating()
			RemoveHandler Frame.TemplateChanged, AddressOf Frame_TemplateChanged
		End Sub
		Private Sub Frame_TemplateChanged(ByVal sender As Object, ByVal e As EventArgs)
			Dim navigationControl As IActionContainer = FindNavBarControl()
			If navigationControl IsNot Nothing Then
				SetupNavigationControl(navigationControl)
			End If
		End Sub
		Protected MustOverride Function FindNavBarControl() As IActionContainer
		Protected MustOverride Sub SetupNavigationControl(ByVal navigationControl As IActionContainer)
		Protected Sub SelectFirstItem(ByVal navGroupIndex As Integer)
			SelectFirstItem(navigationAction.Items(navGroupIndex))
		End Sub
		Protected Sub SelectFirstItem(ByVal navGroup As ChoiceActionItem)
			If (Not AllowSelectFirstItem()) Then
				Return
			End If
			For Each item As ChoiceActionItem In navGroup.Items
				If item.Enabled.ResultValue AndAlso item.Active.ResultValue Then
					navigationAction.DoExecute(item)
					Return
				End If
			Next item
		End Sub
		Protected Function AllowSelectFirstItem() As Boolean
			Dim attr As DictionaryAttribute = Application.Model.RootNode.FindChildNode(ShowNavigationItemController.NavigationItemsNodeName).FindAttribute(AllowSelectFirstItemAttributeName)
			If attr IsNot Nothing AndAlso (Not String.IsNullOrEmpty(attr.Value)) Then
				Return Convert.ToBoolean(attr.Value)
			End If
			Return False
		End Function
		Public Overrides Function GetSchema() As Schema
			Return New Schema(New DictionaryXmlReader().ReadFromString("<Element Name=""Application"">" & ControlChars.CrLf & "                    <Element Name=""" & ShowNavigationItemController.NavigationItemsNodeName & """>" & ControlChars.CrLf & "                       <Attribute Name=""" & AllowSelectFirstItemAttributeName & """ Choice=""True,False""/>" & ControlChars.CrLf & "                    </Element>" & ControlChars.CrLf & "                </Element>"))
		End Function
	End Class
End Namespace
