using bed_grooming_app.application.DTOs;
using bed_grooming_app.application.UseCases.Service;
using Microsoft.AspNetCore.Mvc;

namespace bed_grooming_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceUseCase _serviceUseCase;
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(IServiceUseCase serviceUseCase, ILogger<ServiceController> logger)
        {
            _serviceUseCase = serviceUseCase;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene la lista de todos los servicios activos
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetAllServices()
        {
            try
            {
                var services = await _serviceUseCase.GetAllAsync();
                return Ok(services);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener servicios: {ex.Message}");
                return StatusCode(500, new { message = "Error al obtener los servicios", error = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un servicio específico por ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDTO>> GetServiceById(long id)
        {
            try
            {
                var service = await _serviceUseCase.GetByIdAsync(id);

                if (service == null)
                    return NotFound(new { message = "Servicio no encontrado" });

                return Ok(service);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener servicio: {ex.Message}");
                return StatusCode(500, new { message = "Error al obtener el servicio", error = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo servicio
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ServiceDTO>> CreateService([FromBody] ServiceDTO serviceDTO)
        {
            try
            {
                var createdService = await _serviceUseCase.CreateAsync(serviceDTO);
                return CreatedAtAction(nameof(GetServiceById), new { id = createdService.ServiceId }, createdService);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning($"Validación fallida al crear servicio: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear servicio: {ex.Message}");
                return StatusCode(500, new { message = "Error al crear el servicio", error = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un servicio existente
        /// </summary>
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceDTO>> UpdateService(long id, [FromBody] ServiceDTO serviceDTO)
        {
            try
            {
                var updatedService = await _serviceUseCase.UpdateAsync(id, serviceDTO);
                return Ok(updatedService);
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning($"Validación fallida al actualizar servicio: {ex.Message}");
                return BadRequest(new { message = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning($"Servicio no encontrado: {ex.Message}");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar servicio: {ex.Message}");
                return StatusCode(500, new { message = "Error al actualizar el servicio", error = ex.Message });
            }
        }

        /// <summary>
        /// Elimina (desactiva) un servicio
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(long id)
        {
            try
            {
                var result = await _serviceUseCase.DeleteAsync(id);

                if (!result)
                    return BadRequest(new { message = "No fue posible eliminar el servicio" });

                return Ok(new { message = "Servicio eliminado correctamente" });
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning($"Servicio no encontrado: {ex.Message}");
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar servicio: {ex.Message}");
                return StatusCode(500, new { message = "Error al eliminar el servicio", error = ex.Message });
            }
        }
    }
}
