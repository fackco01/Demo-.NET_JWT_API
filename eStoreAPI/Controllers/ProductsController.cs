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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace eStoreAPI.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _repository = new ProductRepository();

        // GET: api/Products
        [HttpGet, /*Authorize(Roles = "Administrator")*/ AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return _repository.GetProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}"), AllowAnonymous]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = _repository.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}"), Authorize(Roles = "Adminstrator")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            var pTmp = _repository.GetProductById(id);
            if (pTmp == null)
            {
                return NotFound();
            }
            _repository.UpdateProduct(pTmp);

            return Ok();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Authorize(Roles = "Adminstrator")]
        public IActionResult PostProduct(Product product)
        {
            _repository.SaveProduct(product);
            return Ok();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}"), Authorize(Roles = "Adminstrator")]
        public IActionResult DeleteProduct(int id)
        {
            var p = _repository.GetProductById(id);
            if (p == null)
            {
                return NotFound();
            }
            _repository.DeleteProduct(p);

            return Ok();
        }
    }
}
