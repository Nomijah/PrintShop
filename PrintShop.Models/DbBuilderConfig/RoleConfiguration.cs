using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintShop.GlobalData.Models;

namespace PrintShop.GlobalData.DbBuilderConfig
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable($"{nameof(Role)}s").Property(r => r.Id).HasColumnName("RoleId");
        }
    }
}
