using System;
using Jewellery.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jewellery.Data.ConfigurationProviders.Base.Map
{
	public abstract class AbstractEnumerationMap<TEnumeration> : IEntityMap
		where TEnumeration : AbstractEnumeration
	{
		protected abstract string TableName { get; }

		protected virtual string Schema => "dbo";

		public void Map(ModelBuilder builder)
		{
			if (builder == null)
				throw new ArgumentNullException(nameof(builder));

			InternalMap(builder.Entity<TEnumeration>());
		}

		protected virtual void InternalMap(EntityTypeBuilder<TEnumeration> builder)
		{
			if (builder == null)
				throw new ArgumentNullException(nameof(builder));

			builder
				.ToTable(TableName, Schema);

			builder
				.HasKey(enumeration => enumeration.Id)
				.HasName($"PK_{TableName}_{TableName}Id");

			builder
				.Property(enumeration => enumeration.Id)
				.HasColumnName($"{TableName}Id")
				.ValueGeneratedNever();

			builder
				.Property(enumeration => enumeration.Name)
				.HasColumnName("Name");

			builder
				.Property(enumeration => enumeration.DisplayText)
				.HasColumnName("DisplayText");
		}
	}
}
