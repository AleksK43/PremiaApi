using System;
namespace PremiaApi.Controllers.Models
{
	public class Users
	{
        
        public Guid Id { get; set;}

		public string UserName { get; set; }

        public string Name { get; set; }

        public string UserSurname { get; set; }

        public string Password { get; set; }

		public string Email { get; set; }

		public bool isDeleted { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime DeleteDate { get; set; }

		public bool IsSuperUser { get; set; }

		public bool IsSupervisor { get; set; }

		public bool IsNormalUser { get; set; }

		public string Role { get; set; }

    }
}

