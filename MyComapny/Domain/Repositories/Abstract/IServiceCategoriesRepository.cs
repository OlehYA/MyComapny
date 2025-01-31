using MyComapny.Domain.Entities;

namespace MyComapny.Domain.Repositories.Abstract
{
    public interface IServiceCategoriesRepository
    {
        Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync();
        Task<ServiceCategory?> GetServiceCategoryByIdAsync(int id);
        Task ServiceCategoryAsync(ServiceCategory entity);
        Task DeleteServiceCategoryAsync(int id);
    }
}
