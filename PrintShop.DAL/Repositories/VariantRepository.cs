using Microsoft.EntityFrameworkCore;
using PrintShop.DAL.Context;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Models;
using PrintShop.GlobalData.Models.DTOs.GenericDtos;

namespace PrintShop.DAL.Repositories
{
    internal class VariantRepository : IVariantRepository
    {
        private readonly AppDbContext _context;
        public VariantRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<VariantGetDto>> GetAllDtoAsync()
        {
            return await _context.Variants
                .Select(x => new VariantGetDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    Price = x.Price,
                    MaterialId = x.MaterialId,
                    PrintSizeId = x.PrintSizeId,
                    SKUPart = x.SKUPart
                })
                .ToListAsync();
        }

        public async Task<VariantGetDto?> GetDtoByIdAsync(int Id)
        {
            return await _context.Variants
                .Select(x => new VariantGetDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    Price = x.Price,
                    MaterialId = x.MaterialId,
                    PrintSizeId = x.PrintSizeId,
                    SKUPart = x.SKUPart
                }).FirstOrDefaultAsync(x => x.Id == Id);
        }

        internal async Task<IEnumerable<Variant>> GetWithInclude(int? id)
        {
            if (id == null)
                return await _context.Variants
                    .Include(v => v.Size)
                    .Include(v => v.Material)
                    .ToListAsync();
            else
                return await _context.Variants
                    .Include(v => v.Size)
                    .Include(v => v.Material)
                    .Where(v => v.Id == id)
                    .ToListAsync();
        }
    }
}
