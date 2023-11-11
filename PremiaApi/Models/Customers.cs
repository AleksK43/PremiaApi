using System;
namespace PremiaApi.Models
{
	public class Customers
	{
		public Guid Id { get; set; }
        public string CustomerName { get; set; }
		public bool IsDeleted { get; set; } = false;
		public DateTime DeleteDate { get; set; } 
		public string UserGuid { get; set; } = "";
    }
}

