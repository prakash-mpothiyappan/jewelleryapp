using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewellery.Data;
using Jewellery.Data.ConfigurationProviders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace JewellryApp
{
	public class DbContextCreator : IDesignTimeDbContextFactory<JewelleryContext>
	{
		public DbContextCreator()
		{
		}

		public JewelleryContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<JewelleryContext>();
			optionsBuilder.UseSqlServer(
				"Data Source=(local);Initial Catalog=JewelleryStore;Integrated Security=True;"
				, x => x.MigrationsAssembly("Jewellery.Migrations"));

			return new JewelleryContext(optionsBuilder.Options, new JewelleryContextEntityMapProvider(), new JewelleryContextEntitySeedProvider());

		}
	}
}
