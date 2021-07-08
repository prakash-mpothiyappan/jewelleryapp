using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jewellery.Data.ConfigurationProviders.Base.Seed
{
	public abstract class AbstractEntitySeed<TEntityType> : IEntitySeed
		where TEntityType : class
	{
		protected abstract void InternalSeed(EntityTypeBuilder<TEntityType> builder);

		public void Seed(Microsoft.EntityFrameworkCore.ModelBuilder builder)
		{
			if (builder == null)
				throw new ArgumentNullException(nameof(builder));

			InternalSeed(builder.Entity<TEntityType>());
		}
	}
}
