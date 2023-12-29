using CharityClinic.Data.Model;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

namespace CharityClinic.Services
{
    public class ImageService : IBaseService<Image>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public ImageService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Create(Image entity)
        {
            applicationDbContext.Images.Add(entity);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var Image = applicationDbContext.Images.Where(e => e.Id == id).FirstOrDefault();
            if(Image != null)
            {
                _ = applicationDbContext.Images.Remove(Image);
            }
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<Image?> Get(string id)
        {
            return await applicationDbContext.Images.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task<IEnumerable<Image>> GetAll()
        {
            return await applicationDbContext.Images.ToListAsync();
        }

        public async Task<IEnumerable<Image>> Gets(int id)
        {
            return await applicationDbContext.Images.Where(e => e.DanhMucImageId == id).ToListAsync();
        }

        public Task<bool> Patch(Image entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(Image entity)
        {
            applicationDbContext.Images.Update(entity);
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
