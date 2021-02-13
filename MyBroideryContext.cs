using Microsoft.EntityFrameworkCore;
using MyBroidery.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBroidery
{
    public class MyBroideryContext : DbContext, IMyBroideryContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "Admin"
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 13,
                Name = "Guest"
            });
            modelBuilder.Entity<UserRole>().HasData(new List<UserRole> {
                    new UserRole
                    {
                        Id = 14,
                        RoleId = 13,
                        UserId = 15
                    }
                });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 15,
                Username = "Guest"
            });
            modelBuilder.Entity<RolePrivilege>().HasData(new List<RolePrivilege> {
                    new RolePrivilege
                    {
                        Id = 16,
                        RoleId = 13,
                        Privilege = "own_account_read"
                    },
                    new RolePrivilege
                    {
                        Id = 17,
                        RoleId = 13,
                        Privilege = "account_create"
                    },
                    new RolePrivilege
                    {
                        Id = 18,
                        RoleId = 13,
                        Privilege = "own_account_update"
                    },
                    new RolePrivilege
                    {
                        Id = 19,
                        RoleId = 13,
                        Privilege = "own_account_delete"
                    },
                    new RolePrivilege
                    {
                        Id = 20,
                        RoleId = 13,
                        Privilege = "product_read"
                    },
                    new RolePrivilege
                    {
                        Id = 21,
                        RoleId = 13,
                        Privilege = "product_list"
                    },
                });
            modelBuilder.Entity<RolePrivilege>().HasData(new List<RolePrivilege> {
                    new RolePrivilege
                    {
                        Id = 2,
                        RoleId = 1,
                        Privilege = "account_list"
                    } ,
                    new RolePrivilege
                    {
                        Id = 3,
                        RoleId = 1,
                        Privilege = "product_list"
                    } ,
                    new RolePrivilege
                    {
                        Id = 4,
                        RoleId = 1,
                        Privilege = "product_create"
                    } ,
                    new RolePrivilege
                    {
                        Id = 5,
                        RoleId = 1,
                        Privilege = "product_update"
                    } ,
                    new RolePrivilege
                    {
                        Id = 6,
                        RoleId = 1,
                        Privilege = "product_delete"
                    } ,
                    new RolePrivilege
                    {
                        Id = 7,
                        RoleId = 1,
                        Privilege = "account_delete"
                    } ,
                    new RolePrivilege
                    {
                        Id = 8,
                        RoleId = 1,
                        Privilege = "own_account_read"
                    },
                    new RolePrivilege
                    {
                        Id = 9,
                        RoleId = 1,
                        Privilege = "account_create"
                    },
                    new RolePrivilege
                    {
                        Id = 10,
                        RoleId = 1,
                        Privilege = "own_account_update"
                    },
                    new RolePrivilege
                    {
                        Id = 11,
                        RoleId = 1,
                        Privilege = "own_account_delete"
                    },
                    new RolePrivilege
                    {
                        Id = 12,
                        RoleId = 1,
                        Privilege = "product_read"
                    },
                });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite("Data Source=data.db");

    }
}
