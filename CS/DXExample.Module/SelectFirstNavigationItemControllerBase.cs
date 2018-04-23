using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.SystemModule;

namespace DXExample.Module {
    public abstract class SelectFirstNavigationItemControllerBase : WindowController {
        ShowNavigationItemController showNavigationItemController;
        protected SingleChoiceAction navigationAction;
        public SelectFirstNavigationItemControllerBase() {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated() {
            base.OnActivated();
            showNavigationItemController= Frame.GetController<ShowNavigationItemController>();
            navigationAction = showNavigationItemController.ShowNavigationItemAction;
            Frame.TemplateChanged += new EventHandler(Frame_TemplateChanged);
        }
        protected override void OnDeactivated() {
            base.OnDeactivated();
            Frame.TemplateChanged -= new EventHandler(Frame_TemplateChanged);
        }
        private void Frame_TemplateChanged(object sender, EventArgs e) {
            IActionContainer navigationControl = FindNavigationActionContainer();
            if (navigationControl != null) {
                SetupNavigationControl(navigationControl);
            }
        }
        protected abstract IActionContainer FindNavigationActionContainer();
        protected abstract void SetupNavigationControl(IActionContainer container);
        //protected void SelectFirstItem(int navGroupIndex) {
        //    AutoSelectFirstItemInGroup(navigationAction.Items[navGroupIndex]);
        //}
        protected void AutoSelectFirstItemInGroup(ChoiceActionItem navGroupItem) {
            if (!CanAutoSelectFirstItemInGroup()) return;
            foreach (ChoiceActionItem item in navGroupItem.Items) {
                if (item.Enabled.ResultValue && item.Active.ResultValue) {
                    navigationAction.DoExecute(item);
                    return;
                }
            }
        }
        protected bool CanAutoSelectFirstItemInGroup() {
            return ((IModelRootNavigationItemsEx)((IModelApplicationNavigationItems)Application.Model).NavigationItems).AllowSelectFirstItem;
        }
    }
}
