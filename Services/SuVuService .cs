using CharityClinic.Data.Model;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

namespace CharityClinic.Services
{
    public class SuVuService : IBaseService<SuVu>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SuVuService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Create(SuVu entity)
        {
            applicationDbContext.SuVus.Add(entity);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var suVu = applicationDbContext.SuVus.Where(e => e.Id == id).FirstOrDefault();
            if(suVu != null)
            {
                _ = applicationDbContext.SuVus.Remove(suVu);
            }
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<SuVu?> Get(string id)
        {
            return await applicationDbContext.SuVus.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task<IEnumerable<SuVu>> GetAll()
        {
            return await applicationDbContext.SuVus.ToListAsync();
        }

        public Task<IEnumerable<SuVu>> Gets(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Patch(SuVu entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(SuVu entity)
        {
            applicationDbContext.SuVus.Update(entity);
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
