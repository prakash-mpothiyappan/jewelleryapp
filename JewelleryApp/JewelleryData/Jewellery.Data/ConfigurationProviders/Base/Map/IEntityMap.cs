using Microsoft.EntityFrameworkCore;

namespace Jewellery.Data.ConfigurationProviders.Base.Map
{
	public interface IEntityMap
	{
		void Map(ModelBuilder builder);
	}
}
