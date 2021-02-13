using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using MyBroidery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBroidery
{
    public class SecurityContext : ISecurityContext

    {
        IMyBroideryContext context;
        public SecurityContext(IMyBroideryContext context)
        {
            this.context = context;
        }
        public User GetUser(string token)
        {
            var tokens = context.Tokens.Include(r=>r.User).ToList();
            return context.Tokens.Include(r => r.User).FirstOrDefault(r => r.Content == token && r.Expires < DateTimeOffset.Now)?.User ??
                context.Users.FirstOrDefault(r => r.Username == "Guest");
        }
    }
    public class AuthInfo : IAuthInfo
    {
        public string Username { get; set;}
        public int UserId { get; set;}
        public string Token { get; set;}
    }
}

