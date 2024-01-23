using PrintShop.DAL.Context;
using PrintShop.DAL.Repositories.Interfaces;
using PrintShop.GlobalData.Models;
using Microsoft.EntityFrameworkCore;

namespace PrintShop.DAL.Repositories
{
    internal class PictureRepository : IPictureRepository
    {
        private readonly AppDbContext _appDbContext;

        public PictureRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Picture?> GetByIdAsync(Guid id)
        {
            return await _appDbContext.Pictures.FindAsync(id);
        }

        public async Task<Picture?> GetBySKUAsync(string skuPart)
        {
            return await _appDbContext.Pictures
                .FirstOrDefaultAsync(p =>  p.SKUPart == skuPart);
        }
    }
}
