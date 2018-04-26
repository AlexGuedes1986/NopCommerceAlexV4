using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Nop.Core.Plugins;
using Nop.Plugin.Widgets.PromoSlider.Infraestructure;
using Nop.Services.Cms;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Widgets.PromoSlider
{
    public class PromoSliderPlugin : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
    {
	    private PromoSliderObjectContext _context;

	    public PromoSliderPlugin(PromoSliderObjectContext context)
	    {
		    _context = context;
	    }

	    public override void Install()
	    {
			_context.Install();
		    base.Install();
	    }

	    public override void Uninstall()
	    {
			_context.Uninstall();
			base.Uninstall();
	    }

	    public IList<string> GetWidgetZones()
	    {
		    return new List<string>();
	    }

	    public void GetPublicViewComponent(string widgetZone, out string viewComponentName)
	    {
		    throw new NotImplementedException();
	    }

		public void ManageSiteMap(SiteMapNode rootNode)
		{
			var menuItem = new SiteMapNode()
			{
				SystemName = "YourCustomSystemName",
				Title = "Promo Slider",
				ControllerName = "ControllerName",
				ActionName = "List",
				Visible = true,
				RouteValues = new RouteValueDictionary() { { "area", null } },
			};

			var createUpdateNode = new SiteMapNode()
			{
				SystemName = "YourCustomSystemName",
				Title = "New Slider",
				ControllerName = "ControllerName",
				ActionName = "List",
				Visible = true,
				RouteValues = new RouteValueDictionary() { { "area", null } },
			};

			var manageSliders = new SiteMapNode()
			{
				SystemName = "YourCustomSystemName",
				Title = "Manage Sliders",
				ControllerName = "ControllerName",
				ActionName = "List",
				Visible = true,
				RouteValues = new RouteValueDictionary() { { "area", null } },
			};

			menuItem.ChildNodes.Add(createUpdateNode);
			menuItem.ChildNodes.Add(manageSliders);
			var pluginNode = rootNode.ChildNodes.FirstOrDefault(x => x.SystemName == "Third party plugins");
			if (pluginNode != null)
				pluginNode.ChildNodes.Add(menuItem);
			else
				rootNode.ChildNodes.Add(menuItem);
		}
	}
}
