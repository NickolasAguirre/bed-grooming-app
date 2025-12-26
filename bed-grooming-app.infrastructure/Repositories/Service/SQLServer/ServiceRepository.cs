using bed_grooming_app.domain.EntityModel;
using bed_grooming_app.domain.Repositories;
using bed_grooming_app.repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace bed_grooming_app.infrastructure.Repositories.Service.SQLServer
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly BedGroomingContext _bedGroomingContext;

        public ServiceRepository(BedGroomingContext context)
        {
            _bedGroomingContext = context;
        }

        public async Task<ServiceModel> GetByIdAsync(long id)
        {
            return await _bedGroomingContext.Service.FirstOrDefaultAsync(s => s.ServiceId == id);
        }

        public async Task<IEnumerable<ServiceModel>> GetAllAsync()
        {
            return await _bedGroomingContext.Service.ToListAsync();
        }

        public async Task<IEnumerable<ServiceModel>> GetActiveAsync()
        {
            return await _bedGroomingContext.Service.Where(s => s.State).ToListAsync();
        }

        public async Task<ServiceModel> AddAsync(ServiceModel service)
        {
            service.CreatedDateTime = DateTime.UtcNow;
            service.State = true;

            _bedGroomingContext.Service.Add(service);
            await _bedGroomingContext.SaveChangesAsync();
            
            return service;
        }

        public async Task<ServiceModel> UpdateAsync(ServiceModel service)
        {
            var existingService = await _bedGroomingContext.Service.FirstOrDefaultAsync(s => s.ServiceId == service.ServiceId);
            
            if (existingService == null)
                return null;

            existingService.Name = service.Name;
            existingService.Description = service.Description;
            existingService.LastModifiedDateTime = DateTime.UtcNow;
            existingService.LastModifiedUserId = service.LastModifiedUserId;
            existingService.State = service.State;

            _bedGroomingContext.Service.Update(existingService);
            await _bedGroomingContext.SaveChangesAsync();

            return existingService;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var service = await _bedGroomingContext.Service.FirstOrDefaultAsync(s => s.ServiceId == id);
            
            if (service == null)
                return false;

            service.State = false;
            service.LastModifiedDateTime = DateTime.UtcNow;

            _bedGroomingContext.Service.Update(service);
            await _bedGroomingContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ExistsAsync(long id)
        {
            return await _bedGroomingContext.Service.AnyAsync(s => s.ServiceId == id);
        }
    }
}
