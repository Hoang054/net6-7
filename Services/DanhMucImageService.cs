using CharityClinic.Data.Model;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

namespace CharityClinic.Services
{
    public class DanhMucImageService : IBaseService<DanhMucImage>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public DanhMucImageService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Create(DanhMucImage entity)
        {
            applicationDbContext.DanhMucImages.Add(entity);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var DanhMucImage = applicationDbContext.DanhMucImages.Where(e => e.Id == id).FirstOrDefault();
            if(DanhMucImage != null)
            {
                _ = applicationDbContext.DanhMucImages.Remove(DanhMucImage);
            }
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<DanhMucImage?> Get(string id)
        {
            return await applicationDbContext.DanhMucImages.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task<IEnumerable<DanhMucImage>> GetAll()
        {
            return await applicationDbContext.DanhMucImages.ToListAsync();
        }

        public Task<IEnumerable<DanhMucImage>> Gets(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Patch(DanhMucImage entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(DanhMucImage entity)
        {
            applicationDbContext.DanhMucImages.Update(entity);
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
