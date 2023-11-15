using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PrintShop.GlobalData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrintShop.DAL.Context
{
    internal static class SeedData
    {
        internal static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole()
                { Name = "Customer", ConcurrencyStamp = "2", NormalizedName = "Customer" });
        }

        internal static void SeedPrintSizes(ModelBuilder builder)
        {
            builder.Entity<PrintSize>().HasData(
                new PrintSize(101, 30, 30),
                new PrintSize(102, 50, 50),
                new PrintSize(103, 70, 70),
                new PrintSize(104, 100, 100),
                new PrintSize(105, 150, 150),
                new PrintSize(201, 30, 45),
                new PrintSize(202, 50, 75),
                new PrintSize(203, 70, 105),
                new PrintSize(204, 100, 150),
                new PrintSize(205, 150, 225),
                new PrintSize(301, 45, 30),
                new PrintSize(302, 75, 50),
                new PrintSize(303, 105, 70),
                new PrintSize(304, 150, 100),
                new PrintSize(305, 225, 150));
        }

        internal static void SeedMaterials(ModelBuilder builder)
        {
            builder.Entity<Material>().HasData(
                new Material()
                {
                    Id = 101,
                    Name = "Kapa",
                    Description = "Direktprint på Kapa är en prisvärd utskrift som lämpar " +
                    "sig för skyltproduktion eller tillfälliga utställningar.",
                    IsActive = true
                },
                new Material()
                {
                    Id = 102,
                    Name = "Plywood",
                    Description = "Direktprint på plywood är en högkvalitativ utskrift " +
                    "direkt på träytan.",
                    IsActive = true
                },
                new Material()
                {
                    Id = 103,
                    Name = "Aluminium",
                    Description = "Tryck dina bilder på aluminium med lång hållbarhet och " +
                    "hög kvalitet. Trycket i kombination med aluminiumet ger dina bilder " +
                    "ett metalliskt skimmer och en modern industriell känsla.",
                    IsActive = true
                },
                new Material()
                {
                    Id = 104,
                    Name = "Plexiglas",
                    Description = "Tryck dina bilder på reptåligt plexiglas i tjocklekarna" +
                    " 4 mm och 8 mm. Trycket är högkvalitativ och lämpligt för både inom- " +
                    "och utomhusbruk.",
                    IsActive = true
                });
        }
    }
}
