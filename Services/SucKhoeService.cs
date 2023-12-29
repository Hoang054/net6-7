using CharityClinic.Data.Model;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

namespace CharityClinic.Services
{
    public class SucKhoeService : IBaseService<SucKhoe>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SucKhoeService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Create(SucKhoe entity)
        {
            applicationDbContext.SucKhoes.Add(entity);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var SucKhoe = applicationDbContext.SucKhoes.Where(e => e.Id == id).FirstOrDefault();
            if(SucKhoe != null)
            {
                _ = applicationDbContext.SucKhoes.Remove(SucKhoe);
            }
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<SucKhoe?> Get(string id)
        {
            return await applicationDbContext.SucKhoes.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task<IEnumerable<SucKhoe>> GetAll()
        {
            return await applicationDbContext.SucKhoes.ToListAsync();
        }

        public Task<IEnumerable<SucKhoe>> Gets(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Patch(SucKhoe entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(SucKhoe entity)
        {
            applicationDbContext.SucKhoes.Update(entity);
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
