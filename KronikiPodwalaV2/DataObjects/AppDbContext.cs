using System;
using System.Collections.Generic;
using System.ComponentModel;
using KronikiPodwalaV2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KronikiPodwalaV2.DataObjects
{
    public partial class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<EventModel> eventModel {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=kronikipodwala");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventModel>().HasData(new {Id = 1, EventName = "Walentynki", EventDescription = "ABC", EventYear = 2022}, new { Id = 2, EventName = "Walentynki", EventDescription = "ABC", EventYear = 2021}, new { Id = 3, EventName = "Walentynki", EventDescription = "ABC", EventYear = 2020 });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
