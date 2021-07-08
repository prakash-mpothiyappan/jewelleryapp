using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reactjwel.DTO;

namespace Reactjwel.BC.interfaces
{
	public interface ITokenService
	{
		string BuildToken(string key, string issuer, UserDTO user);
		bool IsTokenValid(string key, string issuer, string token);
	}
}
