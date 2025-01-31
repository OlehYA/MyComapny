using Microsoft.EntityFrameworkCore;
using MyComapny.Domain.Entities;
using MyComapny.Domain.Repositories.Abstract;

namespace MyComapny.Domain.Repositories.EntityFramework
{
    public class EFServicesRepository : IServiceRepository
    {
        private readonly AppDbContext _cotext;

        public EFServicesRepository(AppDbContext context)
        {
            _cotext = context;
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await _cotext.Services.Include(x => x.ServiceCategory).ToListAsync();
        }

        public async Task<Service?> GetServiceByIdAsync(int id)
        {
            return await _cotext.Services.Include(x => x.ServiceCategory).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveServiceAsync(ServiceCategory entity)
        {
            _cotext.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            await _cotext.SaveChangesAsync();
        }

        public async Task DeleteServiceAsync(int id)
        {
            _cotext.Entry(new ServiceCategory() { Id = id }).State = EntityState.Deleted;
            await _cotext.SaveChangesAsync();
        }
    }
}
