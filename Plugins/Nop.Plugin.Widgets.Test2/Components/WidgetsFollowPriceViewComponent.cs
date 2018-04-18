using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.Test2.Models;
using Nop.Services.Catalog;
using Nop.Services.Configuration;
using Nop.Web.Factories;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.Test2.Components
{
	[ViewComponent(Name = "WidgetsFollowPrice")]
	public class WidgetsFollowPriceViewComponent : NopViewComponent
	{
		private readonly IStoreContext _storeContext;
		private readonly ISettingService _settingService;
		private readonly IProductService _productService;
		private readonly IProductModelFactory _productModelFactory;
		private readonly IWebHelper _webHelper;
		private readonly IWorkContext _workContext;

		public WidgetsFollowPriceViewComponent(IStoreContext storeContext,
			ISettingService settingService, IProductService productService,
			IProductModelFactory productModelFactory, IWebHelper webHelper,
			IWorkContext workContext)
		{
			this._storeContext = storeContext;
			this._settingService = settingService;
			this._productService = productService;
			this._productModelFactory = productModelFactory;
			this._webHelper = webHelper;
			this._workContext = workContext;
		}

		public IViewComponentResult Invoke(string widgetZone, object additionalData)
		{
			var followPriceSettings = _settingService.LoadSetting<FollowPriceSettings>(_storeContext.CurrentStore.Id);

			var model = new PublicInfoModel
			{
				APIKey = followPriceSettings.APIKey,
				CSSClassName = followPriceSettings.CSSClassName
			};

			if (additionalData != null)
			{
				model.ProductId = (int)additionalData;
				model.LanguageCode = _workContext.WorkingLanguage.LanguageCulture;
				model.UserId = _workContext.CurrentCustomer != null ? _workContext.CurrentCustomer.Id : 0;
				if (model.ProductId > 0)
				{
					var product = _productService.GetProductById(model.ProductId);
					if (product != null && !product.Deleted)
					{
						var productDetails = _productModelFactory.PrepareProductDetailsModel(product);
						model.ProductName = productDetails.Name;
						model.ProductUrl = _webHelper.GetStoreHost(_webHelper.IsCurrentConnectionSecured()) + productDetails.SeName;
						model.ProductImageUrl = productDetails.DefaultPictureModel.ImageUrl;
						model.productPrice = productDetails.ProductPrice.PriceValue;
						model.CurrencyCode = productDetails.ProductPrice.CurrencyCode;
						model.ProductAvailable = 1;
					}
				}
			}

			return View("~/Plugins/Widgets.FollowPrice/Views/PublicInfo.cshtml", model);
		}
	}
}
