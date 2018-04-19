using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Plugin.Widgets.PromoSlider.Models;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Mvc;


namespace Nop.Plugin.Widgets.PromoSlider.Infraestructure
{
    public class PromoSliderDependencyRegistrar : IDependencyRegistrar
    {
	    public int Order { get; }
		private const string CONTEXT_NAME = "nop_object_context_promo_slider";
	    public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
	    {
		    this.RegisterPluginDataContext<PromoSliderObjectContext>(builder, CONTEXT_NAME);

		    builder.RegisterType<EfRepository<PromoImageRecord>>()
			    .As<IRepository<PromoImageRecord>>()
			    .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
			    .InstancePerLifetimeScope();

		    builder.RegisterType<EfRepository<PromoImageRecord>>()
			    .As<IRepository<PromoImageRecord>>()
			    .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
			    .InstancePerLifetimeScope();
	    }

	  
    }
}
