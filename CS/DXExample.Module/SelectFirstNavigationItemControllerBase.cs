using System;

using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.SystemModule;

namespace DXExample.Module {
    public abstract class SelectFirstNavigationItemControllerBase : WindowController {
        public const string AllowSelectFirstItemAttributeName = "AllowSelectFirstItem";
        SingleChoiceAction navigationAction;
        public SelectFirstNavigationItemControllerBase() {
            TargetWindowType = WindowType.Main;
        }
        protected override void OnActivated() {
            base.OnActivated();
            navigationAction = Frame.GetController<ShowNavigationItemController>().ShowNavigationItemAction;
            Frame.TemplateChanged += new EventHandler(Frame_TemplateChanged);
        }
        protected override void OnDeactivating() {
            base.OnDeactivating();
            Frame.TemplateChanged -= new EventHandler(Frame_TemplateChanged);
        }
        private void Frame_TemplateChanged(object sender, EventArgs e) {
            IActionContainer navigationControl = FindNavBarControl();
            if (navigationControl != null) {
                SetupNavigationControl(navigationControl);
            }
        }
        protected abstract IActionContainer FindNavBarControl();
        protected abstract void SetupNavigationControl(IActionContainer navigationControl);
        protected void SelectFirstItem(int navGroupIndex) {
            SelectFirstItem(navigationAction.Items[navGroupIndex]);
        }
        protected void SelectFirstItem(ChoiceActionItem navGroup) {
            if (!AllowSelectFirstItem()) return;
            foreach (ChoiceActionItem item in navGroup.Items) {
                if (item.Enabled.ResultValue && item.Active.ResultValue) {
                    navigationAction.DoExecute(item);
                    return;
                }
            }
        }
        protected bool AllowSelectFirstItem() {
            DictionaryAttribute attr = Application.Model.RootNode.FindChildNode(ShowNavigationItemController.NavigationItemsNodeName).FindAttribute(AllowSelectFirstItemAttributeName);
            if (attr != null && !string.IsNullOrEmpty(attr.Value)) {
                return Convert.ToBoolean(attr.Value);
            }
            return false;
        }
        public override Schema GetSchema() {
            return new Schema(new DictionaryXmlReader().ReadFromString(
                @"<Element Name=""Application"">
                    <Element Name=""" + ShowNavigationItemController.NavigationItemsNodeName + @""">
                       <Attribute Name=""" + AllowSelectFirstItemAttributeName + @""" Choice=""True,False""/>
                    </Element>
                </Element>"
                )
            );
        }
    }
}
