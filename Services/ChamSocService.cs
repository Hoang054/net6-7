using CharityClinic.Data.Model;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

namespace CharityClinic.Services
{
    public class ChamSocService : IBaseService<ChamSoc>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ChamSocService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Create(ChamSoc entity)
        {
            applicationDbContext.ChamSocs.Add(entity);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var ChamSoc = applicationDbContext.ChamSocs.Where(e => e.Id == id).FirstOrDefault();
            if(ChamSoc != null)
            {
                _ = applicationDbContext.ChamSocs.Remove(ChamSoc);
            }
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<ChamSoc?> Get(string id)
        {
            return await applicationDbContext.ChamSocs.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task<IEnumerable<ChamSoc>> GetAll()
        {
            return await applicationDbContext.ChamSocs.ToListAsync();
        }

        public Task<IEnumerable<ChamSoc>> Gets(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Patch(ChamSoc entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(ChamSoc entity)
        {
            applicationDbContext.ChamSocs.Update(entity);
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
