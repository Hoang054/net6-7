using CharityClinic.Data.Model;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

namespace CharityClinic.Services
{
    public class LichSuService : IBaseService<LichSu>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public LichSuService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Create(LichSu entity)
        {
            applicationDbContext.LichSus.Add(entity);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var LichSu = applicationDbContext.LichSus.Where(e => e.Id == id).FirstOrDefault();
            if(LichSu != null)
            {
                _ = applicationDbContext.LichSus.Remove(LichSu);
            }
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<LichSu?> Get(string id)
        {
            return await applicationDbContext.LichSus.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task<IEnumerable<LichSu>> GetAll()
        {
            return await applicationDbContext.LichSus.ToListAsync();
        }

        public Task<IEnumerable<LichSu>> Gets(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Patch(LichSu entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(LichSu entity)
        {
            applicationDbContext.LichSus.Update(entity);
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
