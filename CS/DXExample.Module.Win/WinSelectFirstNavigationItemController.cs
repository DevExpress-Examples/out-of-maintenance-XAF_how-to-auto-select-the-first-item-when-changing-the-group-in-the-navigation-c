using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Win.Templates.ActionContainers;
using DevExpress.XtraTreeList;
using DevExpress.ExpressApp.Actions;

namespace DXExample.Module.Win {
    public class WinSelectFirstNavigationItemController : SelectFirstNavigationItemControllerBase {
        public WinSelectFirstNavigationItemController() { }
        protected override IActionContainer FindNavigationActionContainer() {
            foreach (IActionContainer actionContainer in Window.Template.GetContainers()) {
                NavigationActionContainer result = actionContainer as NavigationActionContainer;
                if (result != null) {
                    return result;
                }
            }
            return null;
        }
        protected override void SetupNavigationControl(IActionContainer container) {
            NavigationActionContainer navigationActionContainer = (NavigationActionContainer)container;
            NavBarNavigationControl navBar = navigationActionContainer.NavigationControl as NavBarNavigationControl;
            if (navBar != null) {
                navBar.ActiveGroupChanged += navBar_ActiveGroupChanged;
            }
            TreeListNavigationControl treeList = navigationActionContainer.NavigationControl as TreeListNavigationControl;
            if (treeList != null) {
                treeList.FocusedNodeChanged += treeList_FocusedNodeChanged;
            }
        }
        void navBar_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e) {
            NavBarNavigationControl navBar = (NavBarNavigationControl)sender;
            if (navBar.GroupToActionItemWrapperMap.ContainsKey(e.Group)) {
                AutoSelectFirstItemInGroup(navBar.GroupToActionItemWrapperMap[e.Group].ActionItem);
            }
        }
        void treeList_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e) {
            if (e.Node != null && e.Node.HasChildren && navigationAction != null) {
                ChoiceActionItem actionItem = (ChoiceActionItem)e.Node.Tag;
                if (navigationAction.Active.ResultValue && navigationAction.Enabled.ResultValue) {
                    AutoSelectFirstItemInGroup(actionItem);
                }
            }
        }
    }
}
