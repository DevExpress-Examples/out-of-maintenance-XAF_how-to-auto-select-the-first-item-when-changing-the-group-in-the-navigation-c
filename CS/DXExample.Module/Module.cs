using System;
using System.Collections.Generic;

using DevExpress.ExpressApp;
using System.Reflection;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Model;


namespace DXExample.Module {
    public sealed partial class DXExampleModule : ModuleBase {
        public DXExampleModule() {
            InitializeComponent();
        }
        public override void ExtendModelInterfaces(ModelInterfaceExtenders extenders) {
            base.ExtendModelInterfaces(extenders);
            extenders.Add<IModelRootNavigationItems, IModelRootNavigationItemsEx>();
        }
    }
    public interface IModelRootNavigationItemsEx {
        bool AllowSelectFirstItem { get;set;}
    }
}
