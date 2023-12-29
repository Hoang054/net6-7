using CharityClinic.Data.Model;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

namespace CharityClinic.Services
{
    public class NguoiBenLeService : IBaseService<NguoiBenLe>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public NguoiBenLeService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Create(NguoiBenLe entity)
        {
            applicationDbContext.NguoiBenLes.Add(entity);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var NguoiBenLe = applicationDbContext.NguoiBenLes.Where(e => e.Id == id).FirstOrDefault();
            if(NguoiBenLe != null)
            {
                _ = applicationDbContext.NguoiBenLes.Remove(NguoiBenLe);
            }
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<NguoiBenLe?> Get(string id)
        {
            return await applicationDbContext.NguoiBenLes.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task<IEnumerable<NguoiBenLe>> GetAll()
        {
            return await applicationDbContext.NguoiBenLes.ToListAsync();
        }

        public Task<IEnumerable<NguoiBenLe>> Gets(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Patch(NguoiBenLe entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(NguoiBenLe entity)
        {
            applicationDbContext.NguoiBenLes.Update(entity);
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
