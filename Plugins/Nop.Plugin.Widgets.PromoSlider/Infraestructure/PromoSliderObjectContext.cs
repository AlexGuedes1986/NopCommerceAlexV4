using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Data;

namespace Nop.Plugin.Widgets.PromoSlider.Infraestructure
{
    public class PromoSliderObjectContext : DbContext, IDbContext	
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

	    public void Install()
	    {
		    Database.SetInitializer<PromoSliderObjectContext>(null);
		    Database.ExecuteSqlCommand(CreateDatabaseInstallationScript());
		    SaveChanges();
	    }

	    public void Uninstall()
	    {
		    this.DropPluginTable("PromoSlider_PromoImages");
		    this.DropPluginTable("PromoSlider_PromoSliders");
	    }

	    public IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
	    {
		    return base.Set<TEntity>();
	    }

	    public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
	    {
		    throw new NotImplementedException();
	    }

	    public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
	    {
		    throw new NotImplementedException();
	    }

	    public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
	    {
		    throw new NotImplementedException();
	    }

	    public void Detach(object entity)
	    {
		    throw new NotImplementedException();
	    }

	    public bool ProxyCreationEnabled { get; set; }
	    public bool AutoDetectChangesEnabled { get; set; }
    }
}
