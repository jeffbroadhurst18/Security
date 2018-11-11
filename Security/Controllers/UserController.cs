using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Security.Classes;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[AllowAnonymous]
		[HttpPost("authenticate")]
		public  async Task<IActionResult> Authenticate([FromBody]UserPassword userPassword)
		{
			var user = await _userService.GetUser(userPassword.username, userPassword.password);

			if (user == null)
				return BadRequest(new { message = "Username or password is incorrect" });

			var token = _userService.Authenticate(user);

			return Ok(token);
		}
	}
}