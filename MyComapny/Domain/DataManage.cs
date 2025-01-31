using MyComapny.Domain.Repositories.Abstract;

namespace MyComapny.Domain
{
    public class DataManage
    {
        public IServiceCategoriesRepository ServiceCategories {  get; set; }
        public IServiceRepository Service {  get; set; }

        public DataManage(IServiceCategoriesRepository serviceCategoriesRepository, IServiceRepository serviceRepository) 
        {
            ServiceCategories = serviceCategoriesRepository;
            Service = serviceRepository;
        }
    }
}
