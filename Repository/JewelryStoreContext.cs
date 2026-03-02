using System;
using System.Collections.Generic;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public partial class JewelryStoreContext : DbContext
{
    public JewelryStoreContext()
    {
    }

    public JewelryStoreContext(DbContextOptions<JewelryStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=JewelryStore;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CaregoryId);

            entity.Property(e => e.CategoryName)
                .HasMaxLength(40)
                .IsFixedLength();
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(60)
                .IsFixedLength();

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_User");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItem_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItem_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.Image1)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Image2)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.ProductName)
                .HasMaxLength(40)
                .IsFixedLength();
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasOne(d => d.Product).WithMany(p => p.Sizes)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Size_Product");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Street)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
