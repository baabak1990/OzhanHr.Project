﻿using Microsoft.EntityFrameworkCore;
using OzhanHr.Domain.Entities.Common;
using OzhanHr.Domain.Entities.Leave;

namespace OzhanItHr.Persistence.Context
{
    public class DefaultDbContext:DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options):base(options)
        {
            
        }
        #region Tabels

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        #endregion
        #region Configurations

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DefaultDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomain>())
            {
                entry.Entity.ModifyDate = DateTime.Now;
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        #endregion
      
    }
}
