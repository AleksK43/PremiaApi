using System;
namespace PremiaApi.Models
{
	public class LoginRequest
	{
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public bool IsSuperUser { get; }

        public bool IsSupervisor { get; }

        public bool IsNormalUser { get; }

    }

}

