using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrintShop.GlobalData.Models;
using System.Reflection.Emit;

namespace PrintShop.DAL.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid, IdentityUserClaim<Guid>,
    IdentityUserRole<Guid>, IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
            builder.Entity<Favorite>().HasKey(f => new { f.PictureId, f.UserId });
            builder.Entity<UserOrder>().HasKey(c => new { c.UserId, c.OrderId });
            builder.Entity<UserCreatorId>().HasKey(c => new { c.CreatorId, c.UserId });
            builder.Entity<Tag>().HasKey(c => new { c.Name });
            SeedData.SeedRoles(builder);
            SeedData.SeedPrintSizes(builder);
            SeedData.SeedMaterials(builder);
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountProduct> DiscountProducts { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderRow> OrderRows { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<PrintSize> PrintSizes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserCreatorId> UserCreatorIds { get; set; }
        public DbSet<UserOrder> UserOrders { get; set; }
        public DbSet<Variant> Variants { get; set; }

    }
}
