using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Core.Plugins;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;

namespace Nop.Plugin.Widgets.Test2
{
	public class FollowPricePlugin : BasePlugin, IWidgetPlugin
	{
		private readonly ISettingService _settingService;
		private readonly IWebHelper _webHelper;
		public FollowPricePlugin(ISettingService settingService, IWebHelper webHelper)
		{
			this._settingService = settingService;
			this._webHelper = webHelper;
		}

		public void GetPublicViewComponent(string widgetZone, out string viewComponentName)
		{
			viewComponentName = "WidgetsFollowPrice";
		}

		public IList<string> GetWidgetZones()
		{
			return new List<string> { "productdetails_inside_overview_buttons_before" };
		}

		public override string GetConfigurationPageUrl()
		{
			return _webHelper.GetStoreLocation() + "Admin/WidgetsFollowPrice/Configure";
		}

		public override void Install()
		{
			var settings = new FollowPriceSettings
			{
				APIKey = "",
				CSSClassName = ""
			};

			_settingService.SaveSetting(settings);

			this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.FollowPrice.APIKey", "API Key");
			this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.FollowPrice.APIKey.Hint", "Enter Follow Price API Key");
			this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.FollowPrice.CSSClass", "CSS Class Name");
			this.AddOrUpdatePluginLocaleResource("Plugins.Widgets.FollowPrice.CSSClass.Hint", "Enter CSS class name to override Follow price button style.");

			base.Install();
		}
		public override void Uninstall()
		{
			_settingService.DeleteSetting<FollowPriceSettings>();

			this.DeletePluginLocaleResource("Plugins.Widgets.FollowPrice.APIKey");
			this.DeletePluginLocaleResource("Plugins.Widgets.FollowPrice.APIKey.Hint");
			this.DeletePluginLocaleResource("Plugins.Widgets.FollowPrice.CSSClass");
			this.DeletePluginLocaleResource("Plugins.Widgets.FollowPrice.CSSClass.Hint");

			base.Uninstall();
		}
	}
}
