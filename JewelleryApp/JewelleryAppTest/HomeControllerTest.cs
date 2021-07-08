using System.Text.Json;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Reactjwel.BC.interfaces;
using Reactjwel.Controllers;
using Reactjwel.DTO;
using Xunit;

namespace JewelleryAppTest
{
	public class HomeControllerTest
	{
		[Fact]
		public void Check_Login_Returns_Token_ForValid_User()
		{
			//Arange
			var data = A.Fake<IJewelleryContext>();
			var tokenService = A.Fake<ITokenService>();
			var config = A.Fake<IConfiguration>();
			var user = new LoginDTO { UserName = "ValidUser", Password = "ValidPassword" };
			var fakeResult = new UserDTO { UserName = "ValidUser", Role = "Normal", IsAuthrozied = true };
			A.CallTo(() => data.GetUserDetails(user.UserName, user.Password)).Returns(fakeResult);
			A.CallTo(() => tokenService.BuildToken("My SecreteKey", "I am a key issure", fakeResult)).Returns("Token");
			var controller = new HomeController(config, data, tokenService);

			//Act
			IActionResult actionResult = controller.Post(user);
			var result = actionResult as OkObjectResult;
			var returnResult = JsonSerializer.Deserialize<UserDTO>(result.Value.ToString());

			//Assert
			Assert.True(returnResult.UserName == fakeResult.UserName);
		}

	}
}
