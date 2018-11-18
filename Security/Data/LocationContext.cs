using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Security.Data;

namespace Security.Data
{
	public class LocationContext : IdentityDbContext<ApplicationUser>
	{
		public LocationContext(DbContextOptions<LocationContext> options)
			: base(options)
		{
		}

		public DbSet<Location> Locations { get; set; }
		public DbSet<Parkrun> Parkruns { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Location>().ToTable("Location");
			base.OnModelCreating(modelBuilder);
		}

		
	}
}
