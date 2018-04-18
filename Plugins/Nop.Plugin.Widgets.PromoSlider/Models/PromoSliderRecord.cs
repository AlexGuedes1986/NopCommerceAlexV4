using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.PromoSlider.Models
{
    public class PromoSliderRecord : BaseEntity
    {
	    public int PromoSliderId { get; set; }
	    public string PromoSliderName { get; set; }
	    public bool IsActive { get; set; }
	    public string ZoneName { get; set; }
	    public int Interval { get; set; }
	    public bool PauseOnHover { get; set; }
	    public bool Wrap { get; set; }
	    public bool KeyBoard { get; set; }
	    public List<PromoImageRecord> Images { get; set; }
    }
}
