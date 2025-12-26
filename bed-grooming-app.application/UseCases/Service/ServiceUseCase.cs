using bed_grooming_app.application.DTOs;
using bed_grooming_app.domain.EntityModel;
using bed_grooming_app.domain.Repositories;

namespace bed_grooming_app.application.UseCases.Service
{
    public class ServiceUseCase : IServiceUseCase
    {
        private readonly IServiceRepository _repository;

        public ServiceUseCase(IServiceRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ServiceDTO>> GetAllAsync()
        {
            var services = await _repository.GetActiveAsync();
            return services.Select(MapToDTO);
        }

        public async Task<ServiceDTO> GetByIdAsync(long id)
        {
            var service = await _repository.GetByIdAsync(id);

            if (service == null || !service.State)
                return null;

            return MapToDTO(service);
        }

        public async Task<ServiceDTO> CreateAsync(ServiceDTO serviceDTO)
        {
            if (string.IsNullOrWhiteSpace(serviceDTO.Name) || string.IsNullOrWhiteSpace(serviceDTO.Description))
                throw new ArgumentException("El nombre y la descripción son requeridos");

            var service = new ServiceModel
            {
                Name = serviceDTO.Name,
                Description = serviceDTO.Description,
                CreatedUserId = serviceDTO.CreatedUserId,
                State = true
            };

            var createdService = await _repository.AddAsync(service);
            return MapToDTO(createdService);
        }

        public async Task<ServiceDTO> UpdateAsync(long id, ServiceDTO serviceDTO)
        {
            if (string.IsNullOrWhiteSpace(serviceDTO.Name) || string.IsNullOrWhiteSpace(serviceDTO.Description))
                throw new ArgumentException("El nombre y la descripción son requeridos");

            var existingService = await _repository.GetByIdAsync(id);

            if (existingService == null)
                throw new KeyNotFoundException($"El servicio con ID {id} no fue encontrado");

            existingService.Name = serviceDTO.Name;
            existingService.Description = serviceDTO.Description;
            existingService.LastModifiedUserId = serviceDTO.LastModifiedUserId;
            existingService.State = serviceDTO.State;

            var updatedService = await _repository.UpdateAsync(existingService);
            return MapToDTO(updatedService);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var exists = await _repository.ExistsAsync(id);

            if (!exists)
                throw new KeyNotFoundException($"El servicio con ID {id} no fue encontrado");

            return await _repository.DeleteAsync(id);
        }

        private static ServiceDTO MapToDTO(ServiceModel service)
        {
            return new ServiceDTO
            {
                ServiceId = service.ServiceId,
                Name = service.Name,
                Description = service.Description,
                CreatedUserId = service.CreatedUserId,
                CreatedDateTime = service.CreatedDateTime,
                LastModifiedUserId = service.LastModifiedUserId,
                LastModifiedDateTime = service.LastModifiedDateTime,
                State = service.State
            };
        }
    }
}
