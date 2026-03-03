using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities;

public partial class TempContext : DbContext
{
    public TempContext()
    {
    }

    public TempContext(DbContextOptions<TempContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asset3D> Asset3Ds { get; set; }

    public virtual DbSet<AssetVersion> AssetVersions { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<CreativeOrder> CreativeOrders { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<MarketplaceOrder> MarketplaceOrders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductionStage> ProductionStages { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<ServicePackage> ServicePackages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BOSS\\SQLEXPRESS;Database=ImmersiveVisionary;User Id=sa;Password=12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asset3D>(entity =>
        {
            entity.HasKey(e => e.AssetId).HasName("PK__Asset3D__434923526DBA72B3");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.IsMarketplace).HasDefaultValue(false);
            entity.Property(e => e.PublishStatus).HasDefaultValue("DRAFT");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Asset3Ds)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asset3D__Created__656C112C");

            entity.HasOne(d => d.Order).WithMany(p => p.Asset3Ds)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Asset3D__OrderId__6477ECF3");

            entity.HasOne(d => d.OwnerCompany).WithMany(p => p.Asset3Ds).HasConstraintName("FK__Asset3D__OwnerCo__66603565");
        });

        modelBuilder.Entity<AssetVersion>(entity =>
        {
            entity.HasKey(e => e.VersionId).HasName("PK__AssetVer__16C6400F9C4C24EE");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Asset).WithMany(p => p.AssetVersions).HasConstraintName("FK__AssetVers__Asset__6B24EA82");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CAC58DBD972");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Status).HasDefaultValue("ACTIVE");
        });

        modelBuilder.Entity<CreativeOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Creative__C3905BCF90059C79");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Status).HasDefaultValue("NEW");

            entity.HasOne(d => d.Company).WithMany(p => p.CreativeOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CreativeO__Compa__534D60F1");

            entity.HasOne(d => d.Package).WithMany(p => p.CreativeOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CreativeO__Packa__5535A963");

            entity.HasOne(d => d.Product).WithMany(p => p.CreativeOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CreativeO__Produ__5441852A");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PK__Delivery__626D8FCEFD363899");

            entity.HasOne(d => d.Asset).WithMany(p => p.Deliveries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Delivery__AssetI__787EE5A0");

            entity.HasOne(d => d.Order).WithMany(p => p.Deliveries).HasConstraintName("FK__Delivery__OrderI__778AC167");
        });

        modelBuilder.Entity<MarketplaceOrder>(entity =>
        {
            entity.HasKey(e => e.MpOrderId).HasName("PK__Marketpl__D16846928FA68FEC");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Asset).WithMany(p => p.MarketplaceOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Marketpla__Asset__7D439ABD");

            entity.HasOne(d => d.BuyerCompany).WithMany(p => p.MarketplaceOrderBuyerCompanies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Marketpla__Buyer__7E37BEF6");

            entity.HasOne(d => d.SellerCompany).WithMany(p => p.MarketplaceOrderSellerCompanies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Marketpla__Selle__7F2BE32F");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A38881238AC");

            entity.Property(e => e.PaymentStatus).HasDefaultValue("PENDING");

            entity.HasOne(d => d.Asset).WithMany(p => p.Payments).HasConstraintName("FK__Payment__AssetId__72C60C4A");

            entity.HasOne(d => d.Company).WithMany(p => p.Payments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Payment__Company__73BA3083");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments).HasConstraintName("FK__Payment__OrderId__71D1E811");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD5E683DBD");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Company).WithMany(p => p.Products).HasConstraintName("FK__Product__Company__4AB81AF0");
        });

        modelBuilder.Entity<ProductionStage>(entity =>
        {
            entity.HasKey(e => e.StageId).HasName("PK__Producti__03EB7AD85298F4C6");

            entity.Property(e => e.Status).HasDefaultValue("PENDING");

            entity.HasOne(d => d.AssignedToNavigation).WithMany(p => p.ProductionStages)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Productio__Assig__5BE2A6F2");

            entity.HasOne(d => d.Order).WithMany(p => p.ProductionStages).HasConstraintName("FK__Productio__Order__5AEE82B9");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.RefreshTokenId).HasName("PK__RefreshT__F5845E39FA7F3402");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RefreshToken_User");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1A39605004");
        });

        modelBuilder.Entity<ServicePackage>(entity =>
        {
            entity.HasKey(e => e.PackageId).HasName("PK__ServiceP__322035CCA73B3565");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CB50E7080");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);

            entity.HasOne(d => d.Company).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__User__CompanyId__44FF419A");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__RoleId__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
