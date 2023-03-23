using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using webAPI2.Models;

namespace webAPI2.DBContext;

public class DatabaseContext : DbContext
{
    

    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserTable> UserTable { get; set; }

     protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
  }
}
