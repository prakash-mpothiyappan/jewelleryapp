using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Data.ConfigurationProviders.Base.Seed
{
	public interface IEntitySeed
	{
		void Seed(Microsoft.EntityFrameworkCore.ModelBuilder builder);
	}
}
