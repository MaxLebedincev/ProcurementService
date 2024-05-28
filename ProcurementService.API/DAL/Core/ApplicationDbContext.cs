﻿using Microsoft.EntityFrameworkCore;
using ProcurementService.API.DAL.Schemes.Purchase.Files;
using ProcurementService.API.DAL.Schemes.Purchase.Filters;
using ProcurementService.API.DAL.Schemes.Purchase.Products;
using ProcurementService.API.DAL.Schemes.Purchase.Requests;
using ProcurementService.API.DAL.Schemes.Security.Roles;
using ProcurementService.API.DAL.Schemes.Security.Users;
using ProcurementService.API.DAL.Schemes.Security.UsersRoles;

namespace ProcurementService.API.DAL.Core
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new RoleConfiguration())
                .ApplyConfiguration(new UserRoleConfiguration())

                .ApplyConfiguration(new ServerFileConfiguration())
                .ApplyConfiguration(new FilterConfiguration())
                .ApplyConfiguration(new RequestConfiguration())
                .ApplyConfiguration(new ProductConfiguration());
        }
    }
}
