// Developer Express Code Central Example:
// How to auto-select the first item, when changing the group in the navigation control.
// 
// By default, XAF doesn't execute the first navigation item when changing the
// group. But, you can easily change this behavior by customizing the navigation
// control, and reusing the functionality of the ShowNavigationItemController. This
// example demonstrates how to write a controller that will do this. This
// controller is managed by the attribute. By default, it doesn't select the first
// navigation item in the group. These help topics will be also very helpful: How
// to: Change Navigation Control Appearance ShowNavigationItemController Class
// Built-in Controllers and Actions
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E506

using DevExpress.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace DXExample.Module
{
    [DefaultClassOptions]
    [NavigationItem(GroupName="Group1")]
    public class DomainObject1 : BaseObject {
        public DomainObject1(Session session) : base(session) { }
    }
    [DefaultClassOptions]
    [NavigationItem(GroupName = "Group1")]
    public class DomainObject2 : BaseObject {
        public DomainObject2(Session session) : base(session) { }
    }
    [DefaultClassOptions]
    [NavigationItem(GroupName = "Group2")]
    public class DomainObject3 : BaseObject {
        public DomainObject3(Session session) : base(session) { }
    }
    [DefaultClassOptions]
    [NavigationItem(GroupName = "Group2")]
    public class DomainObject4 : BaseObject {
        public DomainObject4(Session session) : base(session) { }
    }
    [DefaultClassOptions]
    [NavigationItem(GroupName = "Group3")]
    public class DomainObject5 : BaseObject {
        public DomainObject5(Session session) : base(session) { }
    }
    [DefaultClassOptions]
    [NavigationItem(GroupName = "Group3")]
    public class DomainObject6 : BaseObject {
        public DomainObject6(Session session) : base(session) { }
    }
}
