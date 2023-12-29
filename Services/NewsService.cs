using CharityClinic.Data.Model;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

namespace CharityClinic.Services
{
    public class NewsService : IBaseService<NewsDb>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public NewsService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Create(NewsDb entity)
        {
            applicationDbContext.News.Add(entity);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            applicationDbContext.News.Remove(applicationDbContext.News.Where(e => e.Id == id).FirstOrDefault());
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<NewsDb?> Get(string id)
        {
            return await applicationDbContext.News.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task<IEnumerable<NewsDb>> GetAll()
        {
            return await applicationDbContext.News.ToListAsync();
        }

        public Task<IEnumerable<NewsDb>> Gets(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Patch(NewsDb entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(NewsDb entity)
        {
            applicationDbContext.News.Update(entity);
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
