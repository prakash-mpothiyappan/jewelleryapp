﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Enities
{
	public class UserInRole
	{
		public int UserInRoleId { get; set; }
		public int UserId { get; set; }
		public int RoleId { get; set; }
		public User User { get; set; }
		public Role Role { get; set; }
	}
}
