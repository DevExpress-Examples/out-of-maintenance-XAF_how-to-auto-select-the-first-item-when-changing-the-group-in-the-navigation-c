' Developer Express Code Central Example:
' How to auto-select the first item, when changing the group in the navigation control.
' 
' By default, XAF doesn't execute the first navigation item when changing the
' group. But, you can easily change this behavior by customizing the navigation
' control, and reusing the functionality of the ShowNavigationItemController. This
' example demonstrates how to write a controller that will do this. This
' controller is managed by the attribute. By default, it doesn't select the first
' navigation item in the group. These help topics will be also very helpful: How
' to: Change Navigation Control Appearance ShowNavigationItemController Class
' Built-in Controllers and Actions
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E506


Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl

Namespace DXExample.Module
	<DefaultClassOptions, NavigationItem(GroupName:="Group1")> _
	Public Class DomainObject1
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
	End Class
	<DefaultClassOptions, NavigationItem(GroupName := "Group1")> _
	Public Class DomainObject2
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
	End Class
	<DefaultClassOptions, NavigationItem(GroupName := "Group2")> _
	Public Class DomainObject3
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
	End Class
	<DefaultClassOptions, NavigationItem(GroupName := "Group2")> _
	Public Class DomainObject4
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
	End Class
	<DefaultClassOptions, NavigationItem(GroupName := "Group3")> _
	Public Class DomainObject5
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
	End Class
	<DefaultClassOptions, NavigationItem(GroupName := "Group3")> _
	Public Class DomainObject6
		Inherits BaseObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
	End Class
End Namespace
