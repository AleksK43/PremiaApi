using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PremiaApi.Data;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IActionResult GetAllUsers()
        {
            return Ok(dbContext.users.ToList()); 
        }

        [HttpPost]
        public IActionResult AddUser()
        {

        }
    }
}

