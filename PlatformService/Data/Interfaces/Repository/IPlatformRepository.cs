using PlatformService.Models;

namespace PlatformService.Data.Interfaces.Repository
{
    public interface IPlatformRepository
    {
        Task<bool> SaveChanves();
        Task<IEnumerable<Platform>> GetAll();
        Task<Platform> GetById(int id);
        void Create(Platform platform);
    }
}
