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
        public DbSet<Comment> comment { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=kronikipodwala");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasMany(u=>u.Comments)
                .WithOne(m=>m.Owner)
                .HasForeignKey(m=>m.CommentOwner)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventModel>()
                .HasMany(e=>e.Comments)
                .WithOne(c=>c.Event)
                .HasForeignKey(c=>c.CommentedEvent)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Owner)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.CommentOwner);

            modelBuilder.Entity<Comment>()
                .HasOne(c=>c.Event)
                .WithMany(e=>e.Comments)
                .HasForeignKey(c=>c.CommentedEvent);

            

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventModel>().HasData(new {Id = 1, EventName = "Walentynki", EventDescription = "ABC", EventYear = 2022}, new { Id = 2, EventName = "Walentynki", EventDescription = "ABC", EventYear = 2021}, new { Id = 3, EventName = "Walentynki", EventDescription = "ABC", EventYear = 2020 });

            modelBuilder.Entity<Comment>().HasData(new { Id = 1, Text = "Interesting", isReported = false, CommentOwner = "7dd706b0-b7e3-4020-ad17-d822cd5beee2", CommentedEvent=10 }, new { Id = 2, Text = "Interesting", isReported = false, CommentOwner = "7dd706b0-b7e3-4020-ad17-d822cd5beee2", CommentedEvent = 10 }, new { Id = 3, Text = "Interesting", isReported = false, CommentOwner = "7dd706b0-b7e3-4020-ad17-d822cd5beee2", CommentedEvent = 10 });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
