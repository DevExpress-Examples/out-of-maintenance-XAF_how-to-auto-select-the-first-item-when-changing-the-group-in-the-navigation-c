<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128587975/11.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E506)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [WinSelectFirstNavigationItemController.cs](./CS/DXExample.Module.Win/WinSelectFirstNavigationItemController.cs) (VB: [WinSelectFirstNavigationItemController.vb](./VB/DXExample.Module.Win/WinSelectFirstNavigationItemController.vb))
* [Module.cs](./CS/DXExample.Module/Module.cs) (VB: [Module.vb](./VB/DXExample.Module/Module.vb))
* [SelectFirstNavigationItemControllerBase.cs](./CS/DXExample.Module/SelectFirstNavigationItemControllerBase.cs) (VB: [SelectFirstNavigationItemControllerBase.vb](./VB/DXExample.Module/SelectFirstNavigationItemControllerBase.vb))
<!-- default file list end -->
# How to auto-select the first item, when changing the group in the navigation control


<p>By default, XAF doesn't execute the first navigation item when changing the group. But, you can easily change this behavior by customizing the navigation control, and reusing the functionality of the ShowNavigationItemController.</p>
<p>This example demonstrates how to write a controller that will do this. This controller is managed by the attribute. By default, it doesn't select the first navigation item in the group.</p>
<p>These help topics will be also very helpful:<br> <a href="http://documentation.devexpress.com/#Xaf/CustomDocument2617"><u>How to: Change Navigation Control Appearance</u></a><br> <a href="http://documentation.devexpress.com/#Xaf/clsDevExpressExpressAppSystemModuleShowNavigationItemControllertopic"><u>ShowNavigationItemController Class</u></a><br> <a href="http://documentation.devexpress.com/#Xaf/CustomDocument3016"><u>Built-in Controllers and Actions</u></a></p>


<h3>Description</h3>

<p>This version is extended to operate in both NavigationStyle.NavBar and NavigationStyle.TreeList modes.</p>

<br/>


