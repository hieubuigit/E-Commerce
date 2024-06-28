using BE_E_Commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace BE_E_Commerce.DataContext;

public partial class ECommerceContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ECommerceContext()
    {
    }

    public ECommerceContext(DbContextOptions<ECommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountActionLog> AccountActionLogs { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<BillOfLanding> BillOfLandings { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Common> Commons { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PaymentCard> PaymentCards { get; set; }

    public virtual DbSet<PaymentInfo> PaymentInfos { get; set; }

    public virtual DbSet<ProductResource> ProductResources { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewFile> ReviewFiles { get; set; }

    public virtual DbSet<Routing> Routings { get; set; }

    public virtual DbSet<Shipper> Shippers { get; set; }

    public virtual DbSet<ShippingAddress> ShippingAddresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:E-Commerce");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Account__3214EC07B77A931E");

            entity.ToTable("Account");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AccountActionLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AccountA__3214EC07A27C8B43");

            entity.ToTable("AccountActionLog");

            entity.HasIndex(e => e.AccountId, "Idx_AccountActionLog_Account");

            entity.Property(e => e.Action).HasMaxLength(500);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Location).HasMaxLength(500);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.WebBrowserName).HasMaxLength(100);

            entity.HasOne(d => d.Account).WithMany(p => p.AccountActionLogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountActionLog_Account");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Address__3214EC072B6A19D5");

            entity.ToTable("Address");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<BillOfLanding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BillOfLa__3214EC079305757A");

            entity.ToTable("BillOfLanding");

            entity.HasIndex(e => e.OrderId, "Idx_BillOfLanding_Order");

            entity.HasIndex(e => e.ShipperId, "Idx_BillOfLanding_Shipper");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ReceivedDate).HasColumnType("datetime");
            entity.Property(e => e.ShipFrom).HasMaxLength(1000);
            entity.Property(e => e.ShipTo).HasMaxLength(1000);
            entity.Property(e => e.ShippingDate).HasColumnType("datetime");
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.BillOfLandings)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillOfLanding_Order");

            entity.HasOne(d => d.Shipper).WithMany(p => p.BillOfLandings)
                .HasForeignKey(d => d.ShipperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BillOfLanding_Shipper");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC07E1073C7D");

            entity.ToTable("Cart");

            entity.Property(e => e.CreateOrderTime).HasColumnType("datetime");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Carts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cart_Account");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07CEA7B021");

            entity.ToTable("Category");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Common>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Common__3214EC070D8BF4FA");

            entity.ToTable("Common");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07696961B4");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.CityId, "Idx_Cart_Account");

            entity.HasIndex(e => e.AccountId, "Idx_Customer_Account");

            entity.HasIndex(e => e.CityId, "Idx_Customer_Address_City");

            entity.HasIndex(e => e.CountryId, "Idx_Customer_Address_Country");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.District).HasMaxLength(256);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(14)
                .IsUnicode(false);
            entity.Property(e => e.Street).HasMaxLength(256);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Ward).HasMaxLength(256);

            entity.HasOne(d => d.City).WithMany(p => p.CustomerCities)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_Customer_Address_City");

            entity.HasOne(d => d.Country).WithMany(p => p.CustomerCountries)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Customer_Address_Country");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Customer)
                .HasForeignKey<Customer>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_Account");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Discount__3214EC072B978F07");

            entity.ToTable("Discount");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ExpirationDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(1000);
            entity.Property(e => e.StarDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC07EB4639F1");

            entity.ToTable("Order");

            entity.HasIndex(e => e.AccountId, "Idx_Order_Account");

            entity.HasIndex(e => e.DiscountId, "Idx_Order_Discount");

            entity.HasIndex(e => e.PaymentCardId, "Idx_Order_PaymentCard");

            entity.HasIndex(e => e.PaymentInfoId, "Idx_Order_PaymentInfo");

            entity.HasIndex(e => e.ShippingAddressId, "Idx_Order_ShippingAddress");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Note).HasMaxLength(1000);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.ReceiverName).HasMaxLength(1000);
            entity.Property(e => e.ShippingFee).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Account");

            entity.HasOne(d => d.Discount).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Discount");

            entity.HasOne(d => d.PaymentCard).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_PaymentCard");

            entity.HasOne(d => d.PaymentInfo).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentInfoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_PaymentInfo");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderIte__3214EC0794DD8922");

            entity.ToTable("OrderItem");

            entity.HasIndex(e => e.OrderId, "Idx_OrderItem_Order");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("money");
            entity.Property(e => e.ProductId).HasMaxLength(1000);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItem_Order");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partner__3214EC071356543B");

            entity.ToTable("Partner");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Logo)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<PaymentCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentC__3214EC07DC95F5CA");

            entity.ToTable("PaymentCard");

            entity.HasIndex(e => e.AccountId, "Idx_PaymentCard_Account");

            entity.Property(e => e.CardHolderName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CardNumber)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.PaymentCards)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentCard_Account");
        });

        modelBuilder.Entity<PaymentInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaymentI__3214EC07BBCE8152");

            entity.ToTable("PaymentInfo");

            entity.Property(e => e.CardHolderName).HasMaxLength(255);
            entity.Property(e => e.CardNumber).HasMaxLength(255);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PaypalTrackingId)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SecurityCode)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductR__3214EC072CB8EF5B");

            entity.ToTable("ProductResource");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Url)
                .HasMaxLength(1000)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Review__3214EC07FB72D750");

            entity.ToTable("Review");

            entity.HasIndex(e => e.AccountId, "Idx_Review_Account");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_Account");
        });

        modelBuilder.Entity<ReviewFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReviewFi__3214EC0725D86299");

            entity.ToTable("ReviewFile");

            entity.HasIndex(e => e.ReviewId, "Idx_ReviewFile_Review");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Url)
                .HasMaxLength(1000)
                .IsUnicode(false);

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewFiles)
                .HasForeignKey(d => d.ReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReviewFile_Review");
        });

        modelBuilder.Entity<Routing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Routing__3214EC078918C234");

            entity.ToTable("Routing");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Link)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Shipper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipper__3214EC077A8C5976");

            entity.ToTable("Shipper");

            entity.HasIndex(e => e.PartnerId, "Idx_Shipper_Partner");

            entity.Property(e => e.Address).HasMaxLength(1000);
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CccdCmnd)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CCCD_CMND");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(100);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Partner).WithMany(p => p.Shippers)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Shipper_Partner");
        });

        modelBuilder.Entity<ShippingAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shipping__3214EC078D806697");

            entity.ToTable("ShippingAddress");

            entity.HasIndex(e => e.CityId, "FK_ShippingAddress_Address_City");

            entity.HasIndex(e => e.CountryId, "FK_ShippingAddress_Address_Country");

            entity.HasIndex(e => new { e.AccountId, e.CityId, e.CountryId }, "Idx_ShippingAddress_Account");

            entity.Property(e => e.Address).HasMaxLength(1000);
            entity.Property(e => e.Address2).HasMaxLength(1000);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.District).HasMaxLength(1000);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Ward).HasMaxLength(1000);

            entity.HasOne(d => d.Account).WithMany(p => p.ShippingAddresses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShippingAddress_Account");

            entity.HasOne(d => d.City).WithMany(p => p.ShippingAddressCities)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShippingAddress_Address_City");

            entity.HasOne(d => d.Country).WithMany(p => p.ShippingAddressCountries)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ShippingAddress_Address_Country");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
