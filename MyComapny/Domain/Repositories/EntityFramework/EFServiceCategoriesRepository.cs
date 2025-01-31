using Microsoft.EntityFrameworkCore;
using MyComapny.Domain.Entities;
using MyComapny.Domain.Repositories.Abstract;

namespace MyComapny.Domain.Repositories.EntityFramework
{
    public class EFServiceCategoriesRepository:IServiceCategoriesRepository
    {
        private readonly AppDbContext _cotext;

        public EFServiceCategoriesRepository(AppDbContext context)
        {
            _cotext = context;
        }

        public async Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync()
        {
            return await _cotext.ServiceCategories.Include(x=>x.Services).ToListAsync();
        }

        public async Task<ServiceCategory?> GetServiceCategoryByIdAsync(int id)
        {
            return await _cotext.ServiceCategories.Include(x => x.Services).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task ServiceCategoryAsync(ServiceCategory entity)
        {
            _cotext.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _cotext.SaveChangesAsync();
        }

        public async Task DeleteServiceCategoryAsync(int id)
        {
            _cotext.Entry(new ServiceCategory() { Id = id }).State = EntityState.Deleted;
            await _cotext.SaveChangesAsync();
        }
    }
}
