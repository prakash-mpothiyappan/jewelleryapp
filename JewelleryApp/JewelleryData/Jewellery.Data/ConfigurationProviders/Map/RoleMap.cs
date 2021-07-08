using Jewellery.Data.ConfigurationProviders.Base.Map;
using Jewellery.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jewellery.Data.ConfigurationProviders.Map
{
	public class RoleMap : AbstractEntityMap<Role>
	{
		protected override void InternalMap(EntityTypeBuilder<Role> builder)
		{
            builder
              .ToTable("Role", "dbo");

            builder
                .HasKey(role => role.RoleId)
                .HasName("PK_Role_RoleId");

            builder
                .Property(role => role.RoleId)
                .HasColumnName("RoleId")
                .ValueGeneratedOnAdd();

            builder
                .Property(role => role.RoleName)
                .HasColumnName("RoleName")
                .IsRequired();
        }
	}
}
