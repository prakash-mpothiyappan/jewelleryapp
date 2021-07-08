using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Reactjwel.BC.interfaces;
using Reactjwel.DTO;

namespace Reactjwel.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HomeController : ControllerBase
	{
		private readonly IJewelleryContext _jewelleryContext;
		private readonly ITokenService _tokenService;
		private readonly IConfiguration _config;

		public HomeController(
			IConfiguration config,
			IJewelleryContext context, 
			ITokenService tokenService)
		{
			_jewelleryContext = context;
			_tokenService = tokenService;
			_config = config;
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public IActionResult Post(LoginDTO loginDTO)
		{
			if (string.IsNullOrEmpty(loginDTO.UserName) || string.IsNullOrEmpty(loginDTO.Password))
			{
				return (RedirectToAction("Error"));
			}
			IActionResult response = Unauthorized();
			var validUser = _jewelleryContext.GetUserDetails(loginDTO.UserName, loginDTO.Password);

			if (validUser != null)
			{
				var generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(), validUser);
				if (generatedToken != null)
				{
					validUser.Token = generatedToken;
					return Ok(JsonSerializer.Serialize(validUser));
				}
				else
				{
					return (RedirectToAction("Error"));
				}
			}
			else
			{
				return Unauthorized();
			}
		}
	}
}
