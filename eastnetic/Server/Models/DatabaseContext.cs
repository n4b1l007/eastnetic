﻿using eastnetic.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace eastnetic.Server.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
    }
}