using Microsoft.EntityFrameworkCore;
using System;

namespace Travel_Website_Backend.Data

{
    public class AppDbContext : DbContext
    { 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Admin> Admins { get; set; }
    }
}
