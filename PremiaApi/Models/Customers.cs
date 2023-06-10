using System;
namespace PremiaApi.Models
{
	public class Customers
	{
		public Guid Id { get; set; }
        public String CustomerName { get; set; }
		public Boolean? IsDeleted { get; set; } = false;
        public DateTime? DeleteDate { get; set; }
    }
}

