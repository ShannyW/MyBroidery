using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyBroidery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBroidery
{
    public interface IEntityController<T> where T : class
    {
        public Task<ActionResult<T>> Add(T entity);
        public Task<ActionResult<T>> Update(T entity);
        public Task<ActionResult<bool>> Delete(int entityId);
        public Task<ActionResult<T>> Get(int key);
        public Task<ActionResult<IEnumerable<T>>> Index();
    }
    public interface IMyBroideryContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public Task<int> SaveChangesAsync();
        public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
    }
    public interface IAuthInfo
    {
        public string Username { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
    }
    public interface ISecurityContext
    {
        public User GetUser(string token);
    }
}
