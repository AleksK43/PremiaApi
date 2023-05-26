using System;
namespace PremiaApi.Models
{
	public class LoginRequest
	{

        public string UserName { get; set; }

        public string? Name { get;  }

        public string Password { get; set; }

        public bool IsSuperUser { get; }

        public bool IsSupervisor { get; }

        public bool IsNormalUser { get; }

        public string? Token { get; set; }

        public DateTime? TokenExpire { get; set; }

    }

}

