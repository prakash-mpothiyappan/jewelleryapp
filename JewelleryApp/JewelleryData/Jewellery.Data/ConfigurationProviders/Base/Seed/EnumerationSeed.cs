using System;
using Jewellery.Enities;

namespace Jewellery.Data.ConfigurationProviders.Base.Seed
{
	public class EnumerationSeed<TEnumeration> : IEntitySeed
	where TEnumeration : AbstractEnumeration
	{
		public void Seed(Microsoft.EntityFrameworkCore.ModelBuilder builder)
		{
			if (builder == null)
				throw new ArgumentNullException(nameof(builder));

			var entityTypeBuilder = builder.Entity<TEnumeration>();

			var enumerationHelper = new EnumerationHelper<TEnumeration>();

			foreach (var enumeration in enumerationHelper.GetAll())
			{
				entityTypeBuilder.HasData(enumeration);
			}
		}
	}
}
