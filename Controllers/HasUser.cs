using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBroidery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBroidery.Controllers
{
    public class HasUser: ControllerBase
    {
        public IAuthInfo authInfo;
        public IMyBroideryContext context;
        public User user
        {
            get
            {
                return context.Users.Include(r => r.Roles).ThenInclude(r => r.Role).ThenInclude(r => r.Privileges).FirstOrDefault(r => r.Username == authInfo.Username);
            }
        }
    }
}
