using Microsoft.EntityFrameworkCore;
using SeekWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeekWeb.Data
{
    public class PromotionEngineContext : DbContext
    {
        public PromotionEngineContext(DbContextOptions<PromotionEngineContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<EligibilityCriteria> PromotionCriterias { get; set; }
        public DbSet<Cart> Cart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Ad>().ToTable("Ad");
            modelBuilder.Entity<Promotion>().ToTable("Promotion");
            modelBuilder.Entity<Discount>().ToTable("Discount");
            modelBuilder.Entity<EligibilityCondition>().ToTable("EligibilityCondition");
            modelBuilder.Entity<EligibilityCriteria>().ToTable("EligibilityCriteria");

            modelBuilder.Entity<Cart>().ToTable("Cart");
            modelBuilder.Entity<CartItem>().ToTable("CartItem");
        }
    }
}
