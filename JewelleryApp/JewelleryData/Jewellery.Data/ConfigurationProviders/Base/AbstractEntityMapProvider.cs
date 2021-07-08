using System.Collections.Generic;
using Jewellery.Data.ConfigurationProviders.Base.Map;
using Microsoft.EntityFrameworkCore;

namespace Jewellery.Data.ConfigurationProviders
{
	public abstract class AbstractEntityMapProvider
	{
		public abstract IEnumerable<IEntityMap> EntityTypeMaps { get; }

		public void ApplyMaps(ModelBuilder builder)
		{
			foreach (var entityTypeMap in EntityTypeMaps)
			{
				entityTypeMap.Map(builder);
			}
		}
	}
}
