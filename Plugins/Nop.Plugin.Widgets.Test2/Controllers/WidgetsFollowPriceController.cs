using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.Test2.Models;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;

namespace Nop.Plugin.Widgets.Test2.Controllers
{
	[Area(AreaNames.Admin)]
	public class WidgetsFollowPriceController : BasePluginController
	{
		private readonly IWorkContext _workContext;
		private readonly IStoreService _storeService;
		private readonly IPermissionService _permissionService;
		private readonly ISettingService _settingService;
		private readonly ILocalizationService _localizationService;


		public WidgetsFollowPriceController(IWorkContext workContext, IStoreService storeService,
			IPermissionService permissionService, ISettingService settingService,
			ILocalizationService localizationService)
		{
			this._workContext = workContext;
			this._storeService = storeService;
			this._permissionService = permissionService;
			this._settingService = settingService;
			this._localizationService = localizationService;
		}

		public IActionResult Configure()
		{
			if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
				return AccessDeniedView();

			var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
			var followPriceSettings = _settingService.LoadSetting<FollowPriceSettings>(storeScope);

			var model = new ConfigurationModel
			{
				APIKey = followPriceSettings.APIKey,
				CSSClass = followPriceSettings.CSSClassName
			};

			if (storeScope > 0)
			{
				model.APIKey_OverrideForStore = _settingService.SettingExists(followPriceSettings, x => x.APIKey, storeScope);
				model.APIKey_OverrideForStore = _settingService.SettingExists(followPriceSettings, x => x.CSSClassName, storeScope);
			}

			return View("~/Plugins/Nop.Plugin.Widgets.Test2/Views/Configure.cshtml", model);
		}

		[HttpPost]
		public IActionResult Configure(ConfigurationModel model)
		{
			if (!_permissionService.Authorize(StandardPermissionProvider.ManageWidgets))
				return AccessDeniedView();

			var storeScope = this.GetActiveStoreScopeConfiguration(_storeService, _workContext);
			var followPriceSettings = _settingService.LoadSetting<FollowPriceSettings>(storeScope);

			followPriceSettings.APIKey = model.APIKey;
			followPriceSettings.CSSClassName = model.CSSClass;

			_settingService.SaveSettingOverridablePerStore(followPriceSettings, x => x.APIKey, model.APIKey_OverrideForStore, storeScope, false);
			_settingService.SaveSettingOverridablePerStore(followPriceSettings, x => x.CSSClassName, model.CSSClass_OverrideForStore, storeScope, false);
			_settingService.ClearCache();
			SuccessNotification(_localizationService.GetResource("Admin.Plugins.Saved"));
			return Configure();
		}
	}
}
