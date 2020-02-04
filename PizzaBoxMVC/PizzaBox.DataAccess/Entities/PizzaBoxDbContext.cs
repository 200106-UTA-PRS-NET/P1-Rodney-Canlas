using Microsoft.EntityFrameworkCore;

namespace PizzaBox.DataAccess.Entities
{
    public class PizzaBoxDbContext : DbContext
    {
        public PizzaBoxDbContext() { }

        public PizzaBoxDbContext(DbContextOptions<PizzaBoxDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<UserOrder> UserOrder { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Build table structures
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account", "PizzaBox");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityColumn();

                entity.Property(e => e.Username)
                    .HasColumnName("Username")
                    .IsRequired();

                entity.Property(e => e.Passphrase)
                    .HasColumnName("Passphrase")
                    .IsRequired();

                entity.Property(e => e.FirstName)
                    .HasColumnName("First Name")
                    .IsRequired();

                entity.Property(e => e.LastName)
                    .HasColumnName("Last Name")
                    .IsRequired();
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store", "PizzaBox");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityColumn();

                entity.Property(e => e.StoreName)
                    .HasColumnName("Store Name")
                    .IsRequired();

                entity.Property(e => e.City)
                    .HasColumnName("City")
                    .IsRequired();

                entity.Property(e => e.State)
                    .HasColumnName("State")
                    .IsRequired();

                entity.Property(e => e.Zipcode)
                    .HasColumnName("Zipcode")
                    .IsRequired();

            });

            modelBuilder.Entity<UserOrder>(entity =>
            {
                entity.ToTable("UserOrder", "PizzaBox");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .UseIdentityColumn();

                entity.Property(e => e.StoreId)
                    .HasColumnName("Store ID")
                    .IsRequired();

                entity.Property(e => e.UserId)
                    .HasColumnName("User ID")
                    .IsRequired();

                entity.Property(e => e.OrderContent)
                    .HasColumnName("Order Content")
                    .IsRequired();

                entity.Property(e => e.TotalCost)
                    .HasColumnName("Total Cost")
                    .IsRequired();

                entity.Property(e => e.OrderDateTime)
                    .HasColumnName("Order Date/Time")
                    .IsRequired();
            });
        }
    }
}
