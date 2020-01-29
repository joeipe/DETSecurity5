using DETSecurity5.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace DETSecurity5.Data
{
    public class DETSecurity5Context : IdentityDbContext<StoreUser>
    {
        public DETSecurity5Context(DbContextOptions<DETSecurity5Context> options)
            : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
    }
}
