using DrugWarehouseManagement_API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DrugWarehouseManagement_API.Data
{
    public class DrugHousewareManagementDbContext: IdentityDbContext<User,Role,Guid>
    {
        public DrugHousewareManagementDbContext(DbContextOptions<DrugHousewareManagementDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
                .HasIndex(p => new { p.UserName})
                .IsUnique(true);
        }
    }
}
