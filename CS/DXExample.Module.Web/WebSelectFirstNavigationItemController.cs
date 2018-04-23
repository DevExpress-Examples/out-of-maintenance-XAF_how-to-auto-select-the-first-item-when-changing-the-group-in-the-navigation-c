using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Web.Templates.ActionContainers;

namespace DXExample.Module.Web {
    public class WebSelectFirstNavigationItemController : SelectFirstNavigationItemControllerBase {
        public WebSelectFirstNavigationItemController() { }
        protected override DevExpress.ExpressApp.Templates.IActionContainer FindNavBarControl() {
            if (Window.Template != null) {
                foreach (IActionContainer actionContainer in Window.Template.GetContainers()) {
                    if (actionContainer is NavigationTabsActionContainer || actionContainer is NavigationBarActionContainer) {
                        return actionContainer;
                    }
                }
            }
            return null;
        }
        protected override void SetupNavigationControl(IActionContainer navigationControl) {
            if (navigationControl is NavigationTabsActionContainer) {
                NavigationTabsActionContainer navTabsControl = (NavigationTabsActionContainer)navigationControl;
                navTabsControl.ActiveTabChanged += new DevExpress.Web.ASPxTabControl.TabControlEventHandler(navTabsControl_ActiveTabChanged);
                navTabsControl.AutoPostBack = true;
            } else if (navigationControl is NavigationBarActionContainer) {
                NavigationBarActionContainer navBarControl = (NavigationBarActionContainer)navigationControl;
                navBarControl.ExpandedChanged += new DevExpress.Web.ASPxNavBar.NavBarGroupEventHandler(navBarControl_ExpandedChanged);
                navBarControl.AutoPostBack = true;
            }
        }
        private void navTabsControl_ActiveTabChanged(object source, DevExpress.Web.ASPxTabControl.TabControlEventArgs e) {
            SelectFirstItem(e.Tab.Index);
        }
        private void navBarControl_ExpandedChanged(object source, DevExpress.Web.ASPxNavBar.NavBarGroupEventArgs e) {
            SelectFirstItem(e.Group.Index);
        }
    }
}
