using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Order_Manager.Models.Domain;

namespace Order_Manager.Models
{
    public class OrderContext: IdentityDbContext<ApplicationUser>
    {
        public OrderContext(DbContextOptions<OrderContext> options)
        : base(options){

        }
        
        public DbSet<ApplicationUser> ApplicationUsers {get; set;}
        public DbSet<Cart> Carts {get; set;}
        public DbSet<Office> Offices {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<Product> Products {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

           modelBuilder.Entity<Cart>(entity=>{
               entity.Property(key=> key.CartId).IsRequired(true).ValueGeneratedOnAdd();
               entity.HasOne(cart=> cart.Office).WithMany(office=> office.Carts).HasForeignKey("OfficeId");
               entity.Property(cart=> cart.PhoneNumber).IsRequired(false);
               entity.Property(cart=> cart.Email).IsRequired(false);
               entity.Property(cart=> cart.IsDelivered).HasDefaultValue(false);
               entity.HasMany(cart=> cart.Orders).WithOne(order=> order.Cart);
           });

           modelBuilder.Entity<Office>(entity=>{
               entity.Property(key=> key.OfficeId).IsRequired(true).ValueGeneratedOnAdd();
               entity.HasMany(office=> office.Carts).WithOne(cart=> cart.Office);
           });

           modelBuilder.Entity<Order>(entity=>{
               entity.Property(key=> key.OrderId).IsRequired(true).ValueGeneratedOnAdd();
               entity.HasOne(order=> order.Product).WithMany(product=> product.Orders).HasForeignKey("ProductId");
               entity.HasOne(order=> order.Cart).WithMany(cart=> cart.Orders).HasForeignKey("CartId");
           });

           modelBuilder.Entity<Product>(entity=>{
               entity.Property(key=> key.ProductId).IsRequired(true).ValueGeneratedOnAdd();
               entity.HasMany(product=> product.Orders).WithOne(order=> order.Product);
           });
        }
    }
}