using Nop.Core;

namespace Nop.Plugin.Widgets.PromoSlider.Models
{
	public class PromoImageRecord : BaseEntity
	{
		public int PromoImageId { get; set; }
		public int PromoSliderId { get; set; }
		public string Caption { get; set; }
		public string Url { get; set; }
		public string FilePath { get; set; }
		public int DisplayOrder { get; set; }
		public PromoSliderRecord PromoSliderRecord { get; set; }
	}
}