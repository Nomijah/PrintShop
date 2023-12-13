using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintShop.GlobalData.Models;

namespace PrintShop.GlobalData.DbBuilderConfig
{
    //internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    //{
    //    public void Configure(EntityTypeBuilder<Role> builder)
    //    {
    //        builder.ToTable($"{nameof(Role)}s");

    //        builder.HasKey(r => r.Id);
    //        builder.HasMany(r => r.UserRoles)
    //            .WithOne(r => r.Role)
    //            .HasForeignKey(r => r.RoleId)
    //            .IsRequired()
    //            .OnDelete(DeleteBehavior.Cascade);
    //    }
    //}
}
