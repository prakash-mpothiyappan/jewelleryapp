using System.Collections.Generic;
using Jewellery.Data.ConfigurationProviders.Base.Seed;

namespace Jewellery.Data.ConfigurationProviders
{
	public abstract class AbstractEntitySeedProvider
	{
		protected abstract IEnumerable<IEntitySeed> EntitySeeds { get; }

		public void Seed(Microsoft.EntityFrameworkCore.ModelBuilder builder)
		{
			foreach (var entitySeed in EntitySeeds)
			{
				entitySeed.Seed(builder);
			}
		}
	}
}
