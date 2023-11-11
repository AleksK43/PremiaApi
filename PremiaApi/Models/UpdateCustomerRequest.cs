using System;
namespace PremiaApi.Models
{
	public class UpdateCustomerRequest
	{
        public String CustomerName { get; set; }
        public Boolean IsDeleted { get; set; } = false;
        public DateTime DeleteDate { get; set; }
        public string UserGuid { get; set; } = null; 
    }
}

