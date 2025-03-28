﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SFT.Models;

namespace SFT.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Purchase> Purchases { get; set; } 
    }
}
// AppDbContext and UserManager<User> are injected via constructor
// Demonstrates the Dependency Inversion Principle