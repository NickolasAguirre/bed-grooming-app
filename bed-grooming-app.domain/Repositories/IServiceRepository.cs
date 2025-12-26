using bed_grooming_app.domain.EntityModel;

namespace bed_grooming_app.domain.Repositories
{
    public interface IServiceRepository
    {
        Task<ServiceModel> GetByIdAsync(long id);
        Task<IEnumerable<ServiceModel>> GetAllAsync();
        Task<IEnumerable<ServiceModel>> GetActiveAsync();
        Task<ServiceModel> AddAsync(ServiceModel service);
        Task<ServiceModel> UpdateAsync(ServiceModel service);
        Task<bool> DeleteAsync(long id);
        Task<bool> ExistsAsync(long id);
    }
}
