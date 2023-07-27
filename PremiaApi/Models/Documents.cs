using System;
namespace PremiaApi.Models
{
	public class Documents
	{
		public Guid Id { get; set; }

		public string Customer { get; set; }

		public string InvoiceNumber { get; set; }

		public string Type { get; set; }

		public Guid InvoiceOwner { get; set; }

		public string CaseNumber { get; set; }

		public double Income { get; set; }

		public float TimeConsuming { get; set; }

		public double? Drive { get; set; }

		public int Month { get; set; }

		public string InvoiceStatus { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime SettlementDate { get; set; }

		public DateTime ModifyDate { get; set; }

		public bool? NewInvoice { get; set; }

		public bool? PreAccept { get; set; }

		public bool? Accepted { get; set; }

	}
}

