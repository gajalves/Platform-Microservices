using Microsoft.EntityFrameworkCore;
using PlatformService.Data.Context;
using PlatformService.Data.Interfaces.Repository;
using PlatformService.Models;

namespace PlatformService.Data.Repository
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly PlatformDbContext _context;
        
        public PlatformRepository(PlatformDbContext context)
        {
            _context = context;
        }

        public async void Create(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _context.Platforms.Add(platform);
        }

        public async Task<IEnumerable<Platform>> GetAll()
        {
            return await _context.Platforms.AsNoTracking().ToListAsync();
        }

        public async Task<Platform> GetById(int id)
        {
            return await _context.Platforms.FirstOrDefaultAsync(plat => plat.Id == id);
        }

        public async Task<bool> SaveChanves()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
