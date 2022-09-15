using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RestaurantProject1.Models
{
    public partial class restaurantdbContext : DbContext
    {
        public restaurantdbContext()
        {
        }

        public restaurantdbContext(DbContextOptions<restaurantdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Csvview> Csvviews { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Customerorder> Customerorders { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Restaurantmenu> Restaurantmenus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("Server=localhost;port=3306;user=root;password=12345;database=restaurantdb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Csvview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("csvview");

                entity.Property(e => e.MostPurchasedCustomer).HasMaxLength(511);

                entity.Property(e => e.NumberOfOrderedCustomer).HasColumnType("decimal(32,0)");

                entity.Property(e => e.ProfitInNis).HasColumnType("decimal(42,2)");

                entity.Property(e => e.ProfitInUsd).HasColumnType("decimal(42,2)");

                entity.Property(e => e.RestaurantName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.TheBestSellingMeal).HasMaxLength(255);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Archived).HasColumnType("tinyint");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<Customerorder>(entity =>
            {
                entity.ToTable("customerorder");

                entity.HasIndex(e => e.CustmerId, "custmerOrder_idx");

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.MealId, "mealId_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustmerId).HasColumnName("custmerId");

                entity.Property(e => e.MealId).HasColumnName("mealId");

                entity.HasOne(d => d.Custmer)
                    .WithMany(p => p.Customerorders)
                    .HasForeignKey(d => d.CustmerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("custmerId");

                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.Customerorders)
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("mealId");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("restaurant");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Archived).HasColumnType("tinyint");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Restaurantmenu>(entity =>
            {
                entity.ToTable("restaurantmenu");

                entity.HasIndex(e => e.Id, "Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.RestaurantId, "restarentId_menu_idx");

                entity.Property(e => e.Archived).HasColumnType("tinyint");

                entity.Property(e => e.MealName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PriceInNis).HasColumnType("decimal(10,2)");

                entity.Property(e => e.PriceInUsd).HasColumnType("decimal(10,2)");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Restaurantmenus)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restarentId_menu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
