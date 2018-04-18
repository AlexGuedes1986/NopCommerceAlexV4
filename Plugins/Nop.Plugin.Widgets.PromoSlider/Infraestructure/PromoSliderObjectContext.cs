using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.PromoSlider.Infraestructure
{
    public class PromoSliderObjectContext : DbContext
    {
	    public PromoSliderObjectContext(string connectionString) : base(connectionString)
	    {
	    }

	    protected override void OnModelCreating(DbModelBuilder modelBuilder)
	    {
		    modelBuilder.Configurations.Add(new PromoSliderMap());
		    modelBuilder.Configurations.Add(new PromoImageMap());
		    base.OnModelCreating(modelBuilder);
	    }

	    public string CreateDatabaseInstallationScript()
	    {
		    return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
	    }

    }
}
