using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Mvc.Models;

namespace Nop.Plugin.Widgets.Test2.Models
{
	public class PublicInfoModel : BaseNopModel
	{
		public string APIKey { get; set; }
		public string CSSClassName { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string ProductUrl { get; set; }
		public string ProductImageUrl { get; set; }
		public decimal productPrice { get; set; }
		public string CurrencyCode { get; set; }
		public int ProductAvailable { get; set; }
		public int UserId { get; set; }
		public string Category { get; set; }
		public string SubCategory { get; set; }
		public string LanguageCode { get; set; }
	}
}
