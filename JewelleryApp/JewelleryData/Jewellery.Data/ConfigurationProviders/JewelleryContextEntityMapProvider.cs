using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jewellery.Data.ConfigurationProviders.Base.Map;
using Jewellery.Data.ConfigurationProviders.Map;

namespace Jewellery.Data.ConfigurationProviders
{
	public class JewelleryContextEntityMapProvider : AbstractEntityMapProvider
	{
		public override IEnumerable<IEntityMap> EntityTypeMaps => new List<IEntityMap>() {
		new UserMap(),
		new RoleMap(),
		new UserInRoleMap()
		};
	}
}
