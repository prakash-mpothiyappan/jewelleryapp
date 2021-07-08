using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reactjwel.DTO;

namespace Reactjwel.BC.interfaces
{
	public interface IJewelleryContext
	{
		UserDTO GetUserDetails(string userName, string password);
	}
}
