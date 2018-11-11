using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Security.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Security.Classes
{
	public class UserService : IUserService
	{
		private readonly LocationContext _dbContext;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly AppSettings _appSettings;

		public UserService(LocationContext dbContext, UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager, IOptions<AppSettings> appSettings)
		{
			_dbContext = dbContext;
			_userManager = userManager;
			_signInManager = signInManager;
			_appSettings = appSettings.Value;
		}

		public async Task<ApplicationUser> GetUser(string username, string password)
		{
			var user = await _userManager.FindByNameAsync(username);

			if (user == null && username.Contains("@"))
			{
				user = await _userManager.FindByEmailAsync(username);
			}

			// return null if user not found
			if (user == null)
				return null;

			var success = user != null && await _userManager.CheckPasswordAsync(user, password);

			if (!success) { return null; }

			return user;
		}


		public string Authenticate(ApplicationUser user)
		{
			// authentication successful so generate jwt token, that will be passed back with further requests
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Id.ToString())
				}),
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			var usertoken = tokenHandler.WriteToken(token);
			return usertoken;
		}
	}
}
