using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PremiaApi.Controllers.Models;
using PremiaApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;
using PremiaApi.Data; 

namespace PremiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
	public class AuthController : Controller 
	{
        private readonly PremiaDbContext dbContext;  

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest addUserRequest)
        {

            if (addUserRequest.Password.Length < 8)
            {
                return BadRequest("Password have to contain at least 8 character");
            }

            var userExists = await dbContext.users.AnyAsync(u => u.UserName == addUserRequest.UserName);
            if (userExists)
            {
                return Conflict(new { message = "There Already exist user " + addUserRequest.UserName });
            }
            var passwordHash = HashPassword(addUserRequest.Password);

            var users = new Users()
            {
                Id = Guid.NewGuid(),
                UserName = addUserRequest.UserName,
                Name = addUserRequest.Name,
                UserSurname = addUserRequest.UserSurname,
                Password = passwordHash,
                Email = addUserRequest.Email,
                CreateDate = addUserRequest.CreateDate,
                IsSuperUser = addUserRequest.IsSuperUser,
                IsSupervisor = addUserRequest.IsSupervisor,
                IsNormalUser = addUserRequest.IsNormalUser,
            };

            await dbContext.users.AddAsync(users);
            await dbContext.SaveChangesAsync();

            return Ok(users);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        private static string tokenKey;
        private static DateTime tokenKeyLastChanged;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest loginRequest)
        {
            var user = await dbContext.users.SingleOrDefaultAsync(u => u.UserName == loginRequest.UserName);
            if (user == null)
            {
                return Unauthorized();
            }
            var hashedPassword = HashPassword(loginRequest.Password);
            if (user.Password != hashedPassword)
            {
                return Unauthorized();
            }

            if ((DateTime.UtcNow - tokenKeyLastChanged).TotalHours >= 3)
            {
                var key = new byte[64];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(key);
                }
                tokenKey = Convert.ToBase64String(key);
                tokenKeyLastChanged = DateTime.UtcNow;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var keyBytes = Convert.FromBase64String(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            loginRequest.Token = tokenString;
            loginRequest.TokenExpire = DateTime.UtcNow.AddHours(3);

            return Ok(new { Token = tokenString });
        }


    }
}

