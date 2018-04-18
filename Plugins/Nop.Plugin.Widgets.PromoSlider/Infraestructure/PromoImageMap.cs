using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Widgets.PromoSlider.Models;

namespace Nop.Plugin.Widgets.PromoSlider.Infraestructure
{
    public class PromoImageMap : EntityTypeConfiguration<PromoImageRecord>
    {
	    public PromoImageMap()
	    {
		    ToTable("PromoSlider_PromoImages");
		    HasKey(m => m.PromoImageId);
		    Property(m => m.PromoSliderId);
		    Property(m => m.Caption);
		    Property(m => m.DisplayOrder);
		    Property(m => m.Url);

		    this.HasRequired(i => i.PromoSliderRecord)
			    .WithMany(s => s.Images)
			    .HasForeignKey(i => i.PromoSliderId);
	    }
    }
}
