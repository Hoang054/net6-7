using CharityClinic.Data.Model;
using Microsoft.EntityFrameworkCore;
using Recruit.Server.Data;

namespace CharityClinic.Services
{
    public class SlideImageService : IBaseService<SlideImage>
    {
        private readonly ApplicationDbContext applicationDbContext;

        public SlideImageService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public async Task<int> Create(SlideImage entity)
        {
            applicationDbContext.SlideImages.Add(entity);
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(int id)
        {
            var Image = applicationDbContext.SlideImages.Where(e => e.Id == id).FirstOrDefault();
            if(Image != null)
            {
                _ = applicationDbContext.SlideImages.Remove(Image);
            }
            return await applicationDbContext.SaveChangesAsync();
        }

        public async Task<SlideImage?> Get(string id)
        {
            return await applicationDbContext.SlideImages.FirstOrDefaultAsync(e => e.Id.ToString() == id);
        }

        public async Task<IEnumerable<SlideImage>> GetAll()
        {
            return await applicationDbContext.SlideImages.ToListAsync();
        }

        public async Task<IEnumerable<SlideImage>> Gets(int id)
        {
            //return await applicationDbContext.SlideImages.Where(e => e.DanhMucImageId == id).ToListAsync();
            throw new NotImplementedException();
        }

        public Task<bool> Patch(SlideImage entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(SlideImage entity)
        {
            applicationDbContext.SlideImages.Update(entity);
            return await applicationDbContext.SaveChangesAsync();
        }
    }
}
