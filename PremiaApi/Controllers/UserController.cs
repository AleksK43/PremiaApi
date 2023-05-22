using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PremiaApi.Controllers.Models;
using PremiaApi.Data;
using PremiaApi.Models; 

namespace PremiaApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly PremiaDbContext dbContext;

        public UserController(PremiaDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await dbContext.users.ToListAsync()); 
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await dbContext.users.FindAsync(id);

            if (user == null)
            {
                return NotFound(); 
            }
            return Ok(user); 
        }

        

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUserRequest updateUserRequest )
        {
            var user = await dbContext.users.FindAsync(id);

            if ( user != null )
            {
                user.UserName = updateUserRequest.UserName;
                user.Name = updateUserRequest.Name;  
                user.UserSurname = updateUserRequest.UserSurname;
                user.Email = updateUserRequest.Email;
                user.IsSuperUser = updateUserRequest.IsSuperUser;
                user.IsSupervisor = updateUserRequest.IsSupervisor;
                user.IsNormalUser = updateUserRequest.IsNormalUser;
                user.isDeleted = updateUserRequest.isDeleted;

                await dbContext.SaveChangesAsync();

                return Ok(user); 

            }

            return NotFound(); 

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeeteUser([FromRoute] Guid id)
        {
            var user = await dbContext.users.FindAsync(id);

            if (user != null)
            {
                dbContext.Remove(user);
                await dbContext.SaveChangesAsync();
                return Ok("Thiss User Was Deleted"); 
            }

            return NotFound(); 

        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}

