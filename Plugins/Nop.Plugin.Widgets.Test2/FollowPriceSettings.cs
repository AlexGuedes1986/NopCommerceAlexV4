using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Configuration;

namespace Nop.Plugin.Widgets.Test2
{
    public class FollowPriceSettings : ISettings
    {
		public string APIKey { get; set; }
	    public string CSSClassName { get; set; }
	}
}
