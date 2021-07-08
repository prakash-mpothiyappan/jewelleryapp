using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jewellery.Data.ConfigurationProviders.Base.Map
{
	public abstract class AbstractEntityMap<TEntityType> : IEntityMap
		where TEntityType : class
	{
		public void Map(ModelBuilder builder)
		{
			if (builder == null)
				throw new ArgumentNullException(nameof(builder));

			InternalMap(builder.Entity<TEntityType>());
		}

		protected abstract void InternalMap(EntityTypeBuilder<TEntityType> builder);
	}
}
