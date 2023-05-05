using System;
using Microsoft.EntityFrameworkCore;
using PremiaApi.Controllers.Models; 

namespace PremiaApi.Data
{
	public class PremiaDbContext :DbContext
	{
		public PremiaDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Users>users { get; set; }
	}
}

