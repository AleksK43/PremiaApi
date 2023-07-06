using System;
namespace PremiaApi.Models
{
	public class CustomersRaportDetails
	{
		public Guid Id { get; set; }
		public Guid CustomerGuid { get; set; }
		public bool IsRaportDone { get; set; }
		public bool IsRaportOk { get; set; }
		public bool IsInvoiceDone { get; set; }
		public string? Comment { get; set; }
		public Guid ProjectOwner { get; set; }
	}
}

