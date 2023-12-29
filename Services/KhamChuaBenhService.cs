using CharityClinic.Data.Model;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

namespace CharityClinic.Services
{
    public class KhamChuaBenhService : IBaseService<KhamChuaBenh>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public KhamChuaBenhService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Create(KhamChuaBenh entity)
        {
            applicationDbContext.KhamChuaBenhs.Add(entity);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var KhamChuaBenh = applicationDbContext.KhamChuaBenhs.Where(e => e.Id == id).FirstOrDefault();
            if(KhamChuaBenh != null)
            {
                _ = applicationDbContext.KhamChuaBenhs.Remove(KhamChuaBenh);
            }
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<KhamChuaBenh?> Get(string id)
        {
            return await applicationDbContext.KhamChuaBenhs.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task<IEnumerable<KhamChuaBenh>> GetAll()
        {
            return await applicationDbContext.KhamChuaBenhs.ToListAsync();
        }

        public Task<IEnumerable<KhamChuaBenh>> Gets(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Patch(KhamChuaBenh entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(KhamChuaBenh entity)
        {
            applicationDbContext.KhamChuaBenhs.Update(entity);
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
