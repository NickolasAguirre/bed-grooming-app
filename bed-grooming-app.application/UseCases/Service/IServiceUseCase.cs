using bed_grooming_app.application.DTOs;

namespace bed_grooming_app.application.UseCases.Service
{
    public interface IServiceUseCase
    {
        Task<IEnumerable<ServiceDTO>> GetAllAsync();
        Task<ServiceDTO> GetByIdAsync(long id);
        Task<ServiceDTO> CreateAsync(ServiceDTO serviceDTO);
        Task<ServiceDTO> UpdateAsync(long id, ServiceDTO serviceDTO);
        Task<bool> DeleteAsync(long id);
    }
}
