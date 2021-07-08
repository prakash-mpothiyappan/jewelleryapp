using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewellery.Data.ConfigurationProviders.Base.Map;
using Jewellery.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jewellery.Data.ConfigurationProviders.Map
{
	public class UserMap : AbstractEntityMap<User>
	{
		protected override void InternalMap(EntityTypeBuilder<User> builder)
		{
            builder
               .ToTable("User", "dbo");

            builder
                .HasKey(user => user.UserId)
                .HasName("PK_User_UserId");

            builder
                .Property(user => user.UserId)
                .HasColumnName("UserId")
                .ValueGeneratedOnAdd();

            builder
                .Property(user => user.UserName)
                .HasColumnName("UserName")
                .IsRequired();

            builder
                .Property(user => user.DisplayName)
                .HasColumnName("DisplayName")
                .IsRequired();
            builder
                .Property(user => user.Password)
                .HasColumnName("Password")
                .IsRequired();
        }
	}
}
