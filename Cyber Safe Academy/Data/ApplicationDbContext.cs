
using Cyber_Safe_Academy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cyber_Safe_Academy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TrainingModule> TrainingModules { get; set; }
        public DbSet<TrainingModuleMaterial> TrainingModuleMaterials { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between TrainingModule and TrainingModuleMaterial entities
            modelBuilder.Entity<TrainingModule>()
                .HasMany(tm => tm.Materials)
                .WithOne(tmm => tmm.TrainingModule)
                .HasForeignKey(tmm => tmm.TrainingModuleId);
        }
        public DbSet<Cyber_Safe_Academy.Models.Quiz> Quiz { get; set; }

    }
}
