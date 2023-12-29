using CharityClinic.Data.Model;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

namespace CharityClinic.Services
{
    public class VideoService : IBaseService<Video>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public VideoService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Create(Video entity)
        {
            applicationDbContext.Videos.Add(entity);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var Video = applicationDbContext.Videos.Where(e => e.Id == id).FirstOrDefault();
            if(Video != null)
            {
                _ = applicationDbContext.Videos.Remove(Video);
            }
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Video?> Get(string id)
        {
            return await applicationDbContext.Videos.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task<IEnumerable<Video>> GetAll()
        {
            return await applicationDbContext.Videos.ToListAsync();
        }

        public Task<IEnumerable<Video>> Gets(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Patch(Video entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(Video entity)
        {
            applicationDbContext.Videos.Update(entity);
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
