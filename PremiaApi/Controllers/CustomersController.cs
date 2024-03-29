﻿using System;
using Microsoft.AspNetCore.Mvc;
using PremiaApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using PremiaApi.Controllers.Models;
using PremiaApi.Models;
using Microsoft.AspNetCore.Authorization;


namespace PremiaApi.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class CustomersController :  Controller
	{
		private readonly PremiaDbContext dbContext; 
		public CustomersController(PremiaDbContext dbContext)
		{
			this.dbContext =  dbContext; 
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCustomers()
		{
			return Ok(await dbContext.customers.ToListAsync()); 
		}

		[HttpPost]
		public async Task<IActionResult> AddCustomer(AddCustomerRequest addCustomerRequest)
		{
			var customers = new Customers()
			{
				Id = Guid.NewGuid(),
				CustomerName = addCustomerRequest.CustomerName
			};
            await dbContext.customers.AddAsync(customers);
            await dbContext.SaveChangesAsync();

            return Ok(customers);
		}

		[HttpPut]
		[Route("{id:guid}")]
		public async Task<IActionResult> UpdateCustomer([FromRoute] Guid id, UpdateCustomerRequest updateCustomerRequest)
		{
			var customer = await dbContext.customers.FindAsync(id);
			if (customer != null )
			{
				customer.CustomerName = updateCustomerRequest.CustomerName;
				customer.IsDeleted = updateCustomerRequest.IsDeleted;
                customer.UserGuid = updateCustomerRequest.UserGuid;

				await dbContext.SaveChangesAsync();
				return Ok(customer);
			}
			return NotFound(); 
		}

		[HttpDelete]
		[Route("{id:guid}")]
		public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
		{
			var customer = await dbContext.customers.FindAsync(id);

			if (customer != null )
			{
				dbContext.Remove(customer);
				customer.DeleteDate = DateTime.Now;
				customer.IsDeleted = true;
				await dbContext.SaveChangesAsync();
				return Ok("Customer Deleted");
			}
			return NotFound(); 
		}



	}
}

