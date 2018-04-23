using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;

namespace DXExample.Module.Win {
    public class WinSelectFirstNavigationItemController : SelectFirstNavigationItemControllerBase {
        public WinSelectFirstNavigationItemController() { }
        protected override DevExpress.ExpressApp.Templates.IActionContainer FindNavBarControl() {
            foreach (IActionContainer actionContainer in Window.Template.GetContainers()) {
                if (actionContainer is NavBarActionContainer) {
                    return actionContainer;
                }
            }
            return null;
        }
        protected override void SetupNavigationControl(IActionContainer navigationControl) {
            NavBarActionContainer navBaeControl = (NavBarActionContainer)navigationControl;
            navBaeControl.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(navBaeControl_ActiveGroupChanged);
        }
        void navBaeControl_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e) {
            SelectFirstItem(((NavBarActionGroup)e.Group).Item);
        }
    }
}
