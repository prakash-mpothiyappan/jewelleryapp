using Jewellery.Data.ConfigurationProviders;
using Jewellery.Enities;
using Microsoft.EntityFrameworkCore;

namespace Jewellery.Data
{
	public class JewelleryContext: DbContext
	{
		private AbstractEntityMapProvider _entityMapProvider;
		private AbstractEntitySeedProvider _entitySeedProvider;

		public JewelleryContext(
			DbContextOptions options,
			AbstractEntityMapProvider entityMapProvider = null,
			AbstractEntitySeedProvider entitySeedProvider = null
		) : base(options)
		{
			_entityMapProvider = entityMapProvider;
			_entitySeedProvider = entitySeedProvider;
		}

		public virtual DbSet<User> Users { get; set; }

		public virtual DbSet<Role> Roles { get; set; }

		public virtual DbSet<UserInRole> UserInRoles { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			_entityMapProvider ??= new JewelleryContextEntityMapProvider();
			_entityMapProvider.ApplyMaps(builder);

			//_entitySeedProvider ??= new JewelleryContextEntitySeedProvider();
			//_entitySeedProvider.Seed(builder);
		}
	}
}
