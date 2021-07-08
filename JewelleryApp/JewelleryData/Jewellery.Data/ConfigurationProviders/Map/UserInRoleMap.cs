using Jewellery.Data.ConfigurationProviders.Base.Map;
using Jewellery.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jewellery.Data.ConfigurationProviders.Map
{
	public class UserInRoleMap : AbstractEntityMap<UserInRole>
	{
		protected override void InternalMap(EntityTypeBuilder<UserInRole> builder)
		{
			builder
			   .ToTable("UserInRole", "dbo");

			builder
				.HasKey(userinrole => userinrole.UserInRoleId)
				.HasName("PK_UserInRole_UserInRoleId");

			builder
				.HasOne(u => u.User)
				.WithMany()
				.HasForeignKey(ur => ur.UserId)
				.HasConstraintName("FK_UserInrole_User_UserID")
				.IsRequired();

			builder
				.HasOne(u => u.Role)
				.WithMany()
				.HasForeignKey(ur => ur.RoleId)
				.HasConstraintName("FK_UserInrole_Role_RoleID")
				.IsRequired();
		}
	}
}
