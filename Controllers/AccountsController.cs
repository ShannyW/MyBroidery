using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBroidery.Entities;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace MyBroidery.Controllers
{
    [Route("api/Accounts")]
    [ApiController]
    public class AccountsController : HasUser, IEntityController<User>
    {
        public AccountsController(IMyBroideryContext context, IAuthInfo authInfo)
        {
            this.context = context;
            this.authInfo = authInfo;
        }
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(User login) {
            byte[] salt = Encoding.ASCII.GetBytes("sdlkfjasdfasdfasdfsdfdsfsdfasdffasd");
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: login.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            var successfulLogin = await (from User in context.Users where User.Username == login.Username && User.Password == hashed select User).FirstOrDefaultAsync();
            if (successfulLogin!=null)
            {
                var expiryTime = DateTime.Now.AddDays(1);
                var createdTime = DateTime.Now;
                var token = new Token
                {
                    Content = RandomString(24),
                    UserId = successfulLogin.Id,
                    Expires = expiryTime,
                    Created = createdTime
                };
                context.Tokens.Add(token);
                await context.SaveChangesAsync();
                return Ok(token);
            }
            else
            {
                return StatusCode(401, login);
            }
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Add(User register)
        {
            if (!user.HasPrivilege("account_create"))
            {
                return StatusCode(403);
            }
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = Encoding.ASCII.GetBytes("sdlkfjasdfasdfasdfsdfdsfsdfasdffasd");
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: register.Password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            var users = from User in context.Users where User.Username == hashed select User;
            if (users.Count() == 0)
            {
                await context.Users.AddAsync(new User
                {
                    Username = register.Username,
                    Password = hashed,
                });
                await context.SaveChangesAsync();
                return Ok(register);
            }
            else
            {
                return StatusCode(401, register);
            }
        }
        public async Task<ActionResult<IEnumerable<User>>> Index() {
            if (!user.HasPrivilege("account_list"))
            {
                return StatusCode(403);
            }
            return Ok(await context.Users.ToListAsync());
        }
        [HttpPost("Update")]
        public async Task<ActionResult<User>> Update(User entity)
        {
            if (!user.HasPrivilege("account_update"))
            {
                return StatusCode(403);
            }
            context.Update(entity);
            await context.SaveChangesAsync();
            return Ok(entity);
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<bool>> Delete(int entityId)
        {
            if (!user.HasPrivilege("account_delete"))
            {
                return StatusCode(403);
            }
            context.Users.Remove(context.Users.First(k => k.Id == entityId));
            await context.SaveChangesAsync();
            return Ok(true);
        }
        [HttpGet("{key}")]
        public async Task<ActionResult<User>> Get(int key)
        {
            if (!user.HasPrivilege("account_read"))
            {
                return StatusCode(403);
            }
            return Ok(context.Users.FirstOrDefault(r => r.Id == key));
        }
        [HttpGet("Me")]
        public async Task<ActionResult<User>> Me() 
        {
            return Ok(context.Users.FirstOrDefault(r => r.Username == authInfo.Username));
        }
    }
}
