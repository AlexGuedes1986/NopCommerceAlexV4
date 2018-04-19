using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Plugins;
using Nop.Plugin.Widgets.PromoSlider.Infraestructure;
using Nop.Services.Cms;

namespace Nop.Plugin.Widgets.PromoSlider
{
    public class PromoSliderPlugin : BasePlugin, IWidgetPlugin
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
    }
}
