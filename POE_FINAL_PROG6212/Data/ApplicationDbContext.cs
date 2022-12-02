using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using POE_FINAL_PROG6212.Models;

namespace POE_FINAL_PROG6212.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<POE_FINAL_PROG6212.Models.Semester> Semester { get; set; }
        public DbSet<POE_FINAL_PROG6212.Models.Module> Module { get; set; }
    }
}
