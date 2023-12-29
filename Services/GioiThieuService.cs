using CharityClinic.Data.Model;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

namespace CharityClinic.Services
{
    public class GioiThieuService : IBaseService<GioiThieu>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public GioiThieuService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Create(GioiThieu entity)
        {
            applicationDbContext.GioiThieus.Add(entity);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var GioiThieu = applicationDbContext.GioiThieus.Where(e => e.Id == id).FirstOrDefault();
            if(GioiThieu != null)
            {
                _ = applicationDbContext.GioiThieus.Remove(GioiThieu);
            }
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<GioiThieu?> Get(string id)
        {
            return await applicationDbContext.GioiThieus.FirstOrDefaultAsync(e => e.TitleId.ToString() == id);
        }

        public async Task<IEnumerable<GioiThieu>> GetAll()
        {
            return await applicationDbContext.GioiThieus.ToListAsync();
        }

        public Task<IEnumerable<GioiThieu>> Gets(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Patch(GioiThieu entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(GioiThieu entity)
        {
            applicationDbContext.GioiThieus.Update(entity);
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
