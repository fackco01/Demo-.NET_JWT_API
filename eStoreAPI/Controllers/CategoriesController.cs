using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Context;
using BusinessObject.Model;
using DataAccess.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace eStoreAPI.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICaegoryRepository _repository = new CaegoryRepository();

        // GET: api/Categories
        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return _repository.GetCategories();
        }

        // GET: api/Categories/5
        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = _repository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize(Roles = "Adminstrator")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            var cTmp = _repository.GetCategoryById(id);
            if (cTmp == null)
            {
                return NotFound();
            }
            _repository.UpdateCategory(cTmp);

            return Ok();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize(Roles = "Adminstrator")]
        public IActionResult PostCategory(Category category)
        {
            _repository.SaveCategory(category);
            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}"), Authorize(Roles = "Adminstrator")]
        public IActionResult DeleteCategory(int id)
        {
            var category = _repository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            _repository.DeleteCategory(category);

            return Ok();
        }
    }
}
