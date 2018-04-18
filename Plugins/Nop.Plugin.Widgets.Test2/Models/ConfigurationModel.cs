using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Mvc.ModelBinding;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Plugin.Widgets.Test2.Models
{
	public class ConfigurationModel : BaseNopModel
	{
		public int ActiveStoreScopeConfiguration { get; set; }

		[NopResourceDisplayName("Plugins.Widgets.FollowPrice.APIKey")]
		public string APIKey { get; set; }
		public bool APIKey_OverrideForStore { get; set; }

		[NopResourceDisplayName("Plugins.Widgets.FollowPrice.CSSClass")]
		public string CSSClass { get; set; }
		public bool CSSClass_OverrideForStore { get; set; }
	}
}
