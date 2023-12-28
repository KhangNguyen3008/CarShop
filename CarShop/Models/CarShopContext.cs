using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Models;

public partial class CarShopContext : DbContext
{
    public CarShopContext()
    {
    }

    public CarShopContext(DbContextOptions<CarShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarAdministrator> CarAdministrators { get; set; }

    public virtual DbSet<CarCart> CarCarts { get; set; }

    public virtual DbSet<CarCategory> CarCategories { get; set; }

    public virtual DbSet<CarCustomer> CarCustomers { get; set; }

    public virtual DbSet<CarDealer> CarDealers { get; set; }

    public virtual DbSet<CarOrder> CarOrders { get; set; }

    public virtual DbSet<CarProduct> CarProducts { get; set; }

    public virtual DbSet<CarStoreOwner> CarStoreOwners { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS; Database=CarShop; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarAdministrator>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__CarAdmin__AD0500868CA1DE3C");

            entity.ToTable("CarAdministrator");

            entity.Property(e => e.AdminId)
                .HasMaxLength(20)
                .HasColumnName("adminID");
            entity.Property(e => e.AdminDetail)
                .HasMaxLength(300)
                .HasColumnName("adminDetail");
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(300)
                .HasColumnName("adminEmail");
            entity.Property(e => e.AdminName)
                .HasMaxLength(300)
                .HasColumnName("adminName");
            entity.Property(e => e.AdminPassword)
                .HasMaxLength(300)
                .HasColumnName("adminPassword");
        });

        modelBuilder.Entity<CarCart>(entity =>
        {
            entity.HasKey(e => new { e.CarId, e.CustomerId, e.OrderId }).HasName("pk_customercart");

            entity.ToTable("CarCart");

            entity.Property(e => e.CarId)
                .HasMaxLength(20)
                .HasColumnName("carID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(300)
                .HasColumnName("customerID");
            entity.Property(e => e.OrderId)
                .HasMaxLength(20)
                .HasColumnName("orderID");

            entity.HasOne(d => d.Order).WithMany(p => p.CarCarts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cartorder");
        });

        modelBuilder.Entity<CarCategory>(entity =>
        {
            entity.HasKey(e => e.CatId).HasName("PK__CarCateg__17B6DD261B5CC494");

            entity.ToTable("CarCategory");

            entity.HasIndex(e => e.CatName, "UQ__CarCateg__14D6C89BC9D441B5").IsUnique();

            entity.Property(e => e.CatId).HasColumnName("catID");
            entity.Property(e => e.CatDetail)
                .HasMaxLength(300)
                .HasColumnName("catDetail");
            entity.Property(e => e.CatName)
                .HasMaxLength(300)
                .HasColumnName("catName");
        });

        modelBuilder.Entity<CarCustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__CarCusto__B611CB9D12CC0143");

            entity.ToTable("CarCustomer");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .HasColumnName("customerID");
            entity.Property(e => e.AdminId)
                .HasMaxLength(20)
                .HasColumnName("adminID");
            entity.Property(e => e.CusormerImage)
                .HasMaxLength(300)
                .HasColumnName("cusormerImage");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(300)
                .HasColumnName("customerAddress");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(300)
                .HasColumnName("customerEmail");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(300)
                .HasColumnName("customerName");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(300)
                .HasColumnName("customerPhone");

            entity.HasOne(d => d.Admin).WithMany(p => p.CarCustomers)
                .HasForeignKey(d => d.AdminId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_admincustomer");
        });

        modelBuilder.Entity<CarDealer>(entity =>
        {
            entity.HasKey(e => e.DealerId).HasName("PK__CarDeale__5A9E9DB6B9FFD878");

            entity.ToTable("CarDealer");

            entity.HasIndex(e => e.DealerName, "UQ__CarDeale__E18CE607F19DB9B6").IsUnique();

            entity.Property(e => e.DealerId)
                .HasMaxLength(20)
                .HasColumnName("dealerID");
            entity.Property(e => e.DealerAddress)
                .HasMaxLength(300)
                .HasColumnName("dealerAddress");
            entity.Property(e => e.DealerDetail)
                .HasMaxLength(300)
                .HasColumnName("dealerDetail");
            entity.Property(e => e.DealerLogo)
                .HasMaxLength(300)
                .HasColumnName("dealerLogo");
            entity.Property(e => e.DealerName)
                .HasMaxLength(300)
                .HasColumnName("dealerName");
        });

        modelBuilder.Entity<CarOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__CarOrder__0809337D3A023DFF");

            entity.ToTable("CarOrder");

            entity.Property(e => e.OrderId)
                .HasMaxLength(20)
                .HasColumnName("orderID");
            entity.Property(e => e.CarId)
                .HasMaxLength(20)
                .HasColumnName("carID");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(20)
                .HasColumnName("customerID");
            entity.Property(e => e.OrderDetail)
                .HasMaxLength(300)
                .HasColumnName("orderDetail");
            entity.Property(e => e.OrderName)
                .HasMaxLength(300)
                .HasColumnName("orderName");

            entity.HasOne(d => d.Car).WithMany(p => p.CarOrders)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_productorder");

            entity.HasOne(d => d.Customer).WithMany(p => p.CarOrders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_cusorder");
        });

        modelBuilder.Entity<CarProduct>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__CarProdu__1436F094B4009A20");

            entity.ToTable("CarProduct");

            entity.Property(e => e.CarId)
                .HasMaxLength(20)
                .HasColumnName("carID");
            entity.Property(e => e.CarDetail)
                .HasMaxLength(300)
                .HasColumnName("carDetail");
            entity.Property(e => e.CarImage)
                .HasMaxLength(300)
                .HasColumnName("carImage");
            entity.Property(e => e.CarName)
                .HasMaxLength(300)
                .HasColumnName("carName");
            entity.Property(e => e.Carprice).HasColumnName("carprice");
            entity.Property(e => e.CatId).HasColumnName("catID");
            entity.Property(e => e.DealerId)
                .HasMaxLength(20)
                .HasColumnName("dealerID");
            entity.Property(e => e.OwnerId)
                .HasMaxLength(20)
                .HasColumnName("ownerID");

            entity.HasOne(d => d.Cat).WithMany(p => p.CarProducts)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dealercustomer");

            entity.HasOne(d => d.Dealer).WithMany(p => p.CarProducts)
                .HasForeignKey(d => d.DealerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dealerproduct");

            entity.HasOne(d => d.Owner).WithMany(p => p.CarProducts)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ownerproduct");
        });

        modelBuilder.Entity<CarStoreOwner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__CarStore__7E4B716CDB06153E");

            entity.ToTable("CarStoreOwner");

            entity.Property(e => e.OwnerId)
                .HasMaxLength(20)
                .HasColumnName("ownerID");
            entity.Property(e => e.OwnerAddress)
                .HasMaxLength(300)
                .HasColumnName("ownerAddress");
            entity.Property(e => e.OwnerDetail)
                .HasMaxLength(300)
                .HasColumnName("ownerDetail");
            entity.Property(e => e.OwnerName)
                .HasMaxLength(300)
                .HasColumnName("ownerName");
            entity.Property(e => e.OwnerPassword)
                .HasMaxLength(300)
                .HasColumnName("ownerPassword");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
