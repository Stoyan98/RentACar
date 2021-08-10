using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentACar.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentACar.Data
{
    public class RentACarDbContext : IdentityDbContext<User>
    {
        public RentACarDbContext(DbContextOptions<RentACarDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; init; }
    }
}
