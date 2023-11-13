using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Context;
using BusinessObject.Model.Authen;
using Microsoft.AspNetCore.Cors;
using DataAccess.Repository;
using eStoreAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace eStoreAPI.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository = new UserRepository();
        private readonly StoreService service = new StoreService();

        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult GetUserById(string id)
        {
            return Ok(_repository.GetUserById(new Guid(id)));
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public void UpdateUser(string id, User user)
        {
            _repository.UpdateUser(new Guid(service.DecryptString(Uri.UnescapeDataString(id), _configuration)), user);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult Register(User user)
        {
            _repository.CreateUser(user);
            return Ok();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = _repository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            _repository.DeleteUser(user);

            return NoContent();
        }
    }
}
