using System;
using PremiaApi.Services;
using Microsoft.AspNetCore.Mvc;
using PremiaApi.Data;
using PremiaApi.Models;
 
namespace PremiaApi.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class ProfitController : Controller
	{

		private readonly PremiaDbContext dbContext; 
		public ProfitController( PremiaDbContext dbContext)
		{
			this.dbContext = dbContext;
		}


        [HttpGet("{invoiceOwner:guid}")]
        public IActionResult GetUserProfit(Guid invoiceOwner)
        {
            UserBonusSummary bonusSummary = new UserBonusSummary(invoiceOwner, dbContext);
            double profit = bonusSummary.Profit;

            return Ok(new { Profit = profit });
        }



    }
}

