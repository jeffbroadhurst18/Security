using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Data
{
	public class DbSeeder
	{
		private LocationContext _context;
		private RoleManager<IdentityRole> RoleManager;
		private UserManager<ApplicationUser> UserManager;

		public DbSeeder(LocationContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			RoleManager = roleManager;
			UserManager = userManager;
		}

		public async Task SeedAsync()
		{
			if (await _context.Users.CountAsync() == 0)
			{
				await CreateUsersAsync();
			}
		}

		private async Task CreateUsersAsync()
		{
			DateTime createdDate = new DateTime(2018, 11, 1, 12, 0, 0);
			DateTime lastModifiedDate = DateTime.Now;
			string role_Administrators = "Administrators";
			string role_Registered = "Registered";

			if (!await RoleManager.RoleExistsAsync(role_Administrators))
			{
				await RoleManager.CreateAsync(new IdentityRole(role_Administrators));
			}

			if (!await RoleManager.RoleExistsAsync(role_Registered))
			{
				await RoleManager.CreateAsync(new IdentityRole(role_Registered));
			}

			var user_Admin = new ApplicationUser()
			{
				UserName = "Admin",
				Email = "admin@email.com",
				SecurityStamp = Guid.NewGuid().ToString()
			};

			if (await UserManager.FindByIdAsync(user_Admin.Id) == null)
			{
				await UserManager.CreateAsync(user_Admin, "Pass4Admin");
				await UserManager.AddToRoleAsync(user_Admin, role_Administrators);
				user_Admin.EmailConfirmed = true;
				user_Admin.LockoutEnabled = false;
			}

			var user_Jeff = new ApplicationUser()
			{
				UserName = "Jeff",
				Email = "jeff@email.com",
				EmailConfirmed = true,
				LockoutEnabled = false,
				SecurityStamp = Guid.NewGuid().ToString()
			};

			if (await UserManager.FindByIdAsync(user_Jeff.Id) == null)
			{
				await UserManager.CreateAsync(user_Jeff, "Pass4Jeff");
				await UserManager.AddToRoleAsync(user_Jeff, role_Registered);
			}

			await _context.SaveChangesAsync();

		}

	}
}
