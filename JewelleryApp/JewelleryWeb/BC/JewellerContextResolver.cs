using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jewellery.Data;
using Reactjwel.BC.interfaces;
using Reactjwel.DTO;

namespace Reactjwel.BC
{
	public class JewellerContextResolver : IJewelleryContext
	{
		private readonly JewelleryContext _jewelleryContext;
		public JewellerContextResolver(JewelleryContext context)
		{
			_jewelleryContext = context;
		}

		public UserDTO GetUserDetails(string userName, string password)
		{
			int userID = _jewelleryContext.Users
				.Where(x => x.UserName.ToLower() == userName.ToLower() && x.Password == password)
				.Select(x => x.UserId).FirstOrDefault();

			if (userID > 0)
			{
				return _jewelleryContext.UserInRoles.Where(x => x.UserId == userID).Select(
				x => new UserDTO { UserName = x.User.DisplayName, Role = x.Role.RoleName, IsAuthrozied = (x.Role.RoleName == "Privileged") }
				).FirstOrDefault();
			}
			else
			{
				return null;
			}

		}
	}
}
