using System;
namespace PremiaApi.Models
{
	public class Documents
	{
		public Guid Id { get; set;  }

		public string Customer { get; set; }

		public string InvoiceNumber { get; set; }

		public string Type { get; set; }

		public string InvoiceOwner { get; set; }

		public string CaseNumber { get; set; }

		public double Income { get; set; }

		public float TimeConsuming { get; set; }

		public double? Drive { get; set; }

		public int Month { get; set; }

		public bool InvoiceStatus { get; set; }

		public bool IsBonusCleared { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime SettlementDate { get; set; }

		public DateTime ModifyDate { get; set; }

	}
}

