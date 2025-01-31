using MyComapny.Domain.Entities;

namespace MyComapny.Domain.Repositories.Abstract
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetServicesAsync();
        Task<Service?> GetServiceByIdAsync(int id);
        Task SaveServiceAsync(ServiceCategory entity);
        Task DeleteServiceAsync(int id);
    }
}
