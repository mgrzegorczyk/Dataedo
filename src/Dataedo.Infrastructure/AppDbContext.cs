﻿using Dataedo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Dataedo.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}