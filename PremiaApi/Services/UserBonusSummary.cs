using System;
using PremiaApi.Models;
using PremiaApi.Controllers;
using PremiaApi.Data; 

namespace PremiaApi.Services
{
	
	public class UserBonusSummary
	{
        private readonly PremiaDbContext dbContext;
        public double Profit { get; }

        public UserBonusSummary( Guid id, PremiaDbContext dbContext )
        {
            
            double profit = 0; 
			this.dbContext = dbContext;

			var documents = dbContext.documents.Where(documents => documents.InvoiceOwner == id).ToList();

			if (documents.Count > 0)
			{

				foreach (var document in documents)
				{
					if (document.NewInvoice == true)
					{
						profit += document.Income;
					}
					else
					{
						continue;
					}
				}
			}

			Profit = profit * 0.05;
		}
	}
}


