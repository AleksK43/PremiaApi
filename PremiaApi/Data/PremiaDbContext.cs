using System;
using Microsoft.EntityFrameworkCore;
using PremiaApi.Controllers.Models;
using PremiaApi.Models;

namespace PremiaApi.Data
{
	public class PremiaDbContext : DbContext
	{
		public PremiaDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Users> users { get; set; }

		public DbSet<Documents> documents { get; set; }

		public DbSet<Customers> customers { get; set; }

	}
}

