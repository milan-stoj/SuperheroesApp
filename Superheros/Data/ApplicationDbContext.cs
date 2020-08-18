using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Superheros.Models;

namespace Superheros.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        DbSet<Superhero> Superhero { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
