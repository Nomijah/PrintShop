﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrintShop.GlobalData.Models;

namespace PrintShop.GlobalData.DbBuilderConfig
{
    //internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    //{
    //    public void Configure(EntityTypeBuilder<UserRole> builder)
    //    {
    //        builder.ToTable($"{nameof(UserRole)}s");

    //        builder.HasOne(ur => ur.User)
    //            .WithMany(u => u.UserRoles)
    //            .HasForeignKey(ur => ur.UserId);

    //        builder.HasOne(ur => ur.Role)
    //            .WithMany(r => r.UserRoles)
    //            .HasForeignKey(ur => ur.RoleId);
    //    }
    //}
}
