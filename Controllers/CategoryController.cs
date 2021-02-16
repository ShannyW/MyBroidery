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
    [Route("api/Categories")]
    [ApiController]
    public class CategoryController : HasUser, IEntityController<Category>
    {
        public CategoryController(IMyBroideryContext context, IAuthInfo authInfo)
        {
            this.context = context;
            this.authInfo = authInfo;
        }
        [HttpPost("Add")]
        public async Task<ActionResult<Category>> Add(Category category)
        {
            if (!user.HasPrivilege("category_create"))
            {
                return StatusCode(403);
            }
            var timeCreated = DateTime.Now;
            await context.Categories.AddAsync(new Category
            {
                Name = category.Name
            });
            await context.SaveChangesAsync();
            return Ok(category);
        }
        [HttpPost("Update")]
        public async Task<ActionResult<Category>> Update(Category category)
        {
            if (!user.HasPrivilege("category_update"))
            {
                return StatusCode(403);
            }
            context.Update(category);
            await context.SaveChangesAsync();
            return Ok(category);
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> Delete(int categoryId)
        {
            if (!user.HasPrivilege("category_delete"))
            {
                return StatusCode(403);
            }
            context.Categories.Remove(context.Categories.First(k => k.Id == categoryId));
            await context.SaveChangesAsync();
            return Ok(true);
        }
        [HttpGet("{key}")]
        public async Task<ActionResult<Category>> Get(int key)
        {
            if (!user.HasPrivilege("category_read"))
            {
                return StatusCode(403);
            }
            return Ok(context.Categories.FirstOrDefault(r => r.Id == key));
        }
        public async Task<ActionResult<IEnumerable<Category>>> Index()
        {
            if (!user.HasPrivilege("category_list"))
            {
                return StatusCode(403);
            }
            return Ok(await context.Categories.ToListAsync());
        }
    }
}
