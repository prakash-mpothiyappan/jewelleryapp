using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reactjwel.DTO
{
	public class UserDTO
	{
		public string UserName { get; set; }
		public string Role { get; set; }
		public bool IsAuthrozied { get; set; }
		public string Token { get; set; }
	}
}
