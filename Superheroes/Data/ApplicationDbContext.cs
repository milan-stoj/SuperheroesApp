﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Superheroes.Models;

namespace Superheroes.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Superhero> Superhero { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
