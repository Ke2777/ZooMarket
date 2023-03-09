using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ZooMarket.Entities
{
	public partial class ZooMarket : DbContext
	{
		public ZooMarket()
			: base("name=ZooMarket")
		{
		}

		public virtual DbSet<Order> Order { get; set; }
		public virtual DbSet<OrderProduct> OrderProduct { get; set; }
		public virtual DbSet<PayType> PayType { get; set; }
		public virtual DbSet<Product> Product { get; set; }
		public virtual DbSet<ProductType> ProductType { get; set; }
		public virtual DbSet<Role> Role { get; set; }
		public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
		public virtual DbSet<User> User { get; set; }
		public virtual DbSet<UserOrder> UserOrder { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Order>()
				.HasMany(e => e.OrderProduct)
				.WithRequired(e => e.Order)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Order>()
				.HasMany(e => e.UserOrder)
				.WithRequired(e => e.Order)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<PayType>()
				.HasMany(e => e.Order)
				.WithRequired(e => e.PayType)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.OrderProduct)
				.WithRequired(e => e.Product)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<ProductType>()
				.HasMany(e => e.Product)
				.WithRequired(e => e.ProductType)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Role>()
				.HasMany(e => e.User)
				.WithRequired(e => e.Role)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<User>()
				.HasMany(e => e.UserOrder)
				.WithRequired(e => e.User)
				.WillCascadeOnDelete(false);
		}
	}
}
