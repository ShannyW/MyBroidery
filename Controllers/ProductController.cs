using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBroidery.Entities;
using System.Web.Http.Cors;

namespace MyBroidery.Controllers
{
    [System.Web.Http.Cors.DisableCors] // tune to your needs
    [Route("api/Products")]
    [ApiController]
    public class ProductController : HasUser, IEntityController<Product>
    {
        public ProductController(IMyBroideryContext context, IAuthInfo authInfo)
        {
            this.context = context;
            this.authInfo = authInfo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult<Product>> Add(Product product)
        {
            if (!user.HasPrivilege("product_create"))
            {
                return StatusCode(403);
            }
            var timeCreated = DateTime.Now;
            await context.Products.AddAsync(new Product
            {
                Name = product.Name,
                Description = product.Description,
                Image = product.Image,
                Price = product.Price,
                Created = timeCreated,
                CreatedById = 1
            });
            await context.SaveChangesAsync();
            return Ok(product);
        }
        [HttpPost("Update")]
        public async Task<ActionResult<Product>> Update(Product product)
        {
            if (!user.HasPrivilege("product_update"))
            {
                return StatusCode(403);
            }
            context.Update(product);
            await context.SaveChangesAsync();
            return Ok(product);
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> Delete(int productId)
        {
            if (!user.HasPrivilege("product_delete"))
            {
                return StatusCode(403);
            }
            context.Products.Remove(context.Products.First(k => k.Id == productId));
            await context.SaveChangesAsync();
            return Ok(true);
        }
        [HttpGet("{key}")]
        public async Task<ActionResult<Product>> Get(int key)
        {
            if (!user.HasPrivilege("product_read"))
            {
                return StatusCode(403);
            }
            return Ok(context.Products.FirstOrDefault(r=>r.Id==key));
        }
        public async Task<ActionResult<IEnumerable<Product>>> Index()
        {
            if (!user.HasPrivilege("product_list"))
            {
                return StatusCode(403);
            }
            return Ok(await context.Products.ToListAsync());
        }
    }
}
