namespace Data.Model.PizzaShop {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext {
        public Model1()
            : base("name=Model11") {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Beverage> Beverages { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Account>()
                .Property(e => e.Id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.PostalCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Beverage>()
                .Property(e => e.Id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Beverage>()
                .Property(e => e.OrderId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Beverage>()
                .Property(e => e.ProductId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Beverage>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Beverage>()
                .Property(e => e.TotalPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .Property(e => e.Id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.AccountId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.PaymentStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Beverages)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Pizzas)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.Id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.OrderId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.FirstToppingId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.SecondToppingId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.BorderId)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Pizza>()
                .Property(e => e.TotalPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.Id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Family)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.ListPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Beverages)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Pizzas)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.BorderId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Pizzas1)
                .WithRequired(e => e.Product1)
                .HasForeignKey(e => e.FirstToppingId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Pizzas2)
                .WithRequired(e => e.Product2)
                .HasForeignKey(e => e.SecondToppingId)
                .WillCascadeOnDelete(false);
        }
    }
}
