using System;
namespace PremiaApi.Models
{
	public class AddUserRequest
	{
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string UserSurname { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsSuperUser { get; set; }

        public bool IsSupervisor { get; set; }

        public bool IsNormalUser { get; set; }

        public bool isDeleted { get; set; }


    }
}

